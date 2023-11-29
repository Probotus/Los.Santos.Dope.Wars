namespace LSDW.Application.Interfaces.Infrastructure.Services;

/// <summary>
/// The state service interface.
/// </summary>
public interface IStateService
{
	/// <summary>
	/// Loads the game state from file.
	/// </summary>
	/// <remarks>
	/// If no save file is found, a new save file will be created.
	/// </remarks>
	void Load();

	/// <summary>
	/// Saves the current game state.
	/// </summary>
	void Save();
}
