using LSDW.Domain.Interfaces.Models;
using LSDW.Infrastructure.Services;

using Moq;

namespace LSDW.InfrastructureTests.Services;

public partial class StateServiceTests
{
	[TestMethod]
	public void SaveTest()
	{
		StateService stateService = new(_domainServiceMock.Object, _loggerServiceMock.Object);

		stateService.Save();

		_loggerServiceMock.Verify(x => x.Information(It.IsAny<string>(), It.IsAny<string>()));
	}

	[TestMethod]
	public void SaveExceptionTest()
	{
		IPlayer player = null!;
		_domainServiceMock.Setup(x => x.Player).Returns(player);
		StateService stateService = new(_domainServiceMock.Object, _loggerServiceMock.Object);

		stateService.Save();

		_loggerServiceMock.Verify(v => v.Critical(It.IsAny<string>(), It.IsAny<Exception>(), It.IsAny<string>()));
	}
}
