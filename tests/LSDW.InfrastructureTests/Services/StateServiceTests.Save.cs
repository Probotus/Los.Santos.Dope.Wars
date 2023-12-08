using LSDW.Infrastructure.Services;

using Moq;

namespace LSDW.InfrastructureTests.Services;

public partial class StateServiceTests
{
	[TestMethod]
	public void SaveTest()
	{
		_stateService = new StateService(_domainServiceMock.Object, _loggerServiceMock.Object);

		_stateService.Save();

		_loggerServiceMock.Verify(x => x.Information(It.IsAny<string>(), It.IsAny<string>()));
	}

	[TestMethod]
	public void SaveExceptionTest()
	{
		_stateService = new StateService(_domainServiceMock.Object, _loggerServiceMock.Object);

		_stateService.Save();

		_loggerServiceMock.Verify(v => v.Critical(It.IsAny<string>(), It.IsAny<Exception>(), It.IsAny<string>()));
	}
}
