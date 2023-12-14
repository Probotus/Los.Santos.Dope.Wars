using LSDW.Application.Interfaces.Application.Missions.Base;
using LSDW.Domain.Enumerators;
using LSDW.Domain.Models.Base;

namespace LSDW.Application.Missions.Base;

/// <summary>
/// The mission base class.
/// </summary>
internal abstract class MissionBase : NotifyPropertyBase, IMissionBase
{
	private MissionStatus _status;

	public MissionStatus Status { get => _status; private set => SetProperty(ref _status, value); }

	public abstract void OnAborted(object sender, EventArgs e);

	public abstract void OnTick(object sender, EventArgs e);

	public void Start() => Status = MissionStatus.RUNNING;

	public void Stop() => Status = MissionStatus.STOPPED;
}
