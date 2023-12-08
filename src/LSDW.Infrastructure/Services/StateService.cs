using LSDW.Application.Interfaces.Infrastructure.Services;
using LSDW.Domain.Extensions;
using LSDW.Domain.Extensions.Serialization;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Interfaces.Services;
using LSDW.Infrastructure.Constants;
using LSDW.Infrastructure.Factories;
using LSDW.Infrastructure.Models;
using LSDW.Infrastructure.Statics;

namespace LSDW.Infrastructure.Services;

/// <summary>
/// The state service class.
/// </summary>
/// <remarks>
/// Initializes a new instance of the state service class.
/// </remarks>
/// <param name="domainService">The domain service instance to use.</param>
/// <param name="loggerService">The logger service instance to use.</param>
internal sealed class StateService(IDomainService domainService, ILoggerService loggerService) : IStateService
{
	private readonly string _filePath = Path.Combine(FileStatics.BasePath, FileStatics.SavFileName);
	private readonly IDealerCollection _dealers = domainService.Dealers;
	private readonly IPlayer _player = domainService.Player;
	private readonly ISettings _settings = domainService.Settings;
	private readonly IWorldService _worldService = domainService.WorldService;

	public void Load()
	{
		try
		{
			if (!File.Exists(_filePath))
			{
				Save();
				return;
			}

			GameState state = File.ReadAllBytes(_filePath)
				.Decompress()
				.GetString()
				.FromXml<GameState>();

			_player.Load(
				state.Player.Exp,
				InfrastructureFactory.CreateDrugs(state.Player),
				InfrastructureFactory.CreateTransactions(state.Player)
				);

			_dealers.Load(InfrastructureFactory.CreateDealers(_settings, _worldService, state.Dealers));

			loggerService.Information($"{nameof(LSDW)} state loaded.");
		}
		catch (Exception ex)
		{
			loggerService.Critical("Something went wrong!", ex);
		}
	}

	public void Save()
	{
		try
		{
			byte[] content = new GameState(_player, _dealers)
				.ToXml(XmlConstants.SerializerNamespaces)
				.GetBytes()
				.Compress();

			File.WriteAllBytes(_filePath, content);

			loggerService.Information($"{nameof(LSDW)} state saved.");
		}
		catch (Exception ex)
		{
			loggerService.Critical("Something went wrong!", ex);
		}
	}
}
