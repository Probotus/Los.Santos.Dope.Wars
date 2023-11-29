using GTA.Math;

using LSDW.Application.Interfaces.Application.Missions;
using LSDW.Application.Interfaces.Infrastructure.Services;
using LSDW.Application.Missions.Base;
using LSDW.Domain.Enumerators;
using LSDW.Domain.Extensions;
using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Manager;
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
	private readonly IWorldService _worldService;
	private IDealer? _dealer;
	private bool _showMenu;

	/// <summary>
	/// Initializes a new instance of the street trafficking mission class.
	/// </summary>
	/// <param name="dealers">The dealer collection instance to use.</param>
	/// <param name="loggerService">The logger service instance to use.</param>
	/// <param name="stateService">The state service instance to use.</param>
	/// <param name="domainManager">The domain manager instance to use.</param>
	public StreetTrafficking(IDealerCollection dealers, ILoggerService loggerService, IStateService stateService, IDomainManager domainManager) : base(stateService)
	{
		_dealers = dealers;
		_loggerService = loggerService;
		_notificationService = domainManager.NotificationService;
		_playerService = domainManager.PlayerService;
		_worldService = domainManager.WorldService;
	}

	public IDealer? Dealer { get => _dealer; private set => SetProperty(ref _dealer, value); }
	public bool ShowMenu { get => _showMenu; private set => SetProperty(ref _showMenu, value); }

	public void Discover()
	{
		try
		{
			if (Dealer is not null)
				return;

			_dealers.ForEach(dealer => dealer.Discovered && dealer.Blip is null, dealer => dealer.Discover(_worldService));

			_dealers.ForEach(dealer => !dealer.Discovered, dealer =>
			{
				Vector3 playerPosition = _playerService.Position;

				if (dealer.Position.DistanceTo(playerPosition) <= DiscoverDistance)
				{
					dealer.Discover(_worldService);

					_notificationService.Show(
						subject: "Dealer found!",
						message: $"You have found the dealer in the area of '{_worldService.GetZoneLocalizedName(dealer.Position)}'."
						);
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
			if (Dealer is null)
			{
				_dealers.ForEach(dealer =>
				{
					if (dealer.Position.DistanceTo(_playerService.Position) <= CreateDistance)
					{
						Dealer = dealer;
						Dealer.Create(_worldService);
						return;
					}
				});
			}
			else
			{
				if (Dealer.Position.DistanceTo(_playerService.Position) <= InteractionDistance)
				{
					if (Dealer.Ped is null)
						return;

					Dealer.Ped.Task.LookAt(_playerService.Character);
					ShowMenu = true;
				}
				else if (Dealer.Position.DistanceTo(_playerService.Position) > InteractionDistance)
				{
					if (Dealer.Ped is null)
						return;

					Dealer.Ped.Task.ClearLookAt();
					ShowMenu = false;
				}
				else if (Dealer.Position.DistanceTo(_playerService.Position) > CreateDistance)
				{
					Dealer.Delete();
					Dealer = null;
					return;
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
				return;
			}

			if (Status == MissionStatus.RUNNING)
			{
				Stop();
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
			if (Dealer is not null)
				return;

			Vector3 randomPosition = _playerService.Position.Around(TrackDistance);
			Vector3 possiblePosition = _worldService.GetNextPositionOnSidewalk(randomPosition);

			if (possiblePosition.Equals(Vector3.Zero))
				return;

			string zoneName = _worldService.GetZoneDisplayName(possiblePosition);

			if (_dealers.Any(x => x.Zone == zoneName))
				return;

			if (_dealers.Any(x => x.Position.DistanceTo(possiblePosition) <= TerritoryDistance))
				return;

			IDealer dealer = DomainFactory.CreateDealer(possiblePosition, zoneName);

			_dealers.Add(dealer);

			_notificationService.Show(
				subject: "Dealer spotted!",
				message: $"A dealer was spotted in the area of '{_worldService.GetZoneLocalizedName(dealer.Position)}'."
				);
		}
		catch (Exception ex)
		{
			_loggerService.Critical("Critical error occured!", ex);
		}
	}
}
