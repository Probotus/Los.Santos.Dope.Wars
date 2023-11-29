using LSDW.Domain.Enumerators;
using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;

namespace LSDW.DomainTests.Models;

public sealed partial class DrugTests
{
	[TestMethod]
	public void SetValuesTest()
	{
		IDrug drug = DomainFactory.CreateDrug(DrugType.CANA);

		drug.SetValues(10, 100);

		Assert.AreEqual(10, drug.Quantity);
		Assert.AreEqual(100, drug.Value);
		Assert.AreEqual(1000, drug.TotalValue);
	}

	[DataTestMethod]
	[DataRow(-1, 1)]
	[DataRow(1, -1)]
	[ExpectedException(typeof(ArgumentOutOfRangeException))]
	public void SetValuesExceptionTest(int quantity, int value)
	{
		IDrug drug = DomainFactory.CreateDrug(DrugType.CANA);

		drug.SetValues(quantity, value);
	}
}
