﻿using LSDW.Domain.Extensions;
using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;

namespace LSDW.DomainTests.Models;
public partial class DealerTests
{
	[TestMethod]
	public void LoadTest()
	{
		IEnumerable<IDrug> drugs = DomainFactory.GetAllDrugs();
		drugs.ForEach(drug => drug.SetValues(1, 10));

		_dealer.Load(drugs);

		Assert.AreEqual(15, _dealer.Drugs.Count);
		Assert.AreEqual(150, _dealer.Drugs.Value);
	}
}