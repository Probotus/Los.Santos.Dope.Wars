using LSDW.Domain.Helpers;
using LSDW.Infrastructure.Helpers;

using Microsoft.Extensions.DependencyInjection;

namespace LSDW.InfrastructureTests;

[TestClass]
public abstract class InfrastructureTestBase
{
	private readonly IServiceProvider _serviceProvider;

	public InfrastructureTestBase()
		=> _serviceProvider = CreateServiceProvider();

	public T GetService<T>()
		=> _serviceProvider.GetRequiredService(typeof(T)) is not T service
		? throw new ArgumentException($"{typeof(T)} needs to be a registered service.")
		: service;

	private static ServiceProvider CreateServiceProvider()
	{
		IServiceCollection services = new ServiceCollection();

		services.RegisterDomainServices();
		services.RegisterInfrastructureServices();

		return services.BuildServiceProvider();
	}
}
