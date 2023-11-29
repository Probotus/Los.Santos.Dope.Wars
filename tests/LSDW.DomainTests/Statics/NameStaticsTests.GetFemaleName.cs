using LSDW.Domain.Statics;

namespace LSDW.DomainTests.Statics;

public sealed partial class NameStaticsTests
{
	[TestMethod]
	public void GetFemaleNameTest()
	{
		string name = NameStatics.GetFemaleName();
		Assert.AreNotEqual(string.Empty, name);
	}
}
