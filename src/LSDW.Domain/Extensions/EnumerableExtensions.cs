﻿namespace LSDW.Domain.Extensions;

/// <summary>
/// The enumerable extensions class.
/// </summary>
[ExcludeFromCodeCoverage]
public static class EnumerableExtensions
{
	/// <summary>
	/// Iterates over an enumerable and executes an Action on each element.
	/// </summary>
	/// <typeparam name="T">The type of the elements of source.</typeparam>
	/// <param name="items">A sequence of values to invoke an action on.</param>
	/// <param name="action">An Action to invoke on each source element.</param>
	public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
	{
		foreach (T item in items)
			action(item);
	}

	/// <summary>
	/// Iterates over an enumerable and executes an Action on each element.
	/// </summary>
	/// <typeparam name="T">The type of the elements of source.</typeparam>
	/// <param name="items">A sequence of values to invoke an action on.</param>
	/// <param name="predicate">The function to test each element for a condition.</param>
	/// <param name="action">An Action to invoke on each source element.</param>
	public static void ForEach<T>(this IEnumerable<T> items, Func<T, bool> predicate, Action<T> action)
	{
		foreach (T item in items.Where(predicate))
			action(item);
	}
}