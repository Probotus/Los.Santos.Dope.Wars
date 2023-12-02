using LSDW.Application.Interfaces.Infrastructure.Managers;
using LSDW.Application.Interfaces.Infrastructure.Services;

namespace LSDW.Infrastructure.Managers;

/// <summary>
/// The infrastructure manager class.
/// </summary>
/// <remarks>
/// Initializes a new instance of the infrastructure manager class.
/// </remarks>
/// <param name="loggerService">The logger service instance to use.</param>
/// <param name="settingsService">The settings service instance to use.</param>
/// <param name="stateService">The state service instance to use.</param>
internal sealed class InfrastructureManager(ILoggerService loggerService, ISettingsService settingsService, IStateService stateService) : IInfrastructureManager
{
	public ILoggerService LoggerService { get; } = loggerService;
	public ISettingsService SettingsService { get; } = settingsService;
	public IStateService StateService { get; } = stateService;
}
