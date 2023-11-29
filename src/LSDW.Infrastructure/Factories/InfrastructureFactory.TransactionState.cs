using LSDW.Domain.Extensions;
using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;
using LSDW.Infrastructure.Models;

namespace LSDW.Infrastructure.Factories;

internal static partial class InfrastructureFactory
{
	/// <summary>
	/// Returns a new transaction state from a transaction instance.
	/// </summary>
	/// <param name="transaction">The transaction instance to use.</param>
	/// <returns>The new transaction state.</returns>
	public static TransactionState CreateTransactionState(ITransaction transaction)
		=> new(transaction.Type, transaction.DrugType, transaction.Quantity, transaction.Value);

	/// <summary>
	/// Returns a new transaction state array from a transaction collection instance.
	/// </summary>
	/// <param name="transactions">The transaction collection instance to use.</param>
	/// <returns>The new transaction state array.</returns>
	public static TransactionState[] CreateTransactionStates(IEnumerable<ITransaction> transactions)
	{
		List<TransactionState> states = [];
		transactions.ForEach(transaction => states.Add(CreateTransactionState(transaction)));
		return [.. states];
	}

	/// <summary>
	/// Returns a new transaction instance from a drug state.
	/// </summary>
	/// <param name="state">The transaction state to use.</param>
	/// <returns>The new transaction instance.</returns>
	public static ITransaction CreateTransaction(TransactionState state)
		=> DomainFactory.CreateTransaction(state.Type, state.DrugType, state.Quantity, state.Value);

	/// <summary>
	/// Returns a new transaction instance collection from a transaction state array.
	/// </summary>
	/// <param name="states">The transaction state array to use.</param>
	/// <returns>The new transaction collection instance.</returns>
	public static IEnumerable<ITransaction> CreateTransactions(TransactionState[] states)
	{
		List<ITransaction> transactions = [];
		states.ForEach(state => transactions.Add(CreateTransaction(state)));
		return transactions;
	}
}
