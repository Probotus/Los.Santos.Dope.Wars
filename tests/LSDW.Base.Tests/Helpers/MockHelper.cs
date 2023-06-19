﻿using LSDW.Abstractions.Application.Providers;
using LSDW.Abstractions.Domain.Missions;
using LSDW.Abstractions.Domain.Models;
using LSDW.Abstractions.Domain.Services;
using LSDW.Abstractions.Infrastructure.Services;
using Moq;

namespace LSDW.Base.Tests.Helpers;

[SuppressMessage("Style", "IDE0058", Justification = "UnitTest")]
public static class MockHelper
{
	public static Mock<INotificationService> GetNotificationServiceMock()
		=> new();

	public static Mock<ITimeProvider> GetTimeProviderMock()
	{
		Mock<ITimeProvider> mock = new();
		mock.Setup(x => x.Now).Returns(DateTime.MaxValue);
		mock.Setup(x => x.TimeOfDay).Returns(DateTime.MaxValue.TimeOfDay);
		return mock;
	}

	public static Mock<ILoggerService> GetLoggerServiceMock()
		=> new();

	public static Mock<IGameStateService> GetGameStateServiceMock()
		=> new();

	public static Mock<ITrafficking> GetTraffickingMock()
		=> new();

	public static Mock<IInventory> GetInventoryMock()
		=> new();
}
