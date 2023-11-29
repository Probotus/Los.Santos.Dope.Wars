using GTA;

using LSDW.Domain.Enumerators;
using LSDW.Domain.Interfaces.Models.Base;

namespace LSDW.Application.Interfaces.Application.Missions.Base;

/// <summary>
/// The mission base interface.
/// </summary>
public interface IMissionBase : INotifyPropertyBase
{
	/// <summary>
	/// Gets the current status of the mission.
	/// </summary>
	MissionStatus Status { get; }

	/// <summary>
	/// Starts the mission.
	/// </summary>
	void Start();

	/// <summary>
	/// Stops the mission.
	/// </summary>
	void Stop();

	/// <summary>
	/// Handles the event that is raised when this <see cref="Script"/> gets aborted for any reason.
	/// This should be used for cleaning up anything created during this <see cref="Script"/>.
	/// </summary>
	void OnAborted(object sender, EventArgs e);

	/// <summary>
	/// Handles the event that is raised every tick of the <see cref="Script"/>.
	/// Put code that needs to be looped each frame in here.
	/// </summary>
	void OnTick(object sender, EventArgs e);
}
