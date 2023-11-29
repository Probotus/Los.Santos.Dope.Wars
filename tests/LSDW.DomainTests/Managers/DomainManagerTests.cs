using LSDW.Domain.Interfaces.Manager;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LSDW.DomainTests.Managers;

[TestClass]
public class DomainManagerTests : DomainTestBase
{
	[TestMethod]
	public void DomainManagerTest()
	{
		IDomainManager manager;

		manager = GetService<IDomainManager>();

		Assert.IsNotNull(manager);
		Assert.IsNotNull(manager.AudioService);
		Assert.IsNotNull(manager.GameService);
		Assert.IsNotNull(manager.NotificationService);
		Assert.IsNotNull(manager.PlayerService);
		Assert.IsNotNull(manager.ScreenService);
		Assert.IsNotNull(manager.WorldService);
	}
}
