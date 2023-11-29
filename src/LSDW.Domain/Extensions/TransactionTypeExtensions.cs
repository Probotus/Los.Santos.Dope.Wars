using LSDW.Domain.Caches;
using LSDW.Domain.Enumerators;

namespace LSDW.Domain.Extensions;

/// <summary>
/// The transaction type extensions class.
/// </summary>
public static class TransactionTypeExtensions
{
	/// <summary>
	/// Returns the description of the <see cref="TransactionType"/> enumerator.
	/// </summary>
	/// <param name="value">The enumerator value.</param>
	/// <returns>The description of the enumerator.</returns>
	public static string GetDescription(this TransactionType value)
		=> TransactionAttributeCache.GetDescription(value);

	/// <summary>
	/// Returns the title of the <see cref="TransactionType"/> enumerator.
	/// </summary>
	/// <param name="value">The enumerator value.</param>
	/// <returns>The title of the enumerator.</returns>
	public static string GetTitle(this TransactionType value)
		=> TransactionAttributeCache.GetDescription(value);

	/// <summary>
	/// Returns the sub title of the <see cref="TransactionType"/> enumerator.
	/// </summary>
	/// <param name="value">The enumerator value.</param>
	/// <returns>The sub title of the enumerator.</returns>
	public static string GetSubTitle(this TransactionType value)
		=> TransactionAttributeCache.GetDescription(value);
}
