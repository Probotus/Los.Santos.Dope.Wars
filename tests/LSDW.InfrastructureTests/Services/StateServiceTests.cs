using LSDW.Application.Interfaces.Infrastructure.Services;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Interfaces.Services;

using Moq;

namespace LSDW.InfrastructureTests.Services;

[TestClass]
public partial class StateServiceTests : InfrastructureTestBase
{
	private static readonly string SaveFilePath = Path.Combine(AppContext.BaseDirectory, $"{nameof(LSDW)}.sav");
	private readonly Mock<IDomainService> _domainServiceMock;
	private readonly Mock<ILoggerService> _loggerServiceMock;
	private IStateService? _stateService;

	public StateServiceTests()
	{
		IDealerCollection dealers = GetService<IDealerCollection>();
		IPlayer player = GetService<IPlayer>();
		ISettings settings = GetService<ISettings>();
		Mock<IWorldService> worldServiceMock = new();
		worldServiceMock.SetupAllProperties();

		_loggerServiceMock = new Mock<ILoggerService>();
		_domainServiceMock = new Mock<IDomainService>();

		_domainServiceMock.Setup(x => x.Dealers).Returns(dealers);
		_domainServiceMock.Setup(x => x.Player).Returns(player);
		_domainServiceMock.Setup(x => x.Settings).Returns(settings);
		_domainServiceMock.Setup(x => x.WorldService).Returns(worldServiceMock.Object);
	}

	[ClassCleanup]
	public static void ClassCleanup()
	{
		if (File.Exists(SaveFilePath))
			File.Delete(SaveFilePath);
	}
}
