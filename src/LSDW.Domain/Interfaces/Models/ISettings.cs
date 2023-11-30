using LSDW.Domain.Interfaces.Models.Base;

namespace LSDW.Domain.Interfaces.Models;

/// <summary>
/// The settings interface.
/// </summary>
public interface ISettings
{
	/// <summary>
	/// The dealer settings.
	/// </summary>
	public IDealerSettings Dealer { get; }

	/// <summary>
	/// The market settings.
	/// </summary>
	public IMarketSettings Market { get; }

	/// <summary>
	/// The player settings.
	/// </summary>
	public IPlayerSettings Player { get; }

	/// <summary>
	/// The trafficking settings.
	/// </summary>
	public ITraffickingSettings Trafficking { get; }
}

/// <summary>
/// The dealer settings interface.
/// </summary>
public interface IDealerSettings
{
	/// <summary>
	/// The down time in hours property.
	/// </summary>
	IBindableProperty<int> DownTimeInHours { get; }

	/// <summary>
	/// The dealer has armor property.
	/// </summary>
	IBindableProperty<bool> HasArmor { get; }

	/// <summary>
	/// The dealer has weapons property.
	/// </summary>
	IBindableProperty<bool> HasWeapons { get; }

	/// <summary>
	/// Returns the possible dealer down time values.
	/// </summary>
	/// <returns>The list of possible values.</returns>
	int[] GetDownTimeInHoursValues();
}

/// <summary>
/// The market settings interface.
/// </summary>
public interface IMarketSettings
{
	/// <summary>
	/// The restock interval property.
	/// </summary>
	IBindableProperty<int> RestockInterval { get; }

	/// <summary>
	/// The maximum drug price factor.
	/// </summary>
	IBindableProperty<float> MaximumDrugPrice { get; }

	/// <summary>
	/// The minimum drug price factor.
	/// </summary>
	IBindableProperty<float> MinimumDrugPrice { get; }

	/// <summary>
	/// The refresh interval property.
	/// </summary>
	IBindableProperty<int> RefreshInterval { get; }

	/// <summary>
	/// The special offer chance property.
	/// </summary>
	IBindableProperty<float> SpecialOfferChance { get; }

	/// <summary>
	/// Returns the possible restock interval values.
	/// </summary>
	/// <returns>The list of possible values.</returns>
	int[] GetRestockIntervalValues();

	/// <summary>
	/// Returns the possible maximum drug price factor values.
	/// </summary>
	/// <returns>The list of possible values.</returns>
	float[] GetMaximumDrugPriceValues();

	/// <summary>
	/// Returns the possible minimum drug price factor values.
	/// </summary>
	/// <returns>The list of possible values.</returns>
	float[] GetMinimumDrugPriceValues();

	/// <summary>
	/// Returns the possible refresh interval values.
	/// </summary>
	/// <returns>The list of possible values.</returns>
	int[] GetRefreshIntervalValues();

	/// <summary>
	/// Returns the possible special offer chance values.
	/// </summary>
	/// <returns>The list of possible values.</returns>
	float[] GetSpecialOfferChanceValues();
}

/// <summary>
/// The player settings interface.
/// </summary>
public interface IPlayerSettings
{
	/// <summary>
	/// The experience multiplier property.
	/// </summary>
	IBindableProperty<float> ExperienceMultiplier { get; }

	/// <summary>
	/// The bag size per level property.
	/// </summary>
	IBindableProperty<int> BagSizePerLevel { get; }

	/// <summary>
	/// The loose drugs on death property.
	/// </summary>
	IBindableProperty<bool> LooseDrugsOnDeath { get; }

	/// <summary>
	/// The loose drugs when busted property.
	/// </summary>
	IBindableProperty<bool> LooseDrugsWhenBusted { get; }

	/// <summary>
	/// The loose money on death property.
	/// </summary>
	IBindableProperty<bool> LooseMoneyOnDeath { get; }

	/// <summary>
	/// The loose money when busted property.
	/// </summary>
	IBindableProperty<bool> LooseMoneyWhenBusted { get; }

	/// <summary>
	/// Returns the possible experience multiplier factor values.
	/// </summary>
	/// <returns>The list of possible values.</returns>
	float[] GetExperienceMultiplierValues();

	/// <summary>
	/// Returns the possible starting inventory values.
	/// </summary>
	/// <returns>The list of possible values.</returns>
	int[] GetBagSizePerLevelValues();
}

/// <summary>
/// The trafficking settings interface.
/// </summary>
public interface ITraffickingSettings
{
	/// <summary>
	/// The bust chance property.
	/// </summary>
	IBindableProperty<float> BustChance { get; }

	/// <summary>
	/// The discover dealer property.
	/// </summary>
	IBindableProperty<bool> DiscoverDealer { get; }

	/// <summary>
	/// The wanted level property.
	/// </summary>
	IBindableProperty<int> WantedLevel { get; }

	/// <summary>
	/// Returns the possible bust chance values.
	/// </summary>
	/// <returns>The list of possible values.</returns>
	float[] GetBustChanceValues();

	/// <summary>
	/// Returns the possible wanted level values.
	/// </summary>
	/// <returns>The list of possible values.</returns>
	int[] GetWantedLevelValues();
}
