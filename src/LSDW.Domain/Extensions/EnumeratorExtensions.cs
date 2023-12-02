using LSDW.Domain.Caches;

namespace LSDW.Domain.Extensions;

/// <summary>
/// The enumerator extensions class.
/// </summary>
public static class EnumeratorExtensions
{
	/// <summary>
	/// Returns the menu description of the enumerator from the <see cref="MenuAttributeCache{T}"/>.
	/// </summary>
	/// <param name="value">The enumerator value.</param>
	/// <returns>The menu description of the enumerator.</returns>
	public static string GetMenuDescription<T>(this T value) where T : struct, IComparable, IFormattable, IConvertible
		=> MenuAttributeCache<T>.GetDescription(value);

	/// <summary>
	/// Returns the menu title of the enumerator from the <see cref="MenuAttributeCache{T}"/>.
	/// </summary>
	/// <param name="value">The enumerator value.</param>
	/// <returns>The menu title of the enumerator.</returns>
	public static string GetMenuTitle<T>(this T value) where T : struct, IComparable, IFormattable, IConvertible
			=> MenuAttributeCache<T>.GetTitle(value);

	/// <summary>
	/// Returns the menu sub title of the enumerator from the <see cref="MenuAttributeCache{T}"/>.
	/// </summary>
	/// <param name="value">The enumerator value.</param>
	/// <returns>The menu sub title of the enumerator.</returns>
	public static string GetMenuSubTitle<T>(this T value) where T : struct, IComparable, IFormattable, IConvertible
			=> MenuAttributeCache<T>.GetSubTitle(value);

	/// <summary>
	/// Returns an <see cref="IEnumerable{T}"/> of all enumerators of the given type of enum.
	/// </summary>
	/// <typeparam name="T">The type of the enumerator.</typeparam>
	/// <param name="value">The value of the enumerator.</param>
	/// <returns>An <see cref="IEnumerable{T}"/> of all enumerators of the provided type.</returns>
	public static IEnumerable<T> GetValues<T>(this T value) where T : struct, IComparable, IFormattable, IConvertible
		=> Enum.GetValues(value.GetType()).Cast<T>().ToArray();
}
