using LSDW.Domain.Extensions;
using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;
using LSDW.Infrastructure.Models;

namespace LSDW.Infrastructure.Factories;

internal static partial class InfrastructureFactory
{
	/// <summary>
	/// Returns a new drug state from a drug instance.
	/// </summary>
	/// <param name="drug">The drug instance to use.</param>
	/// <returns>The new drug state.</returns>
	public static DrugState CreateDrugState(IDrug drug)
		=> new(drug.Type, drug.Quantity, drug.Value);

	/// <summary>
	/// Returns a new drug state array from a drug collection instance.
	/// </summary>
	/// <param name="drugs">The drug collection instance to use.</param>
	/// <returns>The new drug state array.</returns>
	public static DrugState[] CreateDrugStates(IEnumerable<IDrug> drugs)
	{
		List<DrugState> states = [];
		drugs.ForEach(drug => states.Add(CreateDrugState(drug)));
		return [.. states];
	}

	/// <summary>
	/// Returns a new drug instance from a drug state.
	/// </summary>
	/// <param name="state">The drug state to use.</param>
	/// <returns>The new drug instance.</returns>
	public static IDrug CreateDrug(DrugState state)
		=> DomainFactory.CreateDrug(state.Type, state.Quantity, state.Value);

	/// <summary>
	/// Returns a new drug instance collection from a drug state array.
	/// </summary>
	/// <param name="states">The drug state array to use.</param>
	/// <returns>The new drug collection instance.</returns>
	public static IEnumerable<IDrug> CreateDrugs(DrugState[] states)
	{
		List<IDrug> drugs = [];
		states.ForEach(state => drugs.Add(CreateDrug(state)));
		return drugs;
	}
}
