using LSDW.Application.Installers;
using LSDW.Domain.Helpers;

using Microsoft.Extensions.DependencyInjection;

namespace LSDW.ApplicationTests;

[TestClass]
public abstract class ApplicationTestBase
{
	private readonly IServiceProvider _serviceProvider;

	public ApplicationTestBase()
		=> _serviceProvider = CreateServiceProvider();

	public T GetService<T>()
		=> _serviceProvider.GetRequiredService(typeof(T)) is not T service
		? throw new ArgumentException($"{typeof(T)} needs to be a registered service.")
		: service;

	private static ServiceProvider CreateServiceProvider()
	{
		IServiceCollection services = new ServiceCollection();

		services.RegisterApplicationServices();
		services.RegisterDomainServices();

		return services.BuildServiceProvider();
	}
}
