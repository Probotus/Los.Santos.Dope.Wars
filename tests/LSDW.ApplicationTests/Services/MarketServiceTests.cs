using LSDW.Application.Interfaces.Infrastructure.Services;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Interfaces.Services;

using Moq;

namespace LSDW.ApplicationTests.Services;

[TestClass]
public sealed partial class MarketServiceTests : ApplicationTestBase
{
	private readonly IDealerCollection _dealers;
	private readonly IPlayer _player;
	private readonly ISettings _settings;
	private readonly Mock<IWorldService> _worldServiceMock;
	private readonly Mock<IDomainService> _domainServiceMock;
	private readonly Mock<ILoggerService> _loggerServiceMock;
	private readonly Mock<IInfrastructureService> _infraServiceMock;

	public MarketServiceTests()
	{
		_dealers = GetService<IDealerCollection>();
		_player = GetService<IPlayer>();
		_settings = GetService<ISettings>();
		_worldServiceMock = new Mock<IWorldService>();
		_worldServiceMock.SetupAllProperties();
		_domainServiceMock = new Mock<IDomainService>();
		_domainServiceMock.Setup(x => x.Dealers).Returns(_dealers);
		_domainServiceMock.Setup(x => x.Player).Returns(_player);
		_domainServiceMock.Setup(x => x.Settings).Returns(_settings);
		_domainServiceMock.Setup(x => x.WorldService).Returns(_worldServiceMock.Object);
		_loggerServiceMock = new Mock<ILoggerService>();
		_infraServiceMock = new Mock<IInfrastructureService>();
		_infraServiceMock.Setup(x => x.LoggerService).Returns(_loggerServiceMock.Object);
	}
}
