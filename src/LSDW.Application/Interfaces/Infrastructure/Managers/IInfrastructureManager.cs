using LSDW.Application.Interfaces.Infrastructure.Services;

namespace LSDW.Application.Interfaces.Infrastructure.Managers;

/// <summary>
/// The infrastructure manager interface.
/// </summary>
public interface IInfrastructureManager
{
	/// <summary>
	/// The logger service.
	/// </summary>
	ILoggerService LoggerService { get; }

	/// <summary>
	/// The settings service.
	/// </summary>
	ISettingsService SettingsService { get; }

	/// <summary>
	/// The state service.
	/// </summary>
	IStateService StateService { get; }
}
