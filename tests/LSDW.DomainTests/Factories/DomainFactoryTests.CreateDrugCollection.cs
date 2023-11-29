using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;

namespace LSDW.DomainTests.Factories;

public partial class DomainFactoryTests
{
	[TestMethod]
	public void CreateDrugCollectionTest()
	{
		IDrugCollection drugs;

		drugs = DomainFactory.CreateDrugCollection();

		Assert.IsNotNull(drugs);
	}
}
