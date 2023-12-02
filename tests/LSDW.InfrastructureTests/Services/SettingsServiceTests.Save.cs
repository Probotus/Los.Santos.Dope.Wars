namespace LSDW.InfrastructureTests.Services;

public partial class SettingsServiceTests
{
	[TestMethod]
	public void Save()
		=> _settingsService.Save();
}
