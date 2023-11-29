namespace LSDW.Domain.Extensions;

/// <summary>
/// The array extensions class.
/// </summary>
[ExcludeFromCodeCoverage]
public static class ArrayExtensions
{
	private static readonly Random Random = new(Guid.NewGuid().GetHashCode());

	/// <summary>
	/// Returns a randomly choosen item from a given array.
	/// </summary>
	/// <typeparam name="T">Type of objects in the array.</typeparam>
	/// <param name="values">The array of objects to choose from.</param>
	/// <returns>A random item from the array.</returns>
	public static T RandomChoice<T>(this T[] values)
		=> values[Random.Next(0, values.Length)];
}
