using LSDW.Application.Interfaces.Infrastructure.Managers;
using LSDW.Application.Interfaces.Infrastructure.Services;

using Moq;

namespace LSDW.ApplicationTests;

internal static partial class MockHelper
{
	internal static IInfrastructureManager GetInfrastructureManager()
	{
		Mock<IInfrastructureManager> mock = new();
		mock.Setup(x => x.LoggerService).Returns(GetLoggerService());
		mock.Setup(x => x.StateService).Returns(GetStateService());
		mock.Setup(x => x.SettingsService).Returns(GetSettingsService());
		return mock.Object;
	}

	internal static ILoggerService GetLoggerService()
	{
		Mock<ILoggerService> mock = new();
		mock.SetupAllProperties();
		return mock.Object;
	}

	internal static IStateService GetStateService()
	{
		Mock<IStateService> mock = new();
		mock.SetupAllProperties();
		return mock.Object;
	}

	internal static ISettingsService GetSettingsService()
	{
		Mock<ISettingsService> mock = new();
		mock.SetupAllProperties();
		return mock.Object;
	}
}
