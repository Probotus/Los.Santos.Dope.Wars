using LSDW.Domain.Interfaces.Models;

namespace LSDW.Application.Interfaces.Presentation.Menus;

/// <summary>
/// The trafficking menu interface.
/// </summary>
public interface ITraffickingMenu
{
	/// <summary>
	/// Clears the trafficking menu.
	/// </summary>
	void Clear();

	/// <summary>
	/// Closes the trafficking menu.
	/// </summary>
	void Close();

	/// <summary>
	/// Initializes the trafficking menu completely.
	/// </summary>
	/// <param name="dealer">The dealer instance to use.</param>
	void Initialize(IDealer dealer);

	/// <summary>
	/// Shows the trafficking menu.
	/// </summary>
	void Show();
}
