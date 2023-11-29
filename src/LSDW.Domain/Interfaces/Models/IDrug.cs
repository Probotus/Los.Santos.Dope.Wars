using LSDW.Domain.Enumerators;
using LSDW.Domain.Interfaces.Models.Base;

namespace LSDW.Domain.Interfaces.Models;

/// <summary>
/// The drug interface.
/// </summary>
public interface IDrug : INotifyPropertyBase
{
	/// <summary>
	/// The type of the drug.
	/// </summary>
	DrugType Type { get; }

	/// <summary>
	/// The name of the drug.
	/// </summary>
	string Name { get; }

	/// <summary>
	/// The description of the drug.
	/// </summary>
	string Description { get; }

	/// <summary>
	/// The quantity of the drug.
	/// </summary>
	int Quantity { get; }

	/// <summary>
	/// The current value of the drug.
	/// </summary>
	/// <remarks>
	/// <b>For a single <see cref="Quantity"/></b>
	/// </remarks>
	int Value { get; }

	/// <summary>
	/// The average value of the drug.
	/// </summary>
	int AverageValue { get; }

	/// <summary>
	/// The total value of the drug.
	/// </summary>
	/// <remarks>
	/// <b><see cref="Quantity"/> * <see cref="Value"/></b>
	/// </remarks>
	int TotalValue { get; }

	/// <summary>
	/// The availability probability property of a drug.
	/// </summary>
	float Probability { get; }

	/// <summary>
	/// Adds the quantity and value to the drug.
	/// </summary>
	/// <param name="quantity">The quantity of the drug to add.</param>
	/// <param name="value">The value of the drug to add.</param>
	void Add(int quantity, int value);

	/// <summary>
	/// Sets the quantity and value to the drug.
	/// </summary>
	/// <param name="quantity">The quantity of the drug to set.</param>
	/// <param name="value">The value of the drug to set.</param>
	void SetValues(int quantity, int value);

	/// <summary>
	/// Removes the quantity from the drug.
	/// </summary>
	/// <param name="quantity">The quantity of the drug to remove.</param>
	void Remove(int quantity);
}
