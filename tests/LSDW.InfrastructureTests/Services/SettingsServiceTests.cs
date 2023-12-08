using LSDW.Application.Interfaces.Infrastructure.Services;
using LSDW.Domain.Interfaces.Models;

using Moq;

namespace LSDW.InfrastructureTests.Services;

[TestClass]
public partial class SettingsServiceTests : InfrastructureTestBase
{
	private static readonly string IniFilePath = Path.Combine(AppContext.BaseDirectory, $"{nameof(LSDW)}.ini");
	private readonly Mock<ILoggerService> _loggerServiceMock;
	private readonly ISettings _settings;

	public SettingsServiceTests()
	{
		_loggerServiceMock = new Mock<ILoggerService>();
		_settings = GetService<ISettings>();
	}

	[ClassCleanup]
	public static void ClassCleanup()
	{
		if (File.Exists(IniFilePath))
			File.Delete(IniFilePath);
	}
}
