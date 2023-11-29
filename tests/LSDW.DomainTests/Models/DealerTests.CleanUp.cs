namespace LSDW.DomainTests.Models;

public partial class DealerTests
{
	[TestMethod]
	public void CleaUpTest()
	{
		_dealer.CleanUp();

		Assert.IsNull(_dealer.Blip);
		Assert.IsNull(_dealer.Ped);
	}
}
