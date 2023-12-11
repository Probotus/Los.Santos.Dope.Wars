using LSDW.Application.Services;

namespace LSDW.ApplicationTests.Services;

public sealed partial class MarketServiceTests
{
	[TestMethod]
	public void OnTickTest()
	{
		DateTime now = new(2000, 1, 1);
		_worldServiceMock.Object.Now = now;

		MarketService marketService = new(_domainServiceMock.Object, _infraServiceMock.Object);
		marketService.OnTick(this, new());

		Assert.AreNotEqual(now, marketService.NextRefresh);
		Assert.AreNotEqual(now, marketService.NextRestock);
	}
}
