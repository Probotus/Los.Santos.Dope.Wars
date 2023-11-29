using System.ComponentModel;

using LSDW.Domain.Attributes;

namespace LSDW.Domain.Enumerators;

/// <summary>
/// The transaction type enumerator.
/// </summary>
public enum TransactionType
{
	/// <summary>
	/// Indicates a "buy" / "buying" / "bought" transaction.
	/// </summary>
	[Transaction("The buy description", "The buy title", "The buy sub title")]
	BUY,
	/// <summary>
	/// Indicates a "sell" / "selling" / "sold" transaction.
	/// </summary>
	[Transaction("", "", "")]
	SELL,
	/// <summary>
	/// Indicates a "take" / "taking" / "taken" transaction.
	/// </summary>
	[Transaction("", "", "")]
	TAKE,
	/// <summary>
	/// Indicates a "give" / "giving" / "given" transaction.
	/// </summary>
	[Transaction("", "", "")]
	GIVE,
	/// <summary>
	/// Indicates a "find" / "finding" / "found" transaction.
	/// </summary>
	[Transaction("", "", "")]
	FIND,
	/// <summary>
	/// Indicates a "lose" / "loosing" / "lost" transaction.
	/// </summary>
	[Transaction("", "", "")]
	LOSE
}
