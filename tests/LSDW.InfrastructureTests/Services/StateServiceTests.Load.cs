using LSDW.Infrastructure.Services;

using Moq;

namespace LSDW.InfrastructureTests.Services;
public partial class StateServiceTests
{
	[TestMethod]
	public void LoadTest()
	{
		_stateService = new StateService(_domainServiceMock.Object, _loggerServiceMock.Object);

		_stateService.Load();

		_loggerServiceMock.Verify(x => x.Information(It.IsAny<string>(), It.IsAny<string>()));
	}

	[TestMethod]
	public void LoadNoSaveTest()
	{
		_stateService = new StateService(_domainServiceMock.Object, _loggerServiceMock.Object);

		_stateService.Load();

		_loggerServiceMock.Verify(x => x.Information(It.IsAny<string>(), It.IsAny<string>()));
	}

	[TestMethod]
	public void LoadExceptionTest()
	{
		_stateService = new StateService(_domainServiceMock.Object, _loggerServiceMock.Object);

		_stateService.Load();

		_loggerServiceMock.Verify(v => v.Critical(It.IsAny<string>(), It.IsAny<Exception>(), It.IsAny<string>()));
	}
}
