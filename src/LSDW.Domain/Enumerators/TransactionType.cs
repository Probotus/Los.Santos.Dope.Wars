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
	[Menu("Wanna buy some drugs?", "Buy")]
	BUY,
	/// <summary>
	/// Indicates a "sell" / "selling" / "sold" transaction.
	/// </summary>
	[Menu("Wanna sell some drugs?", "Sell")]
	SELL,
	/// <summary>
	/// Indicates a "take" / "taking" / "taken" transaction.
	/// </summary>
	[Menu("Wanna take some drugs?", "Take")]
	TAKE,
	/// <summary>
	/// Indicates a "give" / "giving" / "given" transaction.
	/// </summary>
	[Menu("Wanna give some drugs?", "Give")]
	GIVE,
	/// <summary>
	/// Indicates a "find" / "finding" / "found" transaction.
	/// </summary>
	[Menu("You have found some drugs!", "Found")]
	FIND,
	/// <summary>
	/// Indicates a "lose" / "loosing" / "lost" transaction.
	/// </summary>
	[Menu("You have lost some drugs!", "Lost")]
	LOSE
}
