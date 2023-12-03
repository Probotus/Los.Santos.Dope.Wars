using LSDW.Application.Interfaces.Presentation.Menus;
using LSDW.Presentation.Menus;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LSDW.Presentation.Installers;

/// <summary>
/// The dependency injection installer class.
/// </summary>
public static class DependencyInjectionInstaller
{
	/// <summary>
	/// Registers the presentation services to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	public static IServiceCollection RegisterPresentationServices(this IServiceCollection services)
	{
		services.TryAddTransient<IBuyMenu, BuyMenu>();
		services.TryAddTransient<ISellMenu, SellMenu>();
		services.TryAddTransient<ITraffickingMenu, TraffickingMenu>();

		return services;
	}
}
