using System.ComponentModel;

using LSDW.Domain.Interfaces.Models;

using Moq;

namespace LSDW.DomainTests.Models;

public sealed partial class TransactionCollectionTests
{
	[TestMethod]
	public void Remove()
	{
		Mock<ITransaction> mock = new();
		mock.Setup(x => x.Quantity).Returns(1000);
		_transactions.Add(mock.Object);

		ITransaction transaction = _transactions.First(x => x.Quantity == 1000);

		_transactions.Remove(transaction);

		Assert.IsFalse(_transactions.Contains(transaction));
		Assert.AreEqual(CollectionChangeAction.Remove, _changing);
		Assert.AreEqual(CollectionChangeAction.Remove, _changed);
	}
}
