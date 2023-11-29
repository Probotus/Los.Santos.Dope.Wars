using LSDW.Domain.Enumerators;
using LSDW.Domain.Extensions;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Models;

namespace LSDW.DomainTests.Models;

public sealed partial class DrugTests
{
	[TestMethod]
	public void DrugConstructorTypeOnly()
	{
		DrugType drugType = DrugType.COKE;
		IDrug drug;

		drug = new Drug(drugType);

		Assert.IsNotNull(drug);
		Assert.AreEqual(drugType, drug.Type);
		Assert.AreEqual(default, drug.Value);
		Assert.AreEqual(default, drug.Quantity);
		Assert.AreEqual(default, drug.TotalValue);
		Assert.AreEqual(drugType.GetAverageValue(), drug.AverageValue);
		Assert.AreEqual(drugType.GetName(), drug.Name);
		Assert.AreEqual(drugType.GetDescription(), drug.Description);
		Assert.AreEqual(drugType.GetProbability(), drug.Probability);
	}

	[TestMethod]
	public void DrugConstructorComplex()
	{
		IDrug drug;

		drug = new Drug(DrugType.HASH, 45, 15);

		Assert.IsNotNull(drug);
		Assert.AreEqual(15, drug.Value);
		Assert.AreEqual(45, drug.Quantity);
		Assert.AreEqual(675, drug.TotalValue);
	}
}
