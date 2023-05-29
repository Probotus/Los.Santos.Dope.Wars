﻿using LSDW.Core.Classes;
using LSDW.Core.Enumerators;
using LSDW.Core.Extensions;
using LSDW.Core.Helpers;
using LSDW.Core.Interfaces.Classes;

namespace LSDW.Core.Factories;

/// <summary>
/// The drug fcactory class.
/// </summary>
public static class DrugFactory
{
	/// <summary>
	/// Creates a drug instance.
	/// </summary>
	/// <param name="drugType">The type of the drug.</param>
	/// <param name="quantity">The quantity of the drug.</param>
	/// <param name="price">The price of the drug.</param>
	public static IDrug CreateDrug(DrugType drugType, int quantity, int price)
		=> new Drug(drugType, quantity, price);

	/// <summary>
	/// Creates a drug instance.
	/// </summary>
	/// <param name="drugType">The type of the drug.</param>
	/// <param name="quantity">The quantity of the drug.</param>
	public static IDrug CreateDrug(DrugType drugType, int quantity)
		=> new Drug(drugType, quantity, 0);

	/// <summary>
	/// Creates a drug instance.
	/// </summary>
	/// <param name="drugType">The type of the drug.</param>
	public static IDrug CreateDrug(DrugType drugType)
		=> new Drug(drugType, 0, 0);

	/// <summary>
	/// Creates a random drug instance.
	/// </summary>
	/// <remarks>
	/// Only the drug type is randomly choosen.
	/// </remarks>
	public static IDrug CreateDrug()
	{
		List<IDrug> drugList = CreateAllDrugs().ToList();
		return drugList[RandomHelper.GetInt(0, drugList.Count)];
	}

	/// <summary>
	/// Creates a drug collection instance of all available drugs.
	/// </summary>
	public static IEnumerable<IDrug> CreateAllDrugs()
	{
		IEnumerable<DrugType> drugTypes = DrugType.COKE.GetList();
		List<IDrug> drugs = new();
		foreach (DrugType drugType in drugTypes)
			drugs.Add(CreateDrug(drugType));
		return drugs;
	}
}
