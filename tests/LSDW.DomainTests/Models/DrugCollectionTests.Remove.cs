using LSDW.Domain.Enumerators;
using LSDW.Domain.Extensions;
using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LSDW.DomainTests.Models;

public sealed partial class DrugCollectionTests
{
	[TestMethod]
	public void Remove()
	{
		IEnumerable<IDrug> existingDrugs = DomainFactory.GetAllDrugs();
		existingDrugs.ForEach(drug => drug.Add(10, 10));
		IDrugCollection drugs = new DrugCollection();
		drugs.Load(existingDrugs);

		drugs.Remove(DrugType.COKE, 10);

		Assert.AreEqual(140, drugs.Count);
		Assert.AreEqual(1400, drugs.Value);
	}
}
