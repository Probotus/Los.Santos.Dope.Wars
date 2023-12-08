using LSDW.Domain.Interfaces.Models;

namespace LSDW.DomainTests.Models;

public sealed partial class TransactionCollectionTests
{
	[TestMethod]
	public void FindTest()
	{
		List<ITransaction> transactions = GetTransactions();		
		_transactions.Load(transactions);

		ITransaction result = _transactions.Find(x => x.Quantity > 0);

		Assert.IsNotNull(result);
	}

	[TestMethod]
	public void FindManyTest()
	{
		List<ITransaction> transactions = GetTransactions();
		_transactions.Load(transactions);

		IEnumerable<ITransaction> result =
			_transactions.FindMany(x => x.Quantity > 0);

		Assert.IsNotNull(result);
		Assert.IsTrue(result.Any());
	}
}
