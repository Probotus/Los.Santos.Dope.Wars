using LSDW.Application.Interfaces.Infrastructure.Services;

namespace LSDW.InfrastructureTests.Services;

[TestClass]
public partial class SettingsServiceTests : InfrastructureTestBase
{
	private static readonly string IniFilePath = Path.Combine(AppContext.BaseDirectory, $"{nameof(LSDW)}.ini");
	private readonly ISettingsService _settingsService;

	public SettingsServiceTests()
		=> _settingsService = GetService<ISettingsService>();

	[ClassCleanup]
	public static void ClassCleanup()
	{
		if (File.Exists(IniFilePath))
			File.Delete(IniFilePath);
	}
}
