using LSDW.Domain.Enumerators;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Models;

namespace LSDW.Domain.Factories;

public static partial class DomainFactory
{
	/// <summary>
	/// Creates a new transaction instance.
	/// </summary>
	/// <param name="type">The type of the transaction.</param>
	/// <param name="drugType">The drug type of the transaction.</param>
	/// <param name="quantity">The quantity of the transaction.</param>
	/// <param name="value">The value of the transaction.</param>
	/// <returns>The new transaction instance.</returns>
	public static ITransaction CreateTransaction(TransactionType type, DrugType drugType, int quantity, int value)
		=> new Transaction(type, drugType, quantity, value);
}
