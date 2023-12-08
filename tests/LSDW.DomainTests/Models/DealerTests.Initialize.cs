using GTA;
using GTA.Math;

using LSDW.Domain.Models;

namespace LSDW.DomainTests.Models;

public partial class DealerTests
{
	[TestMethod]
	public void InitializeTest()
	{
		Dealer dealer = new(_settings, _worldServiceMock.Object);

		dealer.Initialize(PedHash.Dealer01SMY, Vector3.Zero, "John Doe");

		Assert.IsTrue(dealer.Initialized);
		Assert.AreEqual("John Doe", dealer.Name);
		Assert.AreEqual(PedHash.Dealer01SMY, dealer.Hash);
		Assert.AreEqual(false, dealer.Discovered);
		Assert.AreEqual(Vector3.Zero, dealer.Position);
		Assert.AreEqual(0, dealer.Money);
	}
}
