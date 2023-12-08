using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Interfaces.Services;

using Moq;

namespace LSDW.DomainTests.Factories;

[TestClass]
public partial class DomainFactoryTests : DomainTestBase
{
	private readonly ISettings _settings;
	private readonly Mock<IWorldService> _worldServiceMock;

	public DomainFactoryTests()
	{
		_settings = GetService<ISettings>();
		_worldServiceMock = new Mock<IWorldService>();
		_worldServiceMock.SetupAllProperties();
	}
}
