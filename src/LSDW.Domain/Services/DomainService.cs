using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Interfaces.Services;

namespace LSDW.Domain.Services;

/// <summary>
/// The domain service class.
/// </summary>
/// <remarks>
/// Initializes a instance of the domain service class.
/// </remarks>
/// <param name="audioService">The audio service instance to use.</param>
/// <param name="dealers">The dealer collection instance to use.</param>
/// <param name="gameService">The game service instance to use.</param>
/// <param name="notificationService">The notification service instance to use.</param>
/// <param name="player">The player instance to use.</param>
/// <param name="playerService">The player service instance to use.</param>
/// <param name="screenService">The screen service instance to use.</param>
/// <param name="settings">The settings instance to use.</param>
/// <param name="worldService">The world service instance to use.</param>
internal sealed class DomainService(IAudioService audioService, IDealerCollection dealers, IGameService gameService, INotificationService notificationService, IPlayer player, IPlayerService playerService, IScreenService screenService, ISettings settings, IWorldService worldService) : IDomainService
{
	public IAudioService AudioService { get; } = audioService;
	public IDealerCollection Dealers { get; } = dealers;
	public IGameService GameService { get; } = gameService;
	public INotificationService NotificationService { get; } = notificationService;
	public IPlayer Player { get; } = player;
	public IPlayerService PlayerService { get; } = playerService;
	public IScreenService ScreenService { get; } = screenService;
	public ISettings Settings { get; } = settings;
	public IWorldService WorldService { get; } = worldService;
}
