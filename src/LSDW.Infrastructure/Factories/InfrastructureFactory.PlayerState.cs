using LSDW.Domain.Interfaces.Models;
using LSDW.Infrastructure.Models;

namespace LSDW.Infrastructure.Factories;

internal static partial class InfrastructureFactory
{
	/// <summary>
	/// Returns a new player state from a drug instance.
	/// </summary>
	/// <param name="player">The player instance to use.</param>
	/// <returns>The new player state.</returns>
	public static PlayerState CreatePlayerState(IPlayer player)
		=> new(player);

	/// <summary>
	/// Returns a new transaction instance collection from the player state.
	/// </summary>
	/// <param name="state">The player state to use.</param>
	/// <returns>The new transaction collection instance.</returns>
	public static IEnumerable<ITransaction> CreateTransactions(PlayerState state)
		=> CreateTransactions(state.Transactions);

	/// <summary>
	/// Returns a new drug instance collection from the player state.
	/// </summary>
	/// <param name="state">The player state to use.</param>
	/// <returns>The new drug collection instance.</returns>
	public static IEnumerable<IDrug> CreateDrugs(PlayerState state)
		=> CreateDrugs(state.Drugs);
}
