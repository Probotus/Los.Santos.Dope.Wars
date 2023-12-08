using LSDW.Domain.Enumerators;
using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;

namespace LSDW.DomainTests.Models;

public sealed partial class TransactionCollectionTests
{
	[TestMethod]
	public void Add()
	{
		ITransaction transaction =
			DomainFactory.CreateTransaction(TransactionType.FIND, DrugType.SMACK, 15, 90);

		_transactions.Add(transaction);

		Assert.AreEqual(1, _transactions.Count);
	}
}
