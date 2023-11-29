using LSDW.Domain.Enumerators;
using LSDW.Domain.Interfaces.Models;

namespace LSDW.DomainTests.Models;

public sealed partial class TransactionCollectionTests
{
	[TestMethod]
	public void FindByDrugType()
	{
		_transactions.Load(_existingTransactions);

		IEnumerable<ITransaction> result =
			_transactions.Find(x => x.DrugType.Equals(DrugType.COKE));

		Assert.IsNotNull(result);
		Assert.IsTrue(result.Any());
		Assert.AreEqual(2, result.Count());
	}

	[TestMethod]
	public void FindByTransactionType()
	{
		_transactions.Load(_existingTransactions);

		IEnumerable<ITransaction> result =
			_transactions.Find(x => x.Type.Equals(TransactionType.BUY));

		Assert.IsNotNull(result);
		Assert.IsTrue(result.Any());
		Assert.AreEqual(2, result.Count());
	}
}
