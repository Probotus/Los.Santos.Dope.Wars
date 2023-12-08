using LSDW.Domain.Interfaces.Services;

namespace LSDW.DomainTests.Services;

[TestClass]
public class DomainServiceTests : DomainTestBase
{
	[TestMethod]
	public void DomainServiceTest()
	{
		IDomainService service;

		service = GetService<IDomainService>();

		Assert.IsNotNull(service);
		Assert.IsNotNull(service.AudioService);
		Assert.IsNotNull(service.Dealers);
		Assert.IsNotNull(service.GameService);
		Assert.IsNotNull(service.NotificationService);
		Assert.IsNotNull(service.Player);
		Assert.IsNotNull(service.PlayerService);
		Assert.IsNotNull(service.ScreenService);
		Assert.IsNotNull(service.Settings);
		Assert.IsNotNull(service.WorldService);
	}
}
