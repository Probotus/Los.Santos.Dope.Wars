using LSDW.Domain.Caches;
using LSDW.Domain.Enumerators;

namespace LSDW.Domain.Extensions;

/// <summary>
/// The drug type extensions class.
/// </summary>
public static class DrugTypeExtensions
{
	/// <summary>
	/// Returns the description of the <see cref="DrugType"/> enumerator.
	/// </summary>
	/// <param name="value">The enumerator value.</param>
	public static string GetDescription(this DrugType value)
		=> DrugAttributeCache.GetDescription(value);

	/// <summary>
	/// Returns the name of the <see cref="DrugType"/> enumerator.
	/// </summary>
	/// <param name="value">The enumerator value.</param>
	public static string GetName(this DrugType value)
		=> DrugAttributeCache.GetName(value);

	/// <summary>
	/// Returns the average value of the <see cref="DrugType"/> enumerator.
	/// </summary>
	/// <param name="value">The enumerator value.</param>
	public static int GetAverageValue(this DrugType value)
		=> DrugAttributeCache.GetAveragePrice(value);

	/// <summary>
	/// Returns the probability property of the <see cref="DrugType"/> enumerator.
	/// </summary>
	/// <param name="value">The enumerator value.</param>
	public static float GetProbability(this DrugType value)
		=> DrugAttributeCache.GetProbability(value);
}
