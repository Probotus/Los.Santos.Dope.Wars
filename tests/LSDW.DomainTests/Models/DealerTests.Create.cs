using LSDW.Domain.Models;

namespace LSDW.DomainTests.Models;

public sealed partial class DealerTests
{
	[TestMethod]
	[ExpectedException(typeof(InvalidOperationException))]
	public void CreateExceptionTest()
	{
		Dealer dealer = new(_settings, _worldServiceMock.Object);

		dealer.Create();
	}
}
