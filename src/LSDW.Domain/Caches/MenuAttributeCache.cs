using System.Reflection;

using LSDW.Domain.Attributes;

namespace LSDW.Domain.Caches;

/// <summary>
/// The menu attribute cache class.
/// </summary>
/// <typeparam name="T">The type to work with.</typeparam>
internal static class MenuAttributeCache<T> where T : struct, IComparable, IFormattable, IConvertible
{
	private static readonly Dictionary<T, string> Descriptions = [];
	private static readonly Dictionary<T, string> Titles = [];
	private static readonly Dictionary<T, string> SubTitles = [];

	/// <summary>
	/// Initializes a instance of the menu attribute cache class.
	/// </summary>
	static MenuAttributeCache()
	{
		Type type = typeof(T);

		foreach (T value in Enum.GetValues(type).Cast<T>())
		{
			string valueName = value.ToString();
			Descriptions.Add(value, type.GetMember(valueName)[0].GetCustomAttribute<MenuAttribute>().Description);
			Titles.Add(value, type.GetMember(valueName)[0].GetCustomAttribute<MenuAttribute>().Title);
			SubTitles.Add(value, type.GetMember(valueName)[0].GetCustomAttribute<MenuAttribute>().SubTitle);
		}
	}

	/// <summary>
	/// Returns the menu description of the <paramref name="value"/> from the cache.
	/// </summary>
	/// <param name="value">The type value.</param>
	/// <returns>The menu description.</returns>
	internal static string GetDescription(T value)
		=> Descriptions[value];

	/// <summary>
	/// Returns the menu title of the <paramref name="value"/> from the cache.
	/// </summary>
	/// <param name="value">The type value.</param>
	/// <returns>The menu title.</returns>
	internal static string GetTitle(T value)
		=> Titles[value];

	/// <summary>
	/// Returns the menu sub title of the <paramref name="value"/> from the cache.
	/// </summary>
	/// <param name="value">The type value.</param>
	/// <returns>The menu sub title.</returns>
	internal static string GetSubTitle(T value)
		=> SubTitles[value];
}
