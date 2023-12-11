using LSDW.Application.Services;

namespace LSDW.ApplicationTests.Services;

public sealed partial class MarketServiceTests
{
	[TestMethod]
	public void RestockMarketTest()
	{
		_dealers.Add(MockHelper.GetDealer(true));
		_dealers.Add(MockHelper.GetDealer(false));

		MarketService marketService = new(_domainServiceMock.Object, _infraServiceMock.Object);
		marketService.Restock();

		Assert.AreNotEqual(0, _dealers.Sum(x => x.Money));
		Assert.AreNotEqual(0, _dealers.Sum(x => x.Drugs.Count));
		Assert.AreNotEqual(0, _dealers.Sum(x => x.Drugs.Value));
	}
}
