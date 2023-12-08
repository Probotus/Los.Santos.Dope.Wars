namespace LSDW.Application.Interfaces.Infrastructure.Services;

/// <summary>
/// The infrastructure service interface.
/// </summary>
public interface IInfrastructureService
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
