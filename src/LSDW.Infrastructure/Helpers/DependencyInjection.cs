using LSDW.Application.Interfaces.Infrastructure.Services;
using LSDW.Infrastructure.Services;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LSDW.Infrastructure.Helpers;

/// <summary>
/// The dependency injection class.
/// </summary>
public static class DependencyInjection
{
	/// <summary>
	/// Registers the infrastructure services to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
	{
		services.TryAddSingleton<ILoggerService, LoggerService>();
		services.TryAddSingleton<ISettingsService, SettingsService>();
		services.TryAddSingleton<IStateService, StateService>();
		services.TryAddSingleton<IInfrastructureService, InfrastructureService>();

		return services;
	}
}
