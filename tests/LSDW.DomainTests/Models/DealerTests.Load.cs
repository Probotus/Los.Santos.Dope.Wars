using LSDW.Domain.Extensions;
using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Models;

namespace LSDW.DomainTests.Models;
public partial class DealerTests
{
	[TestMethod]
	public void LoadTest()
	{
		IEnumerable<IDrug> drugs = DomainFactory.GetAllDrugs();
		drugs.ForEach(drug => drug.SetValues(1, 10));
		Dealer dealer = new(_settings, _worldServiceMock.Object);

		dealer.Load(drugs);

		Assert.AreEqual(15, dealer.Drugs.Count);
		Assert.AreEqual(150, dealer.Drugs.Value);
	}
}
