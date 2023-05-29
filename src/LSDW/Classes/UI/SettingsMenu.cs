﻿using LemonUI;
using LemonUI.Menus;
using LSDW.Interfaces.Services;
using static LSDW.Core.Classes.Settings;
using RESX = LSDW.Properties.Resources;

namespace LSDW.Classes.UI;

/// <summary>
/// The settings menu class.
/// </summary>
public sealed class SettingsMenu : NativeMenu
{
	private readonly ISettingsService _settingsService;
	private readonly ILoggerService _loggerService;
	private readonly ObjectPool _processables = new();

	/// <summary>
	/// Initializes a instance of the settings menu class.
	/// </summary>
	/// <param name="settingsService">The settings service.</param>
	/// <param name="loggerService">The logger service.</param>
	internal SettingsMenu(ISettingsService settingsService, ILoggerService loggerService) : base(RESX.UI_SettingsMenu_Title, RESX.UI_SettingsMenu_Subtitle)
	{
		_settingsService = settingsService;
		_loggerService = loggerService;

		AddMenuItems();
		_processables.Add(this);

		Closing += OnClosing;
	}

	private void AddMenuItems()
	{
		try
		{
			NativeCheckboxItem looseDrugsWhenBustedItem = new($"{nameof(Player.LooseDrugsWhenBusted)}", true)
			{
				Checked = Player.LooseDrugsWhenBusted
			};
			looseDrugsWhenBustedItem.CheckboxChanged += LooseDrugsWhenBustedItemCheckboxChanged;
			Add(looseDrugsWhenBustedItem);

			NativeCheckboxItem looseDrugsOnDeathItem = new($"{nameof(Player.LooseDrugsOnDeath)}", true)
			{
				Checked = Player.LooseDrugsOnDeath
			};
			looseDrugsOnDeathItem.CheckboxChanged += LooseDrugsOnDeathItemCheckboxChanged;
			Add(looseDrugsOnDeathItem);

			NativeListItem<int> inventoryExpansionPerLevelItem = new($"{nameof(Player.InventoryExpansionPerLevel)}", new int[] { 0, 5, 10, 15, 25, 30, 35, 40, 45, 50 })
			{
				Enabled = true,
				SelectedItem = Player.InventoryExpansionPerLevel
			};
			inventoryExpansionPerLevelItem.ItemChanged += InventoryExpansionPerLevelItemChanged;
			Add(inventoryExpansionPerLevelItem);

			NativeListItem<int> startingInventoryItem = new($"{nameof(Player.StartingInventory)}", new int[] { 50, 75, 100, 125, 150 })
			{
				Enabled = true,
				SelectedItem = Player.StartingInventory
			};
			startingInventoryItem.ItemChanged += StartingInventoryItemChanged;
			Add(startingInventoryItem);

			NativeListItem<int> downTimeInHoursItem = new($"{nameof(Dealer.DownTimeInHours)}", new int[] { 24, 48, 72, 96, 120, 144, 168 })
			{
				Enabled = true,
				SelectedItem = Dealer.DownTimeInHours
			};
			downTimeInHoursItem.ItemChanged += DownTimeInHoursItemChanged;
			Add(downTimeInHoursItem);

			NativeListItem<float> minimumDrugValueItem = new($"{nameof(Market.MinimumDrugValue)}", new float[] { 0.5f, 0.6f, 0.7f, 0.8f, 0.9f })
			{
				Enabled = true,
				SelectedItem = Market.MinimumDrugValue
			};
			minimumDrugValueItem.ItemChanged += MinimumDrugValueItemChanged;
			Add(minimumDrugValueItem);

			NativeListItem<float> maximumDrugValueItem = new($"{nameof(Market.MaximumDrugValue)}", new float[] { 1.1f, 1.2f, 1.3f, 1.4f, 1.5f })
			{
				Enabled = true,
				SelectedItem = Market.MaximumDrugValue
			};
			maximumDrugValueItem.ItemChanged += MaximumDrugValueItemChanged;
			Add(maximumDrugValueItem);
		}
		catch (Exception ex)
		{
			_loggerService.Critical(ex.Message);
		}
	}

	private void MaximumDrugValueItemChanged(object sender, ItemChangedEventArgs<float> args)
	{
		if (sender is not NativeListItem<float> maximumDrugValueItem)
			return;
		_settingsService.SetMaximumDrugValue(maximumDrugValueItem.SelectedItem);
	}

	private void MinimumDrugValueItemChanged(object sender, ItemChangedEventArgs<float> args)
	{
		if (sender is not NativeListItem<float> minimumDrugValueItem)
			return;
		_settingsService.SetMinimumDrugValue(minimumDrugValueItem.SelectedItem);
	}

	private void DownTimeInHoursItemChanged(object sender, ItemChangedEventArgs<int> args)
	{
		if (sender is not NativeListItem<int> downTimeInHoursItem)
			return;
		_settingsService.SetDownTimeInHours(downTimeInHoursItem.SelectedItem);
	}

	private void StartingInventoryItemChanged(object sender, ItemChangedEventArgs<int> args)
	{
		if (sender is not NativeListItem<int> startingInventoryItem)
			return;
		_settingsService.SetStartingInventory(startingInventoryItem.SelectedItem);
	}

	private void InventoryExpansionPerLevelItemChanged(object sender, ItemChangedEventArgs<int> args)
	{
		if (sender is not NativeListItem<int> inventoryExpansionPerLevelItem)
			return;
		_settingsService.SetInventoryExpansionPerLevel(inventoryExpansionPerLevelItem.SelectedItem);
	}

	private void LooseDrugsOnDeathItemCheckboxChanged(object sender, EventArgs args)
	{
		if (sender is not NativeCheckboxItem looseDrugsOnDeathItem)
			return;
		_settingsService.SetLooseDrugsOnDeath(looseDrugsOnDeathItem.Checked);
	}

	private void LooseDrugsWhenBustedItemCheckboxChanged(object sender, EventArgs args)
	{
		if (sender is not NativeCheckboxItem looseDrugsWhenBustedItem)
			return;
		_settingsService.SetLooseDrugsWhenBusted(looseDrugsWhenBustedItem.Checked);
	}

	private void OnClosing(object sender, CancelEventArgs args)
		=> _settingsService.Save();

	internal void OnTick(object sender, EventArgs args)
		=> _processables.Process();
}
