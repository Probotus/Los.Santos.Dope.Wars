using LSDW.Domain.Enumerators;
using LSDW.Domain.Extensions;
using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Models;

namespace LSDW.DomainTests.Models;

public partial class DrugCollectionTests
{
	[TestMethod]
	public void FindTest()
	{
		IEnumerable<IDrug> drugs = DomainFactory.GetAllDrugs();
		drugs.ForEach(d => d.Add(5, 53));
		DrugCollection collection = new();
		collection.Load(drugs);

		IDrug value = collection.Find(DrugType.COKE);

		Assert.IsNotNull(value);
	}

	[TestMethod]
	public void FindManyTest()
	{
		IEnumerable<IDrug> drugs = DomainFactory.GetAllDrugs();
		drugs.ForEach(d => d.Add(3, 13));
		DrugCollection collection = new();
		collection.Load(drugs);

		IEnumerable<IDrug> values =
			collection.FindMany(x => x.AverageValue is >= 10 and <= 50);

		Assert.IsNotNull(values);
		Assert.IsTrue(values.Any());
	}
}
