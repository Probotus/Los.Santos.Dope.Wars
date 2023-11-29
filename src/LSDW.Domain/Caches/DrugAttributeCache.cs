using System.Reflection;

using LSDW.Domain.Attributes;
using LSDW.Domain.Enumerators;

namespace LSDW.Domain.Caches;

/// <summary>
/// The drug attribute cache class.
/// </summary>
internal static class DrugAttributeCache
{
	private static readonly Dictionary<DrugType, int> AverageValues;
	private static readonly Dictionary<DrugType, string> Descriptions;
	private static readonly Dictionary<DrugType, float> Probabilities;
	private static readonly Dictionary<DrugType, string> Names;

	/// <summary>
	/// Initializes a instance of the drug attribute cache class.
	/// </summary>
	static DrugAttributeCache()
	{
		AverageValues = [];
		Descriptions = [];
		Probabilities = [];
		Names = [];

		Type type = typeof(DrugType);

		foreach (DrugType value in Enum.GetValues(type).Cast<DrugType>())
		{
			string valueName = value.ToString();
			AverageValues.Add(value, type.GetMember(valueName)[0].GetCustomAttribute<DrugAttribute>().AverageValue);
			Descriptions.Add(value, type.GetMember(valueName)[0].GetCustomAttribute<DrugAttribute>().Description);
			Probabilities.Add(value, type.GetMember(valueName)[0].GetCustomAttribute<DrugAttribute>().Probability);
			Names.Add(value, type.GetMember(valueName)[0].GetCustomAttribute<DrugAttribute>().Name);
		}
	}

	/// <summary>
	/// Returns the average drug value of the <see cref="DrugType"/> enumerator from the cache.
	/// </summary>
	/// <param name="value">The drug type value.</param>
	/// <returns>The average price.</returns>
	internal static int GetAveragePrice(DrugType value)
		=> AverageValues[value];

	/// <summary>
	/// Returns the drug description of the <see cref="DrugType"/> enumerator from the cache.
	/// </summary>
	/// <param name="value">The drug type value.</param>
	/// <returns>The drug description.</returns>
	internal static string GetDescription(DrugType value)
		=> Descriptions[value];

	/// <summary>
	/// Returns the drug probability of the <see cref="DrugType"/> enumerator from the cache.
	/// </summary>
	/// <param name="value">The drug type value.</param>
	/// <returns>The drug probability.</returns>
	internal static float GetProbability(DrugType value)
		=> Probabilities[value];

	/// <summary>
	/// Returns the drug name of the <see cref="DrugType"/> enumerator from the cache.
	/// </summary>
	/// <param name="value">The drug type value.</param>
	/// <returns>The drug name.</returns>
	internal static string GetName(DrugType value)
		=> Names[value];
}
