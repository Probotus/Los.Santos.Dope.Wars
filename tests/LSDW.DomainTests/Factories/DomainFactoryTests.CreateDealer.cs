using GTA;
using GTA.Math;

using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;

namespace LSDW.DomainTests.Factories;

public partial class DomainFactoryTests
{
	[TestMethod]
	public void CreateDealerTest()
	{
		IDealer dealer;

		dealer = DomainFactory.CreateDealer(_settings, _worldServiceMock.Object, Vector3.Zero);

		Assert.IsNotNull(dealer);
		Assert.AreEqual(Vector3.Zero, dealer.Position);
		Assert.AreNotEqual(PedHash.Abigail, dealer.Hash);
		Assert.AreEqual(string.Empty, dealer.Name);
		Assert.AreEqual(true, dealer.Initialized);
	}

	[TestMethod]
	public void CreateSavedDealerTest()
	{
		IDealer dealer;

		dealer = DomainFactory.CreateDealer(_settings, _worldServiceMock.Object, PedHash.Dealer01SMY, Vector3.Zero, "John Doe", true, 250, new List<IDrug>());

		Assert.IsNotNull(dealer);
		Assert.AreEqual(PedHash.Dealer01SMY, dealer.Hash);
		Assert.AreEqual(Vector3.Zero, dealer.Position);		
		Assert.AreEqual("John Doe", dealer.Name);
		Assert.AreEqual(true, dealer.Discovered);
		Assert.AreEqual(250, dealer.Money);
		Assert.AreEqual(true, dealer.Initialized);
	}
}
