using LSDW.Application.Interfaces.Application.Missions;
using LSDW.Application.Missions;

namespace LSDW.ApplicationTests.Missions;

public sealed partial class StreetTraffickingTests
{
	[TestMethod]
	public void DiscoverDealerIsNotNull()
	{
		IStreetTrafficking streetTrafficking =
			new StreetTrafficking(_domainServiceMock.Object, _infrastructureServiceMock.Object, _traffickingMenuMock.Object);

		streetTrafficking.Discover();
	}
}
