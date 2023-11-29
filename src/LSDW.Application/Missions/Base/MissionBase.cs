using LSDW.Application.Interfaces.Application.Missions.Base;
using LSDW.Application.Interfaces.Infrastructure.Services;
using LSDW.Domain.Enumerators;
using LSDW.Domain.Models.Base;

namespace LSDW.Application.Missions.Base;

/// <summary>
/// The mission base class.
/// </summary>
/// <param name="stateService">The state service instance to use.</param>
internal abstract class MissionBase(IStateService stateService) : NotifyPropertyBase, IMissionBase
{
	private readonly IStateService _stateService = stateService;
	private MissionStatus _status;

	public MissionStatus Status { get => _status; private set => SetProperty(ref _status, value); }

	public virtual void OnAborted(object sender, EventArgs e)
		=> Stop();

	public abstract void OnTick(object sender, EventArgs e);

	public virtual void Start()
	{
		_stateService.Load();
		Status = MissionStatus.RUNNING;
	}

	public virtual void Stop()
	{
		Status = MissionStatus.STOPPED;
		_stateService.Save();
	}
}
