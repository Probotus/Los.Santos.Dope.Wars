using LSDW.Application.Interfaces.Infrastructure.Services;
using LSDW.Infrastructure.Services;

using Moq;

namespace LSDW.InfrastructureTests.Services;
public partial class StateServiceTests
{
	[TestMethod]
	public void LoadTest()
		=> _stateService.Load();

	[TestMethod]
	public void LoadNoSaveTest()
		=> _stateService.Load();

	[TestMethod]
	public void LoadExceptionTest()
	{
		Mock<ILoggerService> mock = new();

		new StateService(mock.Object, null!, null!).Load();

		mock.Verify(v => v.Critical(It.IsAny<string>(), It.IsAny<Exception>(), It.IsAny<string>()));
	}
}
