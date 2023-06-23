﻿using GTA;
using LSDW.Abstractions.Application.Managers;
using LSDW.Abstractions.Domain.Missions;
using LSDW.Abstractions.Domain.Models;
using LSDW.Abstractions.Domain.Providers;
using LSDW.Abstractions.Enumerators;
using LSDW.Abstractions.Infrastructure.Services;
using LSDW.Abstractions.Presentation.Menus;
using LSDW.Domain.Extensions;
using LSDW.Domain.Missions.Base;
using System.Diagnostics.CodeAnalysis;

namespace LSDW.Domain.Missions;

/// <summary>
/// The trafficking class.
/// </summary>
/// <remarks>
/// Inherits from the <see cref="Mission"/> base class and 
/// implements the members of the <see cref="ITrafficking"/> interface.
/// </remarks>
internal sealed class Trafficking : Mission, ITrafficking
{
	private readonly ICollection<IDealer> _dealers;
	private readonly IPlayer _player;
	private readonly IServiceManager _serviceManager;
	private readonly IProviderManager _providerManager;

	private ISideMenu? leftSideMenu;
	private ISideMenu? rightSideMenu;

	/// <summary>
	/// Initializes a instance of the trafficking class.
	/// </summary>
	/// <param name="serviceManager">The service manager instance to use.</param>
	/// <param name="providerManager">The provider manager instance to use.</param>
	internal Trafficking(IServiceManager serviceManager, IProviderManager providerManager) : base(serviceManager.LoggerService, nameof(Trafficking))
	{
		_dealers = serviceManager.StateService.Dealers;
		_player = serviceManager.StateService.Player;
		_serviceManager = serviceManager;
		_providerManager = providerManager;

		LoggerService = serviceManager.LoggerService;
		LocationProvider = providerManager.LocationProvider;
		NotificationProvider = providerManager.NotificationProvider;
		TimeProvider = providerManager.TimeProvider;
	}

	public ILocationProvider LocationProvider { get; }
	public ILoggerService LoggerService { get; }
	public INotificationProvider NotificationProvider { get; }
	public ITimeProvider TimeProvider { get; }

	public override void StopMission()
	{
		leftSideMenu = null;
		rightSideMenu = null;
		_dealers.DeleteDealers();
		base.StopMission();
	}

	public override void OnAborted(object sender, EventArgs args)
		=> StopMission();

	[SuppressMessage("Style", "IDE0058", Justification = "Extension methods.")]
	public override void OnTick(object sender, EventArgs args)
	{
		if (Status is not MissionStatusType.Started)
			return;

		if (!Game.Player.CanControlCharacter && !Game.Player.CanStartMission)
			return;

		try
		{
			this.TrackDealers(_dealers, _player)
				.DiscoverDealers(_dealers)
				.ChangeDealerInventories(_dealers, _player)
				.ChangeDealerPrices(_dealers, _player);
		}
		catch (Exception ex)
		{
			LoggerService.Critical(ex.Message);
		}
	}
}
