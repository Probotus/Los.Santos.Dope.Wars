using System.Reflection;

using LSDW.Domain.Attributes;
using LSDW.Domain.Enumerators;

namespace LSDW.Domain.Caches;

/// <summary>
/// The transaction attribute cache class.
/// </summary>
internal static class TransactionAttributeCache
{
	private static readonly Dictionary<TransactionType, string> Descriptions;
	private static readonly Dictionary<TransactionType, string> Titles;
	private static readonly Dictionary<TransactionType, string> SubTitles;

	/// <summary>
	/// Initializes a instance of the transaction attribute cache class.
	/// </summary>
	static TransactionAttributeCache()
	{
		Descriptions = [];
		Titles = [];
		SubTitles = [];

		Type type = typeof(TransactionType);

		foreach (TransactionType value in Enum.GetValues(type).Cast<TransactionType>())
		{
			string valueName = value.ToString();
			Descriptions.Add(value, type.GetMember(valueName)[0].GetCustomAttribute<TransactionAttribute>().Description);
			Titles.Add(value, type.GetMember(valueName)[0].GetCustomAttribute<TransactionAttribute>().Title);
			SubTitles.Add(value, type.GetMember(valueName)[0].GetCustomAttribute<TransactionAttribute>().SubTitle);
		}
	}

	/// <summary>
	/// Returns the description of the <see cref="TransactionType"/> enumerator from the cache.
	/// </summary>
	/// <param name="value">The transaction type value.</param>
	/// <returns>The transaction description.</returns>
	internal static string GetDescription(TransactionType value)
		=> Descriptions[value];

	/// <summary>
	/// Returns the title of the <see cref="TransactionType"/> enumerator from the cache.
	/// </summary>
	/// <param name="value">The transaction type value.</param>
	/// <returns>The transaction title.</returns>
	internal static string GetTitle(TransactionType value)
		=> Titles[value];

	/// <summary>
	/// Returns the sub title of the <see cref="TransactionType"/> enumerator from the cache.
	/// </summary>
	/// <param name="value">The transaction type value.</param>
	/// <returns>The transaction sub title.</returns>
	internal static string GetSubTitle(TransactionType value)
		=> SubTitles[value];
}
