using LSDW.Domain.Attributes;
using LSDW.Domain.Extensions;

namespace LSDW.DomainTests.Attributes;

[TestClass]
public class MenuAttributeTests
{
	[TestMethod]
	public void MenuAttributeTest()
	{
		TestEnum value = TestEnum.None;

		string description = value.GetMenuDescription();
		string title = value.GetMenuTitle();
		string subTitle = value.GetMenuSubTitle();

		Assert.AreEqual("The test description.", description);
		Assert.AreEqual("The test title.", title);
		Assert.AreEqual("The test sub title.", subTitle);
	}

	private enum TestEnum
	{
		[Menu("The test description.", "The test title.", "The test sub title.")]
		None
	}
}
