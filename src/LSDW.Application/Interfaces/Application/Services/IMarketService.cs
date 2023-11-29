using LSDW.Application.Interfaces.Application.Missions.Base;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Interfaces.Models.Base;

namespace LSDW.Application.Interfaces.Application.Services;

/// <summary>
/// The market service interface.
/// </summary>
public interface IMarketService : IServiceBase, INotifyPropertyBase
{
	/// <summary>
	/// The next refresh of the market prices.
	/// </summary>
	DateTime NextRefresh { get; }

	/// <summary>
	/// The next restock of the market quantities and prices.
	/// </summary>
	DateTime NextRestock { get; }

	/// <summary>
	/// Takes care of everything concerning the current price and money.
	/// </summary>
	void Refresh();

	/// <summary>
	/// Takes care of the current prices and the current money of the dealer.
	/// </summary>
	/// <param name="dealer">The dealer to work with.</param>
	void Refresh(IDealer dealer);

	/// <summary>
	/// Flood the market with new goods.
	/// </summary>
	void Restock();

	/// <summary>
	/// Takes care of the current drug quantities of the dealer.
	/// </summary>
	/// <param name="dealer">The dealer to work with.</param>
	void Restock(IDealer dealer);
}
