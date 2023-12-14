using LSDW.Application.Services;

using Moq;

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

	[TestMethod]
	public void OnTickExceptionTest()
	{
		_worldServiceMock.Setup(x => x.Now).Throws<NullReferenceException>();

		MarketService marketService = new(_domainServiceMock.Object, _infraServiceMock.Object);
		marketService.OnTick(this, new());

		_loggerServiceMock.Verify(v => v.Critical(It.IsAny<string>(), It.IsAny<NullReferenceException>(), It.IsAny<string>()));
	}
}
