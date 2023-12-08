using LSDW.Domain.Interfaces.Models;

namespace LSDW.Domain.Interfaces.Services;

/// <summary>
/// The domain service interface.
/// </summary>
public interface IDomainService
{
	/// <summary>
	/// The audio service instance.
	/// </summary>
	IAudioService AudioService { get; }

	/// <summary>
	/// The dealer collection instance.
	/// </summary>
	IDealerCollection Dealers { get; }

	/// <summary>
	/// The game service instance.
	/// </summary>
	IGameService GameService { get; }

	/// <summary>
	/// The notification service instance.
	/// </summary>
	INotificationService NotificationService { get; }

	/// <summary>
	/// The player instance.
	/// </summary>
	IPlayer Player { get; }

	/// <summary>
	/// The player service instance.
	/// </summary>
	IPlayerService PlayerService { get; }

	/// <summary>
	/// The screen service instance.
	/// </summary>
	IScreenService ScreenService { get; }

	/// <summary>
	/// The settings instance.
	/// </summary>
	ISettings Settings { get; }

	/// <summary>
	/// The world service instance.
	/// </summary>
	IWorldService WorldService { get; }
}
