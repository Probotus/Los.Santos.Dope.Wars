using System.ComponentModel;

using LSDW.Domain.Interfaces.Models;

using Moq;

namespace LSDW.DomainTests.Models;

public sealed partial class TransactionCollectionTests
{
	[TestMethod]
	public void Add()
	{
		Mock<ITransaction> mock = new();

		_transactions.Add(mock.Object);

		Assert.IsTrue(_transactions.Contains(mock.Object));
		Assert.AreEqual(CollectionChangeAction.Add, _changing);
		Assert.AreEqual(CollectionChangeAction.Add, _changed);
	}
}
