using LSDW.Domain.Interfaces.Manager;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Managers;
using LSDW.Domain.Models;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LSDW.Domain.Installers;

/// <summary>
/// The dependency injection installer class.
/// </summary>
public static class DependencyInjectionInstaller
{
	/// <summary>
	/// Registers the domain services to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
	{
		services.TryAddSingleton<ISettings, Settings>();
		services.TryAddSingleton<IPlayer, Player>();
		services.TryAddSingleton<IDealerCollection, DealerCollection>();
		services.TryAddSingleton<IDomainManager, DomainManager>();
		services.TryAddSingleton<ITransactionCollection, TransactionCollection>();
		services.TryAddTransient<IDrugCollection, DrugCollection>();

		return services;
	}
}
