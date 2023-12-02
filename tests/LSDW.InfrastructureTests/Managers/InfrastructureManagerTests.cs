using LSDW.Application.Interfaces.Infrastructure.Managers;
using LSDW.InfrastructureTests;

namespace LSDW.InfrastructureTests.Managers;

[TestClass]
public class InfrastructureManagerTests : InfrastructureTestBase
{
	[TestMethod]
	public void InfrastructureManagerTest()
	{
		IInfrastructureManager manager;

		manager = GetService<IInfrastructureManager>();

		Assert.IsNotNull(manager);
		Assert.IsNotNull(manager.LoggerService);
		Assert.IsNotNull(manager.SettingsService);
		Assert.IsNotNull(manager.StateService);
	}
}
