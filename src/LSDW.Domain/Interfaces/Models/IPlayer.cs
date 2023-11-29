using LSDW.Domain.Interfaces.Models.Base;

namespace LSDW.Domain.Interfaces.Models;

/// <summary>
/// The player interface.
/// </summary>
public interface IPlayer : INotifyPropertyBase
{
	/// <summary>
	/// The current maximum bag size of the player.
	/// </summary>
	/// <remarks>
	/// The drugs the player can currently carry.
	/// </remarks>
	int BagSize { get; }

	/// <summary>
	/// The current experience points of the player.
	/// </summary>
	int Exp { get; }

	/// <summary>
	/// The experience points needed to reach the next level.
	/// </summary>
	int ExpForNextLevel { get; }

	/// <summary>
	/// The current level of the player.
	/// </summary>
	/// <remarks>
	/// <b>The current maximum level a player can reach is 100.</b>
	/// </remarks>
	int Level { get; }

	/// <summary>
	/// The drugs of the player.
	/// </summary>
	IDrugCollection Drugs { get; }

	/// <summary>
	/// The transactions of the player.
	/// </summary>
	ITransactionCollection Transactions { get; }

	/// <summary>
	/// Adds the desired experience points to the players current experience.
	/// </summary>
	/// <remarks>
	/// <b>If the player level has reached 100, no more experience points will be added.</b>
	/// </remarks>
	/// <param name="points">The experience points to add.</param>
	void AddExperience(int points);

	/// <summary>
	/// Loads a saved player state.
	/// </summary>
	/// <param name="experience">The saved player experience points.</param>
	/// <param name="drugs">The saved player drugs.</param>
	/// <param name="transactions">The saved player transactions.</param>
	void Load(int experience, IEnumerable<IDrug> drugs, IEnumerable<ITransaction> transactions);
}
