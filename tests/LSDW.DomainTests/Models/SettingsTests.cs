using LSDW.Domain.Interfaces.Models;

namespace LSDW.DomainTests.Models;

[TestClass]
public partial class SettingsTests : DomainTestBase
{
	private readonly ISettings _settings;

	public SettingsTests()
		=> _settings = GetService<ISettings>();
}
