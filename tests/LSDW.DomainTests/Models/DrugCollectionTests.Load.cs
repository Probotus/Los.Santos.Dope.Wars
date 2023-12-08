using LSDW.Domain.Extensions;
using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Models;

namespace LSDW.DomainTests.Models;

public partial class DrugCollectionTests
{
	[TestMethod]
	public void LoadTest()
	{
		IEnumerable<IDrug> drugs = DomainFactory.GetAllDrugs();
		drugs.ForEach(d => d.Add(12, 23));
		DrugCollection collection = [];

		collection.Load(drugs);

		Assert.AreEqual(drugs.Sum(x => x.Quantity), collection.Count);
		Assert.AreEqual(drugs.Sum(x => x.TotalValue), collection.Value);
	}
}
