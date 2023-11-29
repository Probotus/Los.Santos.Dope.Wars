using LSDW.Domain.Interfaces.Models;
using LSDW.Infrastructure.Factories;
using LSDW.Infrastructure.Models;

namespace LSDW.InfrastructureTests.Factories;

public partial class InfrastructureFactoryTests
{
	[TestMethod]
	public void CreateTransactionStateTest()
	{
		ITransaction transaction = GetTransaction();

		TransactionState state =
			InfrastructureFactory.CreateTransactionState(transaction);

		Assert.IsNotNull(state);
		Assert.AreEqual(transaction.Type, state.Type);
		Assert.AreEqual(transaction.DrugType, state.DrugType);
		Assert.AreEqual(transaction.Quantity, state.Quantity);
		Assert.AreEqual(transaction.Value, state.Value);
	}

	[TestMethod]
	public void CreateTransactionStatesTest()
	{
		List<ITransaction> transactions =
			[GetTransaction(), GetTransaction()];

		TransactionState[] states =
			InfrastructureFactory.CreateTransactionStates(transactions);

		Assert.IsNotNull(states);
		Assert.AreEqual(transactions.Count, states.Length);
	}

	[TestMethod]
	public void CreateTransactionTest()
	{
		TransactionState state = GetTransactionState();

		ITransaction transaction =
			InfrastructureFactory.CreateTransaction(state);

		Assert.IsNotNull(state);
		Assert.AreEqual(state.Type, transaction.Type);
		Assert.AreEqual(state.DrugType, transaction.DrugType);
		Assert.AreEqual(state.Quantity, transaction.Quantity);
		Assert.AreEqual(state.Value, transaction.Value);
	}

	[TestMethod]
	public void CreateTransactionsTest()
	{
		TransactionState[] states =
			[GetTransactionState(), GetTransactionState()];

		IEnumerable<ITransaction> transactions =
			InfrastructureFactory.CreateTransactions(states);

		Assert.IsNotNull(transactions);
		Assert.AreEqual(states.Length, transactions.Count());
	}
}
