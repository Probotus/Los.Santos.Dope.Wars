using LemonUI.Menus;

using LSDW.Domain.Enumerators;
using LSDW.Domain.Extensions;
using LSDW.Domain.Interfaces.Manager;
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
/// <param name="dealer">The dealer instance to use.</param>
/// <param name="domainManager">The domain manager instance to use.</param>
public sealed class SellMenu(IPlayer player, IDealer dealer, IDomainManager domainManager) : TradeMenuBase(TransactionType.SELL)
{
	private readonly IPlayerService _playerService = domainManager.PlayerService;

	/// <inheritdoc/>
	public override void Initialize()
	{
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
