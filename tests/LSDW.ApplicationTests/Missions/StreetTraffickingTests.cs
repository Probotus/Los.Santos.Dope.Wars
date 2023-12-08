using LSDW.Application.Interfaces.Infrastructure.Services;
using LSDW.Application.Interfaces.Presentation.Menus;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Interfaces.Services;

using Moq;

namespace LSDW.ApplicationTests.Missions;

[TestClass]
public sealed partial class StreetTraffickingTests : ApplicationTestBase
{
	private readonly IDealerCollection _dealers;
	private readonly ISettings _settings;
	private readonly Mock<IDomainService> _domainServiceMock = new();
	private readonly Mock<ILoggerService> _loggerServiceMock = new();
	private readonly Mock<IStateService> _stateServiceMock = new();
	private readonly Mock<INotificationService> _notificationServiceMock = new();
	private readonly Mock<IPlayerService> _playerServiceMock = new();
	private readonly Mock<IWorldService> _worldServiceMock = new();
	private readonly Mock<ITraffickingMenu> _traffickingMenuMock = new();
	private readonly Mock<IInfrastructureService> _infrastructureServiceMock = new();

	public StreetTraffickingTests()
	{
		_dealers = GetService<IDealerCollection>();
		_settings = GetService<ISettings>();
		_domainServiceMock.Setup(x => x.Dealers).Returns(_dealers);
		_domainServiceMock.Setup(x => x.Settings).Returns(_settings);
		_domainServiceMock.Setup(x => x.NotificationService).Returns(_notificationServiceMock.Object);
		_domainServiceMock.Setup(x => x.PlayerService).Returns(_playerServiceMock.Object);
		_domainServiceMock.Setup(x => x.WorldService).Returns(_worldServiceMock.Object);
		_infrastructureServiceMock.Setup(x => x.LoggerService).Returns(_loggerServiceMock.Object);
		_infrastructureServiceMock.Setup(x => x.StateService).Returns(_stateServiceMock.Object);
	}
}
