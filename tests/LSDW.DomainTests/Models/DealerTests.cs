using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Interfaces.Services;

using Moq;

namespace LSDW.DomainTests.Models;

[TestClass]
public partial class DealerTests : DomainTestBase
{
	private readonly ISettings _settings;
	private readonly Mock<IWorldService> _worldServiceMock;

	public DealerTests()
	{
		_settings = GetService<ISettings>();
		_worldServiceMock = new Mock<IWorldService>();
		_worldServiceMock.SetupAllProperties();
	}
}
