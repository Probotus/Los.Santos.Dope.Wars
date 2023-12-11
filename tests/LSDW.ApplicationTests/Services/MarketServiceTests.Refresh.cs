using LSDW.Application.Services;

namespace LSDW.ApplicationTests.Services;

public sealed partial class MarketServiceTests
{
	[TestMethod]
	public void RefreshMarketTest()
	{
		_dealers.Add(MockHelper.GetDealer(false));
		_dealers.Add(MockHelper.GetDealer(true));

		MarketService marketService = new(_domainServiceMock.Object, _infraServiceMock.Object);
		marketService.Refresh();

		Assert.AreNotEqual(0, _dealers.Sum(x => x.Money));
		Assert.AreNotEqual(_dealers.First().Drugs.Sum(x => x.AverageValue), _dealers.First().Drugs.Sum(x => x.Value));
	}
}
