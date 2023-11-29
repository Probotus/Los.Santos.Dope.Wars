using LSDW.Application.Interfaces.Infrastructure.Services;
using LSDW.Domain.Extensions;
using LSDW.Domain.Extensions.Serialization;
using LSDW.Domain.Interfaces.Models;
using LSDW.Infrastructure.Constants;
using LSDW.Infrastructure.Factories;
using LSDW.Infrastructure.Models;

namespace LSDW.Infrastructure.Services;

/// <summary>
/// The state service class.
/// </summary>
/// <remarks>
/// Initializes a new instance of the state service class.
/// </remarks>
/// <param name="loggerService">The logger service instance to use.</param>
/// <param name="dealers">The dealer collection instance to use.</param>
/// <param name="player">The player instance to use.</param>
internal sealed class StateService(ILoggerService loggerService, IDealerCollection dealers, IPlayer player) : IStateService
{
	private readonly string _filePath = Path.Combine(AppContext.BaseDirectory, $"{nameof(LSDW)}.sav");

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

			player.Load(
				state.Player.Exp,
				InfrastructureFactory.CreateDrugs(state.Player),
				InfrastructureFactory.CreateTransactions(state.Player)
				);

			dealers.Load(InfrastructureFactory.CreateDealers(state.Dealers));

			loggerService.Information($"{nameof(LSDW)} loaded.");
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
			byte[] content = new GameState(player, dealers)
				.ToXml(XmlConstants.SerializerNamespaces)
				.GetBytes()
				.Compress();

			File.WriteAllBytes(_filePath, content);

			loggerService.Information($"{nameof(LSDW)} saved.");
		}
		catch (Exception ex)
		{
			loggerService.Critical("Something went wrong!", ex);
		}
	}
}
