using GTA;

using LSDW.Application.Installers;
using LSDW.Application.Interfaces.Application.Missions;
using LSDW.Application.Interfaces.Application.Services;
using LSDW.Application.Interfaces.Infrastructure.Services;
using LSDW.Domain.Installers;
using LSDW.Infrastructure.Installers;
using LSDW.Presentation.Installers;

using Microsoft.Extensions.DependencyInjection;

namespace LSDW;

/// <summary>
/// The main entry point of the modification.
/// </summary>
[ScriptAttributes(Author = "BoBoBaSs84", SupportURL = "https://github.com/BoBoBaSs84")]
public sealed class StartUp : Script
{
	private readonly IServiceProvider _serviceProvider;
	private readonly ISettingsService _settingsService;
	private readonly IMarketService _marketService;
	private readonly IStreetTrafficking _streetTrafficking;

	/// <summary>
	/// Initializes a instance of the start up class.
	/// </summary>
	public StartUp()
	{
		_serviceProvider = CreateServiceProvider();
		_settingsService = GetService<ISettingsService>();
		
		_settingsService.Load();
		_settingsService.Save();
		
		_marketService = GetService<IMarketService>();
		_streetTrafficking = GetService<IStreetTrafficking>();

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
}
