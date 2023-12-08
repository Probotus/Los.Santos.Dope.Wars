using System.ComponentModel;

using LSDW.Domain.Interfaces.Models;

using Moq;

namespace LSDW.DomainTests.Models;

public partial class DealerCollectionTests
{
	[TestMethod]
	public void LoadTest()
	{
		Mock<IDealer> dealerMock = new();
		List<IDealer> dealers = [dealerMock.Object];

		_dealers.Load(dealers);

		Assert.AreEqual(1, _dealers.Count);
		Assert.AreEqual(CollectionChangeAction.Refresh, _changing);
		Assert.AreEqual(CollectionChangeAction.Refresh, _changed);
	}
}
