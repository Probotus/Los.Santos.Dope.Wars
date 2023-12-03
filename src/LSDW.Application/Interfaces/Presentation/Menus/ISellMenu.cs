using LSDW.Application.Interfaces.Presentation.Menus.Base;
using LSDW.Domain.Interfaces.Models;

namespace LSDW.Application.Interfaces.Presentation.Menus;

/// <summary>
/// The sell menu interface.
/// </summary>
public interface ISellMenu : ITradeMenuBase
{
	/// <summary>
	/// The dealer to interact with.
	/// </summary>
	IDealer? Dealer { get; set; }
}
