using LSDW.Domain.Interfaces.Models;

using Moq;

namespace LSDW.DomainTests.Models;

public sealed partial class DealerCollectionTests
{
	[TestMethod]
	public void AddTest()
	{
		Mock<IDealer> dealerMock = new();

		_dealers.Add(dealerMock.Object);

		Assert.AreEqual(1, _dealers.Count);
	}
}
