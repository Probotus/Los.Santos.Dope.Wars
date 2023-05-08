﻿using LSDW.Attributes;

namespace LSDW.Enumerators;

/// <summary>
/// The drug type enumerator.
/// </summary>
public enum DrugType
{
	/// <summary>
	/// The cocaine drug type enumerator.
	/// </summary>
	[DrugType("Cocaine", 2000, 3, "Cocaine is a powerful stimulant and narcotic.")]
	COKE = 1,

	/// <summary>
	/// The methamphetamine drug type enumerator.
	/// </summary>
	[DrugType("Methamphetamine", 2250, 3, "Methamphetamine is also known as meth or crystal.")]
	METH = 2
}
