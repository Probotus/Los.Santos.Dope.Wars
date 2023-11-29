using GTA.Math;

using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LSDW.DomainTests.Models;

public sealed partial class DealerCollectionTests
{
	[TestMethod]
	public void AddTest()
	{
		IDealer dealer = DomainFactory.CreateDealer(Vector3.Zero, "UnitTest");

		_dealers.Add(dealer);

		Assert.AreEqual(1, _dealers.Count);
	}
}
