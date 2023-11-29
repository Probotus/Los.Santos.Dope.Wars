using LSDW.Domain.Enumerators;
using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;

namespace LSDW.DomainTests.Models;

public sealed partial class DrugTests
{
	[TestMethod]
	public void AddSuccess()
	{
		IDrug drug = DomainFactory.CreateDrug(DrugType.MDMA, 5, 100);

		drug.Add(5, 50);

		Assert.AreEqual(10, drug.Quantity);
		Assert.AreEqual(75, drug.Value);
		Assert.AreEqual(750, drug.TotalValue);
	}

	[TestMethod]
	[ExpectedException(typeof(ArgumentOutOfRangeException))]
	public void AddQuantityException()
	{
		IDrug drug = DomainFactory.CreateDrug(DrugType.MDMA, 5, 100);

		drug.Add(0, 10);
	}

	[TestMethod]
	[ExpectedException(typeof(ArgumentOutOfRangeException))]
	public void AddValueException()
	{
		IDrug drug = DomainFactory.CreateDrug(DrugType.MDMA, 5, 100);

		drug.Add(1, -1);
	}
}
