using GTA.Math;

using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LSDW.DomainTests.Models;

public sealed partial class DealerCollectionTests
{
	[TestMethod]
	public void RemoveTest()
	{
		_dealers.Add(DomainFactory.CreateDealer(Vector3.Zero, "TestZone"));

		IDealer dealer = _dealers.Where(x => x.Zone == "TestZone").Single();

		_dealers.Remove(dealer);
	}
}
