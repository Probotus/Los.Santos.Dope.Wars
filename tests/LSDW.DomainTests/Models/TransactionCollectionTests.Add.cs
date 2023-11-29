using LSDW.Domain.Enumerators;
using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LSDW.DomainTests.Models;

public sealed partial class TransactionCollectionTests
{
	[TestMethod]
	public void Add()
	{
		ITransactionCollection transactions =
			new TransactionCollection();

		ITransaction transaction =
			DomainFactory.CreateTransaction(TransactionType.FIND, DrugType.SMACK, 15, 90);

		transactions.Add(transaction);

		Assert.AreEqual(1, transactions.Count);
	}
}
