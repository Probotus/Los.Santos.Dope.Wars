using GTA;

using LSDW.Application.Interfaces.Infrastructure.Services;
using LSDW.Domain.Interfaces.Models;

namespace LSDW.Infrastructure.Services;

/// <summary>
/// The settings service class.
/// </summary>
internal sealed class SettingsService : ISettingsService
{
	private readonly string _filePath = Path.Combine(AppContext.BaseDirectory, $"{nameof(LSDW)}.log");
	private readonly ScriptSettings _scriptSettings;
	private readonly ILoggerService _loggerService;
	private readonly ISettings _settings;

	/// <summary>
	/// Initializes a new instance of the settings service class.
	/// </summary>
	/// <param name="loggerService">The logger service instance to use.</param>
	/// <param name="settings">The settings instance to use.</param>
	public SettingsService(ILoggerService loggerService, ISettings settings)
	{
		_scriptSettings = ScriptSettings.Load(_filePath);
		_loggerService = loggerService;
		_settings = settings;

		_settings.Dealer.DownTimeInHours.Changed += (s, e) => _scriptSettings.SetValue("Dealer", "DownTimeInHours", e.Value);
		_settings.Dealer.HasArmor.Changed += (s, e) => _scriptSettings.SetValue("Dealer", "HasArmor", e.Value);
		_settings.Dealer.HasWeapons.Changed += (s, e) => _scriptSettings.SetValue("Dealer", "HasWeapons", e.Value);
	}

	public void Load()
	{
		throw new NotImplementedException();
	}

	public void Save()
	{
		throw new NotImplementedException();
	}
}
