using LSDW.Domain.Interfaces.Models.Base;

namespace LSDW.Domain.Interfaces.Models;

/// <summary>
/// The dealer collection interface.
/// </summary>
public interface IDealerCollection : IEnumerable<IDealer>, ILoadable<IDealer>, INotifyCollectionBase
{
	/// <summary>
	/// The total number of dealers within the collection.
	/// </summary>
	int Count { get; }

	/// <summary>
	/// Adds a dealer to the collection.
	/// </summary>
	/// <param name="dealer">The dealer to add.</param>
	void Add(IDealer dealer);

	/// <summary>
	/// Removes a dealer from the collection.
	/// </summary>
	/// <param name="dealer">The dealer to remove.</param>
	void Remove(IDealer dealer);
}
