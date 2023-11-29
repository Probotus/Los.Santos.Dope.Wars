using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

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
