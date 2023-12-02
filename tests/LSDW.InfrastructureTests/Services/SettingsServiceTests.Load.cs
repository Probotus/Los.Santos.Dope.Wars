namespace LSDW.InfrastructureTests.Services;

public partial class SettingsServiceTests
{
	[TestMethod]
	public void Load()
		=> _settingsService.Load();
}
