using LSDW.Application.Interfaces.Infrastructure.Services;

namespace LSDW.InfrastructureTests.Services;

[TestClass]
public class InfrastructureServiceTests : InfrastructureTestBase
{
	[TestMethod]
	public void InfrastructureServiceTest()
	{
		IInfrastructureService service;

		service = GetService<IInfrastructureService>();

		Assert.IsNotNull(service);
		Assert.IsNotNull(service.LoggerService);
		Assert.IsNotNull(service.SettingsService);
		Assert.IsNotNull(service.StateService);
	}
}
