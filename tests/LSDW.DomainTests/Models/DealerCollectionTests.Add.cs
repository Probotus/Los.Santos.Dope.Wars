using System.ComponentModel;

using LSDW.Domain.Interfaces.Models;

using Moq;

namespace LSDW.DomainTests.Models;

public sealed partial class DealerCollectionTests
{
	[TestMethod]
	public void AddTest()
	{
		Mock<IDealer> dealerMock = new();
		IDealer dealer = dealerMock.Object;

		_dealers.Add(dealer);

		Assert.IsTrue(_dealers.Contains(dealer));
		Assert.AreEqual(CollectionChangeAction.Add, _changing);
		Assert.AreEqual(CollectionChangeAction.Add, _changed);
	}
}
