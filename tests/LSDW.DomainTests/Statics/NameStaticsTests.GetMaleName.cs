using LSDW.Domain.Statics;

namespace LSDW.DomainTests.Statics;

public sealed partial class NameStaticsTests
{
	[TestMethod]
	public void GetMaleNameTest()
	{
		string name = NameStatics.GetMaleName();
		Assert.AreNotEqual(string.Empty, name);
	}
}
