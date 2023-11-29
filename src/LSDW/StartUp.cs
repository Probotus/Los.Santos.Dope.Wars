using GTA;

using LSDW.Application.Installers;
using LSDW.Application.Interfaces.Application.Missions;
using LSDW.Application.Interfaces.Application.Services;
using LSDW.Domain.Installers;
using LSDW.Domain.Interfaces.Manager;
using LSDW.Domain.Interfaces.Models;
using LSDW.Infrastructure.Installers;
using LSDW.Presentation.Installers;
using LSDW.Presentation.Menus;

using Microsoft.Extensions.DependencyInjection;

namespace LSDW;

/// <summary>
/// The main entry point of the modification.
/// </summary>
[ScriptAttributes(Author = "BoBoBaSs84", SupportURL = "https://github.com/BoBoBaSs84")]
public sealed class StartUp : Script
{
	private readonly IServiceProvider _serviceProvider;
	private readonly IDomainManager _domainManager;
	private readonly IMarketService _marketService;
	private readonly IStreetTrafficking _streetTrafficking;
	private readonly IPlayer _player;

	private BuyMenu? _buyMenu;

	/// <summary>
	/// Initializes a instance of the start up class.
	/// </summary>
	public StartUp()
	{
		_serviceProvider = CreateServiceProvider();
		_domainManager = GetService<IDomainManager>();
		_marketService = GetService<IMarketService>();
		_streetTrafficking = GetService<IStreetTrafficking>();
		_player = GetService<IPlayer>();

		_streetTrafficking.PropertyChanged += (s, e) => OnStreetTraffickingPropertyChanged(e.PropertyName);

		Aborted += _streetTrafficking.OnAborted;
		Tick += _streetTrafficking.OnTick;
		KeyUp += _streetTrafficking.OnKeyUp;

		Tick += _marketService.OnTick;
	}

	/// <summary>
	/// Returns the requested service.
	/// </summary>
	/// <typeparam name="T">The requested service.</typeparam>
	/// <returns>The registered service.</returns>
	/// <exception cref="ArgumentException">If a service is not registered.</exception>
	public T GetService<T>()
		=> _serviceProvider.GetRequiredService(typeof(T)) is not T service
		? throw new ArgumentException($"{typeof(T)} needs to be a registered service.")
		: service;

	private static ServiceProvider CreateServiceProvider()
	{
		IServiceCollection services = new ServiceCollection();

		services.RegisterApplicationServices();
		services.RegisterDomainServices();
		services.RegisterInfrastructureServices();
		services.RegisterPresentationServices();

		return services.BuildServiceProvider();
	}

	private void OnStreetTraffickingPropertyChanged(string propertyName)
	{
		if (propertyName == nameof(_streetTrafficking.Dealer))
		{
			_buyMenu = new(_player, _streetTrafficking.Dealer!, _domainManager);
			_buyMenu.Initialize();
		}

		if (propertyName == nameof(_streetTrafficking.ShowMenu) && _buyMenu is not null)
		{
			_buyMenu.Visible = _streetTrafficking.ShowMenu;
		}
	}
}
