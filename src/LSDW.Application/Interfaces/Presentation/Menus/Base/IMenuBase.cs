namespace LSDW.Application.Interfaces.Presentation.Menus.Base;

/// <summary>
/// The base menu interface.
/// </summary>
public interface IMenuBase
{
	/// <summary>
	/// Event triggered when the menu is opened and shown to the user.s
	/// </summary>
	event EventHandler Shown;

	/// <summary>
	/// Event triggered when the menu finishes closing.
	/// </summary>
	event EventHandler Closed;

	/// <summary>
	/// Toggles the visibility of the menu on or off.
	/// </summary>
	void Toggle();
}
