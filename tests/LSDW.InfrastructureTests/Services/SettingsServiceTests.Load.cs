using LSDW.Infrastructure.Services;

using Moq;

namespace LSDW.InfrastructureTests.Services;

public partial class SettingsServiceTests
{
	[TestMethod]
	public void Load()
	{
		SettingsService settingsService = new(_loggerServiceMock.Object, _settings);

		settingsService.Load();

		_loggerServiceMock.Verify(x => x.Information(It.IsAny<string>(), It.IsAny<string>()));
	}
}
