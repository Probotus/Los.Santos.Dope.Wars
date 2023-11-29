using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LSDW.ApplicationTests.Services;

public sealed partial class MarketServiceTests
{
	[TestMethod]
	public void OnTickTest()
	{
		DateTime now = new(2000, 1, 1);
		_domainManager.WorldService.Now = now;

		_marketService.OnTick(this, new());

		Assert.AreNotEqual(now, _marketService.NextRefresh);
		Assert.AreNotEqual(now, _marketService.NextRestock);
	}
}
