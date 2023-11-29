using LSDW.Domain.Enumerators;

namespace LSDW.Domain.Interfaces.Models;

/// <summary>
/// The transaction interface.
/// </summary>
public interface ITransaction
{
	/// <summary>
	/// The type of the transaction.
	/// </summary>
	TransactionType Type { get; }

	/// <summary>
	/// The drug type of the transaction.
	/// </summary>
	DrugType DrugType { get; }

	/// <summary>
	/// The quantity of the transaction.
	/// </summary>
	int Quantity { get; }

	/// <summary>
	/// The value of the transaction.
	/// </summary>
	int Value { get; }

	/// <summary>
	/// The total value of the transaction.
	/// </summary>
	/// <remarks>
	/// <b>Which means <see cref="Quantity"/> * <see cref="Value"/>.</b>
	/// </remarks>
	int TotalValue { get; }
}
