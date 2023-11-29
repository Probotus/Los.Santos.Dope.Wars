using LSDW.Domain.Enumerators;
using LSDW.Domain.Extensions;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Models;

namespace LSDW.Domain.Factories;

public static partial class DomainFactory
{
	/// <summary>
	/// Creates a new drug instance.
	/// </summary>
	/// <param name="type">The type of the drug.</param>
	/// <returns>The new drug instance.</returns>
	public static IDrug CreateDrug(DrugType type)
		=> new Drug(type);

	/// <summary>
	/// Creates a new drug instance.
	/// </summary>
	/// <param name="type">The type of the drug.</param>
	/// <param name="quantity">The quantity of the drug.</param>
	/// <returns>The new drug instance.</returns>
	public static IDrug CreateDrug(DrugType type, int quantity)
		=> new Drug(type, quantity);

	/// <summary>
	/// Creates a new drug instance.
	/// </summary>
	/// <param name="type">The type of the drug.</param>
	/// <param name="quantity">The quantity of the drug.</param>
	/// <param name="value">The current value of the drug.</param>
	/// <returns>The new drug instance.</returns>
	public static IDrug CreateDrug(DrugType type, int quantity, int value)
		=> new Drug(type, quantity, value);

	/// <summary>
	/// Retursn a collection of all available drugs.
	/// </summary>
	/// <returns>A collection of all available drugs.</returns>
	public static IEnumerable<IDrug> GetAllDrugs()
	{
		List<IDrug> drugs = new();
		IEnumerable<DrugType> drugTypes = DrugType.COKE.GetValues();
		drugTypes.ForEach(drugType => drugs.Add(new Drug(drugType)));
		return drugs;
	}

	/// <summary>
	/// Returns a new drug collection.
	/// </summary>
	/// <returns>A new drug collection.</returns>
	public static IDrugCollection CreateDrugCollection()
		=> new DrugCollection();
}
