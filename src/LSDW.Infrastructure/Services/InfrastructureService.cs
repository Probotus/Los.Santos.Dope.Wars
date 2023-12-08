using LSDW.Application.Interfaces.Infrastructure.Services;

namespace LSDW.Infrastructure.Services;

/// <summary>
/// The infrastructure service class.
/// </summary>
/// <remarks>
/// Initializes a new instance of the infrastructure service class.
/// </remarks>
/// <param name="loggerService">The logger service instance to use.</param>
/// <param name="settingsService">The settings service instance to use.</param>
/// <param name="stateService">The state service instance to use.</param>
internal sealed class InfrastructureService(ILoggerService loggerService, ISettingsService settingsService, IStateService stateService) : IInfrastructureService
{
	public ILoggerService LoggerService { get; } = loggerService;
	public ISettingsService SettingsService { get; } = settingsService;
	public IStateService StateService { get; } = stateService;
}
