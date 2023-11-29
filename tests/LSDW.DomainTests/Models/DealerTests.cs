using GTA.Math;

using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;

namespace LSDW.DomainTests.Models;

[TestClass]
public partial class DealerTests : DomainTestBase
{
	private readonly IDealer _dealer;

	public DealerTests()
		=> _dealer = DomainFactory.CreateDealer(Vector3.Zero, "UnitTest");
}
