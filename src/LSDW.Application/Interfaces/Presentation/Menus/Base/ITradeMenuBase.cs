namespace LSDW.Application.Interfaces.Presentation.Menus.Base;

/// <summary>
/// The base trade menu interface.
/// </summary>
public interface ITradeMenuBase : IMenuBase
{
	/// <summary>
	/// Clears the menu from its items.
	/// </summary>
	void Clear();
	
	/// <summary>
	/// Initializes the trade menu completely.
	/// </summary>
	void Initialize();
}
