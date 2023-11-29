using LSDW.Domain.Enumerators;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LSDW.DomainTests.Models;

public sealed partial class TransactionCollectionTests
{
	[TestMethod]
	public void Remove()
	{
		IEnumerable<ITransaction> existingTransactions =
			new List<ITransaction>() { new Transaction(TransactionType.BUY, DrugType.COKE, 15, 90) };
		_transactions.Load(existingTransactions);
		ITransaction transaction = _transactions.First();

		_transactions.Remove(transaction);

		Assert.AreEqual(0, _transactions.Count);
		Assert.AreEqual(0, _transactions.Value);
	}
}
