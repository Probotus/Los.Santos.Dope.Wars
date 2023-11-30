namespace LSDW.Application.Interfaces.Infrastructure.Services;

/// <summary>
/// The settings service interface.
/// </summary>
public interface ISettingsService
{
	/// <summary>
	/// Loads the current settings from file.
	/// </summary>
	void Load();

	/// <summary>
	/// Saves the current settings to file.
	/// </summary>
	void Save();
}
