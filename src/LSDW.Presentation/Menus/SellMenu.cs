using LemonUI.Menus;

using LSDW.Application.Interfaces.Presentation.Menus;
using LSDW.Domain.Enumerators;
using LSDW.Domain.Extensions;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Interfaces.Services;
using LSDW.Presentation.Menus.Base;

namespace LSDW.Presentation.Menus;

/// <summary>
/// The sell menu.
/// </summary>
/// <remarks>
/// Initializes a new instance of the sell menu class.
/// </remarks>
/// <param name="player">The player instance to use.</param>
/// <param name="domainManager">The domain manager instance to use.</param>
internal sealed class SellMenu(IPlayer player, IDomainService domainManager) : TradeMenuBase(TransactionType.SELL), ISellMenu
{
	private readonly IPlayerService _playerService = domainManager.PlayerService;
	
	/// <inheritdoc/>
	public IDealer? Dealer { get; set; }

	/// <inheritdoc/>
	public override void Initialize()
	{
		if (Dealer is null)
			return;

		player.Drugs.ForEach(drug => AddDrugListItem(drug));
		base.Initialize();
	}

	/// <inheritdoc/>
	public override void OnItemActivated(object sender, EventArgs e)
	{
	}

	/// <inheritdoc/>
	public override void OnItemChanged(object sender, ItemChangedEventArgs<int> e)
	{
	}
}
