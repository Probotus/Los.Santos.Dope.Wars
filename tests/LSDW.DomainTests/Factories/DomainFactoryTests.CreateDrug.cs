using LSDW.Domain.Enumerators;
using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LSDW.DomainTests.Factories;

public partial class DomainFactoryTests
{
	[TestMethod]
	public void CreateOneTest()
	{
		IDrug drug;

		drug = DomainFactory.CreateDrug(DrugType.PCP);

		Assert.IsNotNull(drug);
		Assert.AreEqual(DrugType.PCP, drug.Type);
		Assert.AreEqual(0, drug.Quantity);
		Assert.AreEqual(0, drug.Value);
	}

	[TestMethod]
	public void CreateTwoTest()
	{
		IDrug drug;

		drug = DomainFactory.CreateDrug(DrugType.KETA, 10);

		Assert.IsNotNull(drug);
		Assert.AreEqual(DrugType.KETA, drug.Type);
		Assert.AreEqual(10, drug.Quantity);
		Assert.AreEqual(0, drug.Value);
	}

	[TestMethod]
	public void CreateThreeTest()
	{
		IDrug drug;

		drug = DomainFactory.CreateDrug(DrugType.PEYO, 15, 45);

		Assert.IsNotNull(drug);
		Assert.AreEqual(DrugType.PEYO, drug.Type);
		Assert.AreEqual(15, drug.Quantity);
		Assert.AreEqual(45, drug.Value);
	}
}
