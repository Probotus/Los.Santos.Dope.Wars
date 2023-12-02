using LSDW.Domain.Interfaces.Models;

namespace LSDW.DomainTests.Models;

[TestClass]
public partial class SettingsTests : DomainTestBase
{
	private readonly ISettings _settings;

	public SettingsTests()
		=> _settings = GetService<ISettings>();

	[TestMethod]
	public void SettingsTest()
	{
		int? changing = default;
		int? changed = default;
		_settings.Player.BagSizePerLevel.Changing += (s, e) => changing = e.Value;
		_settings.Player.BagSizePerLevel.Changed += (s, e) => changed = e.Value;

		_settings.Player.BagSizePerLevel.Value = 1000;

		Assert.IsNotNull(changing);
		Assert.IsNotNull(changed);
	}
}
