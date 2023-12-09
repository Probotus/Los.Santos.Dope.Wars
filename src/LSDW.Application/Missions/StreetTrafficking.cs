using GTA.Math;

using LSDW.Application.Interfaces.Application.Missions;
using LSDW.Application.Interfaces.Infrastructure.Services;
using LSDW.Application.Interfaces.Presentation.Menus;
using LSDW.Application.Missions.Base;
using LSDW.Domain.Enumerators;
using LSDW.Domain.Extensions;
using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Interfaces.Services;

namespace LSDW.Application.Missions;

/// <summary>
/// The street trafficking mission class.
/// </summary>
internal sealed class StreetTrafficking : MissionBase, IStreetTrafficking
{
	private const float TrackDistance = 400;
	private const float TerritoryDistance = 250;
	private const float DiscoverDistance = 150;
	private const float CreateDistance = 100;
	private const float InteractionDistance = 3;

	private readonly IDealerCollection _dealers;
	private readonly ILoggerService _loggerService;
	private readonly INotificationService _notificationService;
	private readonly IPlayerService _playerService;
	private readonly ISettings _settings;
	private readonly ITraffickingMenu _traffickingMenu;
	private readonly IWorldService _worldService;
	private IDealer? _dealer;
	private bool _dealerIslooking;

	/// <summary>
	/// Initializes a new instance of the street trafficking mission class.
	/// </summary>
	/// <param name="domainService">The domain manager instance to use.</param>
	/// <param name="infrastructureService">The infrastructure manager instance to use.</param>
	/// <param name="traffickingMenu">The trafficking menu instance to use.</param>
	public StreetTrafficking(IDomainService domainService, IInfrastructureService infrastructureService, ITraffickingMenu traffickingMenu) : base(infrastructureService.StateService)
	{
		_dealers = domainService.Dealers;
		_loggerService = infrastructureService.LoggerService;
		_notificationService = domainService.NotificationService;
		_playerService = domainService.PlayerService;
		_settings = domainService.Settings;
		_traffickingMenu = traffickingMenu;
		_worldService = domainService.WorldService;
	}

	public void Discover()
	{
		try
		{
			if (_dealer is not null)
				return;

			_dealers.ForEach(dealer => dealer.Discovered && dealer.Blip is null, dealer => dealer.Discover());

			_dealers.ForEach(dealer => !dealer.Discovered, dealer =>
			{
				if (dealer.Position.DistanceTo(_playerService.Position) <= DiscoverDistance || !_settings.Trafficking.DiscoverDealer.Value)
				{
					dealer.Discover();

					string zoneFullName = _worldService.GetZoneLocalizedName(dealer.Position);

					_notificationService.Show(
						subject: "Dealer found!",
						message: $"You have found the dealer in the area of {zoneFullName}."
						);

					_loggerService.Information($"Dealer found in {zoneFullName}.");
				}
			});
		}
		catch (Exception ex)
		{
			_loggerService.Critical("Critical error occured!", ex);
		}
	}

	public void InProximity()
	{
		try
		{
			if (_dealer is null)
			{
				foreach (IDealer dealer in _dealers)
				{
					if (dealer.Position.DistanceTo(_playerService.Position) <= CreateDistance)
					{
						_dealer = dealer;
						_dealer.Create();
						break;
					}
				}
			}

			if (_dealer is not null)
			{
				if (_dealer.Position.DistanceTo(_playerService.Position) <= InteractionDistance)
				{
					if (_dealer.Ped is null)
						return;

					if (!_dealerIslooking)
					{
						_dealer.Ped.Task.LookAt(_playerService.Character);
						_dealerIslooking = true;
					}
				}

				if (_dealer.Position.DistanceTo(_playerService.Position) > InteractionDistance)
				{
					if (_dealer.Ped is null)
						return;

					if (_dealerIslooking)
					{
						_dealer.Ped.Task.ClearLookAt();
						_dealerIslooking = false;
					}
				}

				if (_dealer.Position.DistanceTo(_playerService.Position) > CreateDistance)
				{
					_dealer.Delete();
					_dealer = null;
				}
			}
		}
		catch (Exception ex)
		{
			_loggerService.Critical("Critical error occured!", ex);
		}
	}

	public void OnKeyDown(object sender, KeyEventArgs e) { }

	public void OnKeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F10)
		{
			if (Status == MissionStatus.STOPPED)
			{
				Start();
				_loggerService.Information($"{nameof(StreetTrafficking)} started.");
				return;
			}

			if (Status == MissionStatus.RUNNING)
			{
				Stop();
				_loggerService.Information($"{nameof(StreetTrafficking)} stoped.");
				return;
			}
		}
	}

	public override void OnTick(object sender, EventArgs e)
	{
		while (!_playerService.CanControlCharacter && !_playerService.CanStartMission)
			return;

		while (Status.Equals(MissionStatus.STOPPED))
			return;

		Track();
		InProximity();
		Discover();
	}

	public override void Stop()
	{
		_dealers.ForEach(dealer => dealer.CleanUp());
		base.Stop();
	}

	public void Track()
	{
		try
		{
			if (_dealer is not null)
				return;

			Vector3 randomPosition = _playerService.Position.Around(TrackDistance);
			Vector3 position = _worldService.GetNextPositionOnPavement(randomPosition);

			if (position.Equals(Vector3.Zero))
				return;

			if (!_settings.Trafficking.MultipleDealer.Value)
			{
				if (_dealers.Any(x => x.Zone == _worldService.GetZoneDisplayName(position)))
					return;
			}

			if (_dealers.Any(x => x.Position.DistanceTo(position) <= TerritoryDistance))
				return;

			IDealer dealer = DomainFactory.CreateDealer(_settings, _worldService, position);

			_dealers.Add(dealer);

			string zoneFullName = _worldService.GetZoneLocalizedName(dealer.Position);

			_notificationService.Show(
				subject: "Dealer spotted!",
				message: $"A dealer was spotted in the area of {zoneFullName}."
				);

			_loggerService.Information($"Dealer spotted in {zoneFullName}.");
		}
		catch (Exception ex)
		{
			_loggerService.Critical("Critical error occured!", ex);
		}
	}
}
