using LSDW.Domain.Interfaces.Models;

namespace LSDW.DomainTests.Models;

[TestClass]
public sealed partial class PlayerTests : DomainTestBase
{
	private readonly ISettings _settings;

	public PlayerTests()
		=> _settings = GetService<ISettings>();
}
