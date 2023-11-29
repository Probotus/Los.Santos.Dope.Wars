namespace LSDW.Application.Interfaces.Application.Missions.Base;

/// <summary>
/// The mission control interface.
/// </summary>
public interface IMissionControl
{
	/// <summary>
	/// Handles the event that is raised when a key is first pressed.
	/// The <see cref="KeyEventArgs"/> contains the key that was pressed.
	/// </summary>
	void OnKeyDown(object sender, KeyEventArgs e);

	/// <summary>
	/// Handles the event that is raised when a key is lifted.
	/// The <see cref="KeyEventArgs"/> contains the key that was lifted.
	/// </summary>
	void OnKeyUp(object sender, KeyEventArgs e);
}
