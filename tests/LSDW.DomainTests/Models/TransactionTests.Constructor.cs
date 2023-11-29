using LSDW.Domain.Enumerators;
using LSDW.Domain.Extensions;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Models;

namespace LSDW.DomainTests.Models;

public sealed partial class TransactionTests
{
	[TestMethod]
	public void WithValues()
	{
		ITransaction transaction;
		TransactionType transactionType = TransactionType.FIND;
		DrugType drugType = DrugType.METH;
		int quantity = 45;

		transaction = new Transaction(transactionType, drugType, quantity, drugType.GetAverageValue());

		Assert.IsNotNull(transaction);
		Assert.AreEqual(transactionType, transaction.Type);
		Assert.AreEqual(drugType, transaction.DrugType);
		Assert.AreEqual(quantity, transaction.Quantity);
		Assert.AreEqual(drugType.GetAverageValue(), transaction.Value);
		Assert.AreEqual(drugType.GetAverageValue() * transaction.Quantity, transaction.TotalValue);
	}

	[TestMethod]
	[ExpectedException(typeof(ArgumentOutOfRangeException))]
	public void QuantityException()
	{
		_ = new Transaction(TransactionType.SELL, DrugType.KETA, 0, 0);
	}

	[TestMethod]
	[ExpectedException(typeof(ArgumentOutOfRangeException))]
	public void ValueException()
	{
		_ = new Transaction(TransactionType.SELL, DrugType.KETA, 1, 0);
	}
}
