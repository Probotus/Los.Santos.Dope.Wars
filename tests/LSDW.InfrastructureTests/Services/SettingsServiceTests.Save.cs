using LSDW.Infrastructure.Services;

using Moq;

namespace LSDW.InfrastructureTests.Services;

public partial class SettingsServiceTests
{
	[TestMethod]
	public void Save()
	{
		SettingsService settingsService = new(_loggerServiceMock.Object, _settings);

		settingsService.Save();

		_loggerServiceMock.Verify(x => x.Information(It.IsAny<string>(), It.IsAny<string>()));
	}
}
