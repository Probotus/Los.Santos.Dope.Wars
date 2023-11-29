using GTA;

namespace LSDW.Application.Interfaces.Application.Missions.Base;

/// <summary>
/// The service base interface.
/// </summary>
public interface IServiceBase
{
	/// <summary>
	/// Handles the event that is raised every tick of the <see cref="Script"/>.
	/// Put code that needs to be looped each frame in here.
	/// </summary>
	void OnTick(object sender, EventArgs e);
}
