using LSDW.Domain.Enumerators;
using LSDW.Domain.Interfaces.Models;

namespace LSDW.Domain.Models;

/// <summary>
/// The transaction class.
/// </summary>
internal sealed class Transaction : ITransaction
{
	/// <summary>
	/// Initializes a instance of the transaction class.
	/// </summary>
	/// <param name="type">The type of the transaction.</param>
	/// <param name="drugType">The drug type of the transaction.</param>
	/// <param name="quantity">The quantity of the transaction.</param>
	/// <param name="value">The value of the transaction.</param>
	internal Transaction(TransactionType type, DrugType drugType, int quantity, int value)
	{
		if (quantity < 1)
			throw new ArgumentOutOfRangeException(nameof(quantity));

		if (value < 1)
			throw new ArgumentOutOfRangeException(nameof(quantity));

		Type = type;
		DrugType = drugType;
		Quantity = quantity;
		Value = value;
		TotalValue = Quantity * Value;
	}

	public TransactionType Type { get; }
	public DrugType DrugType { get; }
	public int Quantity { get; }
	public int Value { get; }
	public int TotalValue { get; }
}
