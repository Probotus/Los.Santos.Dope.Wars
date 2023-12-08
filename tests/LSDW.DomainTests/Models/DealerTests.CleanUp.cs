using LSDW.Domain.Models;

namespace LSDW.DomainTests.Models;

public partial class DealerTests
{
	[TestMethod]
	public void CleaUpTest()
	{
		Dealer dealer = new(_settings, _worldServiceMock.Object);
		dealer.Initialize(GTA.PedHash.Dealer01SMY, GTA.Math.Vector3.Zero);

		dealer.CleanUp();

		Assert.IsNull(dealer.Blip);
		Assert.IsNull(dealer.Ped);
	}
}
