using LSDW.Domain.Enumerators;
using LSDW.Domain.Interfaces.Models.Base;

namespace LSDW.Domain.Interfaces.Models;

/// <summary>
/// The drug collection interface.
/// </summary>
public interface IDrugCollection : IEnumerable<IDrug>, ILoadable<IDrug>, IFindable<IDrug>, INotifyPropertyBase, IRecalculable
{
	/// <summary>
	/// The total number of drugs within the collection.
	/// </summary>
	int Count { get; }

	/// <summary>
	/// The total value of the drugs within the collection.
	/// </summary>
	int Value { get; }

	/// <summary>
	/// Adds the the given <paramref name="quantity"/> and <paramref name="value"/> to the
	/// provided <paramref name="drugType"/>.
	/// </summary>
	/// <param name="drugType">The drug type to work on.</param>
	/// <param name="quantity">The quantity to add.</param>
	/// <param name="value">The value to add.</param>
	void Add(DrugType drugType, int quantity, int value);

	/// <summary>
	/// Returns the drug collection item by its type.
	/// </summary>
	/// <param name="drugType">The drug type to fetch.</param>
	/// <returns>The fetched drug collection item.</returns>
	IDrug Find(DrugType drugType);

	/// <summary>
	/// Removes the given <paramref name="quantity"/> from the provided <paramref name="drugType"/>.
	/// </summary>
	/// <param name="drugType">The drug type to work on.</param>
	/// <param name="quantity">The quantity to remove.</param>
	void Remove(DrugType drugType, int quantity);
}
