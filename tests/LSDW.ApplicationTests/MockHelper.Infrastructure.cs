using LSDW.Application.Interfaces.Infrastructure.Services;

using Moq;

namespace LSDW.ApplicationTests;

internal static partial class MockHelper
{
	internal static ILoggerService GetLoggerService()
	{
		Mock<ILoggerService> service = new();
		service.SetupAllProperties();
		return service.Object;
	}

	internal static IStateService GetStateService()
	{
		Mock<IStateService> service = new();
		service.SetupAllProperties();
		return service.Object;
	}
}
