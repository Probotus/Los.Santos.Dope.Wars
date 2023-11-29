using LSDW.Domain.Interfaces.Manager;
using LSDW.Domain.Interfaces.Services;
using LSDW.Domain.Services;

namespace LSDW.Domain.Managers;

/// <summary>
/// The domain manager class.
/// </summary>
internal sealed class DomainManager : IDomainManager
{
	private readonly Lazy<IAudioService> _audioService;
	private readonly Lazy<IGameService> _gameService;
	private readonly Lazy<INotificationService> _notificationService;
	private readonly Lazy<IPlayerService> _playerService;
	private readonly Lazy<IScreenService> _screenService;
	private readonly Lazy<IWorldService> _worldService;

	/// <summary>
	/// Initializes a new instance of the domain service manager class.
	/// </summary>
	public DomainManager()
	{
		_audioService = new(() => new AudioService());
		_gameService = new(() => new GameService());
		_notificationService = new(() => new NotificationService());
		_playerService = new(() => new PlayerService());
		_screenService = new(() => new ScreenService());
		_worldService = new(() => new WorldService());
	}

	public IAudioService AudioService => _audioService.Value;
	public IGameService GameService => _gameService.Value;
	public INotificationService NotificationService => _notificationService.Value;
	public IPlayerService PlayerService => _playerService.Value;
	public IScreenService ScreenService => _screenService.Value;
	public IWorldService WorldService => _worldService.Value;
}
