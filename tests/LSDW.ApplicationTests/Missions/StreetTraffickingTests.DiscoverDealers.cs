namespace LSDW.ApplicationTests.Missions;

public sealed partial class StreetTraffickingTests
{
	[TestMethod]
	public void DiscoverDealerIsNotNull()
	{
		_streetTrafficking.Discover();
	}
}
