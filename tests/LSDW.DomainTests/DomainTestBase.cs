using LSDW.Domain.Installers;

using Microsoft.Extensions.DependencyInjection;

namespace LSDW.DomainTests;

[TestClass]
public abstract class DomainTestBase
{
	private readonly IServiceProvider _serviceProvider;

	public DomainTestBase()
		=> _serviceProvider = CreateServiceProvider();

	public T GetService<T>()
		=> _serviceProvider.GetRequiredService(typeof(T)) is not T service
		? throw new ArgumentException($"{typeof(T)} needs to be a registered service.")
		: service;

	private static ServiceProvider CreateServiceProvider()
	{
		IServiceCollection services = new ServiceCollection();

		services.RegisterDomainServices();

		return services.BuildServiceProvider();
	}
}
