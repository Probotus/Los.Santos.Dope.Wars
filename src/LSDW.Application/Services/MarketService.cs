using LSDW.Application.Interfaces.Application.Services;
using LSDW.Application.Interfaces.Infrastructure.Services;
using LSDW.Domain.Enumerators;
using LSDW.Domain.Extensions;
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
	private readonly IDealerCollection _dealers;
	private readonly IPlayer _player;
	private readonly IMarketSettings _settings;
	private readonly ILoggerService _loggerService;
	private readonly IWorldService _worldProvider;
	private DateTime _lastRefresh;
	private DateTime _lastRestock;

	/// <summary>
	/// Initializes a new instance of the market service class.
	/// </summary>
	/// <param name="domainService">The domain service instance to use.</param>
	/// <param name="infrastructureService">The infrastructure service instance to use.</param>
	public MarketService(IDomainService domainService, IInfrastructureService infrastructureService)
	{
		_dealers = domainService.Dealers;
		_player = domainService.Player;
		_settings = domainService.Settings.Market;
		_loggerService = infrastructureService.LoggerService;
		_worldProvider = domainService.WorldService;

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
				NextRefresh = now.AddHours(_settings.RefreshInterval.Value);
			}

			if (NextRestock < now)
			{
				Restock();
				NextRestock = now.AddHours(_settings.RestockInterval.Value);
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
		float maxValue = _settings.MaximumDrugPrice.Value;
		float minValue = _settings.MinimumDrugPrice.Value;
		float playerfactor = _player.Level / (float)1000;
		float averageValue = type.GetAverageValue();
		int highestValue = (int)Math.Ceiling((maxValue + playerfactor) * averageValue);
		int lowestValue = (int)Math.Ceiling((minValue - playerfactor) * averageValue);

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
