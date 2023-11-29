using LSDW.Domain.Statics;

using Microsoft.VisualStudio.TestTools.UnitTesting;

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
