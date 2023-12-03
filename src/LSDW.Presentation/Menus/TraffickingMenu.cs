using LSDW.Application.Interfaces.Presentation.Menus;
using LSDW.Domain.Interfaces.Models;

namespace LSDW.Presentation;

/// <summary>
/// The trafficking menu class.
/// </summary>
internal sealed class TraffickingMenu : ITraffickingMenu
{
	private readonly IBuyMenu _buyMenu;
	private readonly ISellMenu _sellMenu;
	private bool _initialized;

	/// <summary>
	/// Initializes a new instance of the trafficking menu class.
	/// </summary>
	/// <param name="buyMenu">The buy menu instance to use.</param>
	/// <param name="sellMenu">The sell menu instance to use.</param>
	public TraffickingMenu(IBuyMenu buyMenu, ISellMenu sellMenu)
	{
		_buyMenu = buyMenu;
		_sellMenu = sellMenu;

		_buyMenu.Closed += (s, e) => OnBuyMenuClosed();
		_sellMenu.Closed += (s, e) => OnSellMenuClosed();
	}

	private void OnBuyMenuClosed()
		=> _sellMenu.Toggle();

	private void OnSellMenuClosed()
		=> _buyMenu.Toggle();

	public void Initialize(IDealer dealer)
	{
		_buyMenu.Dealer = dealer;
		_buyMenu.Initialize();
		_sellMenu.Dealer = dealer;
		_sellMenu.Initialize();
		_initialized = true;
	}

	public void Show()
	{
		if (!_initialized)
			throw new InvalidOperationException($"{nameof(_initialized)} is {_initialized}");

		_buyMenu.Toggle();
	}

	public void Clear()
	{
		_buyMenu.Closed -= (s, e) => OnBuyMenuClosed();
		_buyMenu.Clear();
		_buyMenu.Dealer = null;

		_sellMenu.Closed -= (s, e) => OnSellMenuClosed();		
		_sellMenu.Clear();
		_sellMenu.Dealer = null;

		_initialized = false;
	}
}
