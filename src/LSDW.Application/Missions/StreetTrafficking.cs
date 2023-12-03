using GTA.Math;

using LSDW.Application.Interfaces.Application.Missions;
using LSDW.Application.Interfaces.Infrastructure.Managers;
using LSDW.Application.Interfaces.Infrastructure.Services;
using LSDW.Application.Interfaces.Presentation.Menus;
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
	private readonly ITraffickingMenu _traffickingMenu;
	private readonly IPlayerService _playerService;
	private readonly IWorldService _worldService;
	private IDealer? _dealer;
	private bool _showMenu;

	/// <summary>
	/// Initializes a new instance of the street trafficking mission class.
	/// </summary>
	/// <param name="dealers">The dealer collection instance to use.</param>
	/// <param name="infrastructureManager">The infrastructure manager instance to use.</param>
	/// <param name="domainManager">The domain manager instance to use.</param>
	/// <param name="traffickingMenu">The trafficking menu instance to use.</param>
	public StreetTrafficking(IDealerCollection dealers, IInfrastructureManager infrastructureManager, IDomainManager domainManager, ITraffickingMenu traffickingMenu) : base(infrastructureManager.StateService)
	{
		_dealers = dealers;
		_loggerService = infrastructureManager.LoggerService;
		_notificationService = domainManager.NotificationService;
		_traffickingMenu = traffickingMenu;
		_playerService = domainManager.PlayerService;
		_worldService = domainManager.WorldService;

	}

	public void Discover()
	{
		try
		{
			if (_dealer is not null)
				return;

			_dealers.ForEach(dealer => dealer.Discovered && dealer.Blip is null, dealer => dealer.Discover(_worldService));

			_dealers.ForEach(dealer => !dealer.Discovered, dealer =>
			{
				Vector3 playerPosition = _playerService.Position;

				if (dealer.Position.DistanceTo(playerPosition) <= DiscoverDistance)
				{
					dealer.Discover(_worldService);

					string zoneFullName = _worldService.GetZoneLocalizedName(dealer.Position);

					_notificationService.Show(
						subject: "Dealer found!",
						message: $"You have found a dealer in the area of {zoneFullName}."
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
				_dealers.ForEach(dealer =>
				{
					if (dealer.Position.DistanceTo(_playerService.Position) <= CreateDistance)
					{
						_dealer = dealer;
						_dealer.Create(_worldService);
						_traffickingMenu.Initialize(dealer);
						return;
					}
				});
			}
			else
			{
				if (_dealer.Position.DistanceTo(_playerService.Position) <= InteractionDistance)
				{
					if (_dealer.Ped is null)
						return;

					if (_showMenu)
						return;

					_dealer.Ped.Task.LookAt(_playerService.Character);					
					_traffickingMenu.Show();
					_showMenu = true;
				}
				else if (_dealer.Position.DistanceTo(_playerService.Position) > InteractionDistance)
				{
					if (_dealer.Ped is null)
						return;

					_dealer.Ped.Task.ClearLookAt();

					if (!_showMenu)
						return;

					_traffickingMenu.Close();
					_showMenu = false;
				}
				else if (_dealer.Position.DistanceTo(_playerService.Position) > CreateDistance)
				{
					_traffickingMenu.Clear();
					_dealer.Delete();
					_dealer = null;
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
