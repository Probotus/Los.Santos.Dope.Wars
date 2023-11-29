using LSDW.Domain.Interfaces.Models;
using LSDW.Infrastructure.Factories;
using LSDW.Infrastructure.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LSDW.InfrastructureTests.Factories;

public partial class InfrastructureFactoryTests
{
	[TestMethod]
	public void CreateDrugStateTest()
	{
		IDrug drug = GetDrug();

		DrugState state =
			InfrastructureFactory.CreateDrugState(drug);

		Assert.IsNotNull(state);
		Assert.AreEqual(drug.Type, state.Type);
		Assert.AreEqual(drug.Quantity, state.Quantity);
		Assert.AreEqual(drug.Value, state.Value);
	}

	[TestMethod]
	public void CreateDrugStatesTest()
	{
		List<IDrug> drugs =
			[GetDrug(), GetDrug()];

		DrugState[] states =
			InfrastructureFactory.CreateDrugStates(drugs);

		Assert.IsNotNull(states);
		Assert.AreEqual(drugs.Count, states.Length);
	}

	[TestMethod]
	public void CreateDrugTest()
	{
		DrugState state = GetDrugState();

		IDrug drug =
			InfrastructureFactory.CreateDrug(state);

		Assert.IsNotNull(drug);
		Assert.AreEqual(state.Type, drug.Type);
		Assert.AreEqual(state.Quantity, drug.Quantity);
		Assert.AreEqual(state.Value, drug.Value);
	}

	[TestMethod]
	public void CreateDrugsTest()
	{
		DrugState[] states =
			[GetDrugState(), GetDrugState()];

		IEnumerable<IDrug> drugs =
			InfrastructureFactory.CreateDrugs(states);

		Assert.IsNotNull(drugs);
		Assert.AreEqual(states.Length, drugs.Count());
	}
}
