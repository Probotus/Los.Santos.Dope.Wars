using LSDW.Domain.Helpers;

using Microsoft.Extensions.DependencyInjection;

namespace LSDW.DomainTests;

[TestClass]
public abstract class DomainTestBase
{
	private static IServiceProvider? s_serviceProvider;

	[AssemblyInitialize]
	public static void AssemblyInitialize(TestContext context)
		=> s_serviceProvider = CreateServiceProvider();

	protected static T GetService<T>()
		=> s_serviceProvider?.GetRequiredService(typeof(T)) is not T service
		? throw new ArgumentException($"{typeof(T)} needs to be a registered service.")
		: service;

	private static ServiceProvider CreateServiceProvider()
	{
		IServiceCollection services = new ServiceCollection()
			.RegisterDomainServices();

		return services.BuildServiceProvider();
	}
}
