using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Interfaces.Services;
using LSDW.Domain.Models;
using LSDW.Domain.Services;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LSDW.Domain.Helpers;

/// <summary>
/// The dependency injection class.
/// </summary>
public static class DependencyInjection
{
	/// <summary>
	/// Registers the domain services to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
	{
		services.TryAddSingleton<IAudioService, AudioService>();
		services.TryAddSingleton<IDealerCollection, DealerCollection>();
		services.TryAddSingleton<IDomainService, DomainService>();
		services.TryAddSingleton<IGameService, GameService>();
		services.TryAddSingleton<INotificationService, NotificationService>();
		services.TryAddSingleton<IPlayer, Player>();
		services.TryAddSingleton<IPlayerService, PlayerService>();
		services.TryAddSingleton<IScreenService, ScreenService>();
		services.TryAddSingleton<ISettings, Settings>();
		services.TryAddSingleton<IWorldService, WorldService>();

		services.TryAddTransient<IDealer, Dealer>();
		services.TryAddTransient<IDrugCollection, DrugCollection>();

		return services;
	}
}
