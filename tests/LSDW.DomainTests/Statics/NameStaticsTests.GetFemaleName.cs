using LSDW.Domain.Statics;

using Microsoft.VisualStudio.TestTools.UnitTesting;

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
