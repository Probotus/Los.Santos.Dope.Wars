using LSDW.Application.Interfaces.Application.Services;
using LSDW.Application.Interfaces.Infrastructure.Services;
using LSDW.Domain.Enumerators;
using LSDW.Domain.Extensions;
using LSDW.Domain.Interfaces.Manager;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Interfaces.Services;
using LSDW.Domain.Models.Base;

namespace LSDW.Application.Services;

/// <summary>
/// The market service class.
/// </summary>
internal sealed class MarketService : NotifyPropertyBase, IMarketService
{
	private static readonly Random Random = new(Guid.NewGuid().GetHashCode());

	private const int RefreshInterval = 6;
	private const int RestockInterval = 24;
	private const float MaxValue = 1.15f;
	private const float MinValue = 0.85f;

	private readonly IDealerCollection _dealers;
	private readonly IPlayer _player;
	private readonly ILoggerService _loggerService;
	private readonly IWorldService _worldProvider;
	private DateTime _lastRefresh;
	private DateTime _lastRestock;

	/// <summary>
	/// Initializes a new instance of the market service class.
	/// </summary>
	/// <param name="dealers">The dealer collection instance to use.</param>
	/// <param name="player">The player instance to use.</param>
	/// <param name="loggerService">The logger service instance to use.</param>
	/// <param name="domainManager">The domain manager instance to use.</param>
	public MarketService(IDealerCollection dealers, IPlayer player, ILoggerService loggerService, IDomainManager domainManager)
	{
		_dealers = dealers;
		_player = player;
		_loggerService = loggerService;
		_worldProvider = domainManager.WorldService;

		_dealers.CollectionChanged += (s, e) => OnDealerCollectionChanged();
		_dealers.CollectionChanging += (s, e) => OnDealerCollectionChanging();
	}

	public DateTime NextRefresh { get => _lastRefresh; private set => SetProperty(ref _lastRefresh, value); }
	public DateTime NextRestock { get => _lastRestock; private set => SetProperty(ref _lastRestock, value); }

	public void OnTick(object sender, EventArgs e)
	{
		try
		{
			DateTime now = _worldProvider.Now;

			if (NextRefresh < now)
			{
				Refresh();
				NextRefresh = now.AddHours(RefreshInterval);
			}

			if (NextRestock < now)
			{
				Restock();
				NextRestock = now.AddHours(RestockInterval);
			}
		}
		catch (Exception ex)
		{
			_loggerService.Critical("Critical error occured!", ex);
		}
	}

	public void Refresh()
		=> _dealers.ForEach(dealer => dealer.Discovered, Refresh);

	public void Refresh(IDealer dealer)
	{
		int minMoney = _player.Level * 50;
		int maxMoney = _player.Level * 250;

		dealer.Money = Random.Next(minMoney, maxMoney);
		dealer.Drugs.ForEach(drug =>
		{
			int value = GetCurrentDrugValue(drug.Type);
			drug.SetValues(drug.Quantity, value);
		});
	}

	public void Restock()
	{
		_dealers.ForEach(dealer => dealer.Discovered, dealer =>
		{
			Restock(dealer);
			Refresh(dealer);
		});
	}

	public void Restock(IDealer dealer)
	{
		dealer.Drugs.ForEach(drug =>
		{
			int quantity = GetCurrentDrugQuantity(drug.Type);
			drug.SetValues(quantity, drug.Value);
		});
	}

	/// <summary>
	/// Returns the current value of the drug.
	/// </summary>
	/// <param name="type">The drug type to use.</param>
	/// <returns>The value of the drug.</returns>
	private int GetCurrentDrugValue(DrugType type)
	{
		float playerfactor = _player.Level / (float)1000;
		float averageValue = type.GetAverageValue();
		int highestValue = (int)Math.Ceiling((MaxValue + playerfactor) * averageValue);
		int lowestValue = (int)Math.Ceiling((MinValue - playerfactor) * averageValue);

		return Random.Next(lowestValue, highestValue);
	}

	/// <summary>
	/// Returns the current quantity of the drug.
	/// </summary>
	/// <param name="type">The drug type to use.</param>
	/// <returns>The quantity of the drug.</returns>
	private int GetCurrentDrugQuantity(DrugType type)
	{
		if (Random.NextDouble() > type.GetProbability())
			return 0;

		int lowestQuantity = _player.Level;
		int highestQuantity = _player.Level * 5;

		return Random.Next(lowestQuantity, highestQuantity);
	}

	private void OnDealerCollectionChanged()
		=> _dealers.ForEach(d => d.PropertyChanged += (s, e) => OnDealerDiscovered(s, e.PropertyName));

	private void OnDealerCollectionChanging()
		=> _dealers.ForEach(d => d.PropertyChanged -= (s, e) => OnDealerDiscovered(s, e.PropertyName));

	private void OnDealerDiscovered(object sender, string propertyName)
	{
		if (sender is IDealer dealer && propertyName == nameof(IDealer.Discovered))
		{
			Restock(dealer);
			Refresh(dealer);
		}
	}
}
