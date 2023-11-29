using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;

namespace LSDW.DomainTests.Factories;

public partial class DomainFactoryTests
{
	[TestMethod]
	public void GetAllDrugsTest()
	{
		IEnumerable<IDrug> drugs;

		drugs = DomainFactory.GetAllDrugs();

		Assert.IsNotNull(drugs);
	}
}
