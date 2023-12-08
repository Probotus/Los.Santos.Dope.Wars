using LSDW.Domain.Interfaces.Models.Base;

namespace LSDW.Domain.Interfaces.Models;

/// <summary>
/// The transaction collection interface.
/// </summary>
public interface ITransactionCollection : IEnumerable<ITransaction>, ILoadable<ITransaction>, IFindable<ITransaction>, IRecalculable, INotifyCollectionBase
{
	/// <summary>
	/// The number of transactions in the collection.
	/// </summary>
	int Count { get; }

	/// <summary>
	/// The value of transactions in the collection.
	/// </summary>
	int Value { get; }

	/// <summary>
	/// Adds a transaction to the collection.
	/// </summary>
	/// <param name="transaction">The transaction to add.</param>
	void Add(ITransaction transaction);

	/// <summary>
	/// Removes a transaction from the collection.
	/// </summary>
	/// <param name="transaction">The transaction to remove.</param>
	void Remove(ITransaction transaction);
}
