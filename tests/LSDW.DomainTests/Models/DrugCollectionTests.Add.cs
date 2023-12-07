﻿using LSDW.Domain.Enumerators;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Models;

namespace LSDW.DomainTests.Models;

public sealed partial class DrugCollectionTests
{
	[TestMethod]
	public void Add()
	{
		IDrugCollection drugs = GetService<IDrugCollection>();
		IDrug drug = new Drug(DrugType.COKE, 13, 87);

		drugs.Add(drug.Type, drug.Quantity, drug.Value);

		Assert.AreEqual(13, drugs.Count);
		Assert.AreEqual(1131, drugs.Value);
	}
}