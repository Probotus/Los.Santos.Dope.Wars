﻿using System.Diagnostics.CodeAnalysis;

namespace LSDW.Domain.Extensions;

/// <summary>
/// The integer extensions class.
/// </summary>
[ExcludeFromCodeCoverage]
public static partial class IntegerExtensions
{
	/// <summary>
	/// Returns an array of integers starting from the <paramref name="minValue"/> to the <paramref name="value"/>.
	/// </summary>
	/// <param name="value">The value to end with.</param>
	/// <param name="minValue">The value to start from.</param>
	/// <returns>An array of integers.</returns>
	public static int[] ArrayDown(this int value, int minValue = 0)
	{
		if (value < minValue)
			throw new ArgumentOutOfRangeException(nameof(minValue), "Minimum value must be smaller than the starting value.");

		int[] array = new int[value + 1];
		for (int i = minValue; i <= value; i++)
			array[i] = i;
		return array;
	}
}
