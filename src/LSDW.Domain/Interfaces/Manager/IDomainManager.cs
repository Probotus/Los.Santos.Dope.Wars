using LSDW.Domain.Interfaces.Services;

namespace LSDW.Domain.Interfaces.Manager;

/// <summary>
/// The domain manager interface.
/// </summary>
public interface IDomainManager
{
	/// <summary>
	/// The audio service instance.
	/// </summary>
	IAudioService AudioService { get; }

	/// <summary>
	/// The game service instance.
	/// </summary>
	IGameService GameService { get; }

	/// <summary>
	/// The notification service instance.
	/// </summary>
	INotificationService NotificationService { get; }

	/// <summary>
	/// The player service instance.
	/// </summary>
	IPlayerService PlayerService { get; }

	/// <summary>
	/// The screen service instance.
	/// </summary>
	IScreenService ScreenService { get; }

	/// <summary>
	/// The world service instance.
	/// </summary>
	IWorldService WorldService { get; }
}
