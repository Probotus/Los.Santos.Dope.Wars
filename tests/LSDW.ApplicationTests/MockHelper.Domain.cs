using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Manager;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Interfaces.Services;

using Moq;

namespace LSDW.ApplicationTests;

internal static partial class MockHelper
{
	internal static IDealer GetDealer(bool discovered = false)
	{
		Mock<IDealer> mock = new();
		mock.SetupAllProperties();
		mock.Setup(x => x.Drugs).Returns(GetDrugCollection());
		mock.Setup(x => x.Discover(GetWorldService()));
		mock.Setup(x => x.Discovered).Returns(discovered);
		return mock.Object;
	}

	internal static IDrug GetDrug()
	{
		Mock<IDrug> mock = new();
		mock.SetupAllProperties();
		return mock.Object;
	}

	internal static IDrugCollection GetDrugCollection()
	 => DomainFactory.CreateDrugCollection();

	internal static IAudioService GetAudioProvider()
	{
		Mock<IAudioService> mock = new();
		mock.SetupAllProperties();
		return mock.Object;
	}

	internal static IGameService GetGameProvider()
	{
		Mock<IGameService> mock = new();
		mock.SetupAllProperties();
		return mock.Object;
	}

	internal static INotificationService GetNotificationService()
	{
		Mock<INotificationService> mock = new();
		mock.SetupAllProperties();
		return mock.Object;
	}

	internal static IPlayerService GetPlayerService()
	{
		Mock<IPlayerService> mock = new();
		mock.SetupAllProperties();
		return mock.Object;
	}

	internal static IScreenService GetScreenProvider()
	{
		Mock<IScreenService> mock = new();
		mock.SetupAllProperties();
		return mock.Object;
	}

	internal static IWorldService GetWorldService()
	{
		Mock<IWorldService> mock = new();
		mock.SetupAllProperties();
		return mock.Object;
	}

	internal static IDomainManager GetDomainManager()
	{
		Mock<IDomainManager> mock = new();
		mock.Setup(x => x.AudioService).Returns(GetAudioProvider());
		mock.Setup(x => x.GameService).Returns(GetGameProvider());
		mock.Setup(x => x.NotificationService).Returns(GetNotificationService());
		mock.Setup(x => x.ScreenService).Returns(GetScreenProvider());
		mock.Setup(x => x.PlayerService).Returns(GetPlayerService());
		mock.Setup(x => x.WorldService).Returns(GetWorldService());
		return mock.Object;
	}
}
