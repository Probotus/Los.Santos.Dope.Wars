using LSDW.Domain.Enumerators;
using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;

namespace LSDW.DomainTests.Models;

public sealed partial class DrugTests
{
	[TestMethod]
	public void RemoveSuccess()
	{
		IDrug drug = DomainFactory.CreateDrug(DrugType.OXY, 5, 100);

		drug.Remove(5);

		Assert.AreEqual(0, drug.Quantity);
		Assert.AreEqual(100, drug.Value);
		Assert.AreEqual(0, drug.TotalValue);
	}

	[TestMethod]
	[ExpectedException(typeof(ArgumentOutOfRangeException))]
	public void RemoveQuantityException()
	{
		IDrug drug = DomainFactory.CreateDrug(DrugType.CANA, 5, 100);

		drug.Remove(0);
	}

	[TestMethod]
	[ExpectedException(typeof(ArgumentOutOfRangeException))]
	public void RemoveResultingQuantityException()
	{
		IDrug drug = DomainFactory.CreateDrug(DrugType.LSD, 5, 100);

		drug.Remove(6);
	}
}
