using LSDW.Application.Interfaces.Application.Missions;
using LSDW.Application.Missions;
using LSDW.Domain.Interfaces.Models;

using Moq;

namespace LSDW.ApplicationTests.Missions;

public sealed partial class StreetTraffickingTests
{
	[TestMethod]
	public void DiscoverDealerIsNullTest()
	{
		IStreetTrafficking streetTrafficking =
			new StreetTrafficking(_domainServiceMock.Object, _infrastructureServiceMock.Object, _traffickingMenuMock.Object);

		streetTrafficking.Discover();
	}

	[TestMethod]
	public void DiscoverDealerExceptionTest()
	{
		Mock<IDealer> dealerMock = new();
		dealerMock.SetupAllProperties();
		dealerMock.Setup(x => x.Discovered).Throws<Exception>();
		_dealers.Add(dealerMock.Object);

		IStreetTrafficking streetTrafficking =
			new StreetTrafficking(_domainServiceMock.Object, _infrastructureServiceMock.Object, _traffickingMenuMock.Object);

		streetTrafficking.Discover();

		_dealers.Remove(dealerMock.Object);
		_loggerServiceMock.Verify(v => v.Critical(It.IsAny<string>(), It.IsAny<Exception>(), It.IsAny<string>()));
	}

	[TestMethod]
	public void DiscoverDealerDiscoveredTest()
	{
		Mock<IDealer> dealerMock = new();
		dealerMock.SetupAllProperties();
		dealerMock.Setup(x => x.Discovered).Returns(true);
		_dealers.Add(dealerMock.Object);

		IStreetTrafficking streetTrafficking =
			new StreetTrafficking(_domainServiceMock.Object, _infrastructureServiceMock.Object, _traffickingMenuMock.Object);

		streetTrafficking.Discover();

		_dealers.Remove(dealerMock.Object);
		dealerMock.Verify(v => v.Discover(), Times.Once());
	}
}
