using LSDW.Domain.Interfaces.Models;

using Moq;

namespace LSDW.DomainTests.Models;

public sealed partial class DealerCollectionTests
{
	[TestMethod]
	public void RemoveTest()
	{
		Mock<IDealer> dealerMock = new();
		dealerMock.Setup(x => x.Zone).Returns("TestZone");

		_dealers.Add(dealerMock.Object);

		IDealer dealer = _dealers.Where(x => x.Zone == "TestZone").Single();

		_dealers.Remove(dealer);
	}
}
