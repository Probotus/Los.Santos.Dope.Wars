using LemonUI.Menus;

using LSDW.Application.Interfaces.Presentation.Menus.Base;
using LSDW.Domain.Enumerators;
using LSDW.Domain.Extensions;
using LSDW.Domain.Interfaces.Models;

using GTAFont = GTA.UI.Font;

namespace LSDW.Presentation.Menus.Base;

/// <summary>
/// The trade menu class.
/// </summary>
internal abstract class TradeMenuBase : MenuBase, ITradeMenuBase
{
	/// <summary>
	/// Initializes a new instance of the trade menu class.
	/// </summary>
	/// <param name="type">The transaction type to use.</param>
	protected TradeMenuBase(TransactionType type) : base(type.GetMenuTitle())
	{
		Description = type.GetMenuDescription();
		BannerText.Font = GTAFont.Pricedown;
		ItemCount = CountVisibility.Never;
		MenuType = type;
	}

	/// <summary>
	/// The type of the menu.
	/// </summary>
	protected TransactionType MenuType { get; }

	/// <summary>
	/// Is the menu completely initialized?
	/// </summary>
	protected bool Initialized { get; private set; }

	/// <summary>
	/// Adds a new drug list item to the menu.
	/// </summary>
	/// <param name="drug">The drug to add as item.</param>
	/// <returns>The list item.</returns>
	protected NativeListItem<int> AddDrugListItem(IDrug drug)
	{
		NativeListItem<int> item = AddListItem(drug.Name, drug.Description, OnItemActivated, OnItemChanged, drug.Quantity.ArrayDown());
		item.Enabled = drug.Quantity > 0;
		item.Tag = drug;
		item.SelectedIndex = drug.Quantity;
		return item;
	}

	/// <summary>
	/// Initializes the menu completely.
	/// </summary>
	public virtual void Initialize()
		=> Initialized = true;

	/// <summary>
	/// The action to perform when the drug item gets activated.
	/// </summary>
	public abstract void OnItemActivated(object sender, EventArgs e);

	/// <summary>
	/// The action to perform when the selected drug item of the list changes.
	/// </summary>
	public abstract void OnItemChanged(object sender, ItemChangedEventArgs<int> e);

	/// <inheritdoc/>
	public override void Toggle()
	{
		if (!Initialized)
			throw new InvalidOperationException($"{nameof(Initialized)} is {Initialized}");

		base.Toggle();
	}

	/// <inheritdoc/>
	public override void Switch(bool value)
	{
		if (!Initialized)
			throw new InvalidOperationException($"{nameof(Initialized)} is {Initialized}");

		base.Switch(value);
	}
}
