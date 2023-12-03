using LSDW.Application.Interfaces.Presentation.Menus.Base;
using LSDW.Domain.Interfaces.Models;

namespace LSDW.Application.Interfaces.Presentation.Menus;

/// <summary>
/// The buy menu interface.
/// </summary>
public interface IBuyMenu : ITradeMenuBase
{
	/// <summary>
	/// The dealer to interact with.
	/// </summary>
	IDealer? Dealer { get; set; }
}
