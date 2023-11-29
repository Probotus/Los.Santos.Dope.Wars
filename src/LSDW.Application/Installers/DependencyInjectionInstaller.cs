using LSDW.Application.Interfaces.Application.Missions;
using LSDW.Application.Interfaces.Application.Services;
using LSDW.Application.Missions;
using LSDW.Application.Services;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LSDW.Application.Installers;

/// <summary>
/// The dependency injection installer class.
/// </summary>
public static class DependencyInjectionInstaller
{
	/// <summary>
	/// Registers the application services to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
	{
		services.TryAddSingleton<IMarketService, MarketService>();
		services.TryAddSingleton<IStreetTrafficking, StreetTrafficking>();

		return services;
	}
}
