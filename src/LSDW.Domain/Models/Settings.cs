using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Interfaces.Models.Base;
using LSDW.Domain.Models.Base;

namespace LSDW.Domain.Models;

/// <summary>
/// The settings class.
/// </summary>
internal sealed class Settings : ISettings
{
	private readonly Lazy<IDealerSettings> _lazyDealerSettings;
	private readonly Lazy<IMarketSettings> _lazyMarketSettings;
	private readonly Lazy<IPlayerSettings> _lazyPlayerSettings;
	private readonly Lazy<ITraffickingSettings> _lazyTraffickingSettings;

	/// <summary>
	/// Initializes a new instance of the settings class.
	/// </summary>
	public Settings()
	{
		_lazyDealerSettings = new(() => new DealerSettings());
		_lazyMarketSettings = new(() => new MarketSettings());
		_lazyPlayerSettings = new(() => new PlayerSettings());
		_lazyTraffickingSettings = new(() => new TraffickingSettings());
	}

	public IDealerSettings DealerSettings
		=> _lazyDealerSettings.Value;
	public IMarketSettings MarketSettings
		=> _lazyMarketSettings.Value;
	public IPlayerSettings PlayerSettings
		=> _lazyPlayerSettings.Value;
	public ITraffickingSettings TraffickingSettings
		=> _lazyTraffickingSettings.Value;
}

/// <summary>
/// The dealer settings class.
/// </summary>
internal sealed class DealerSettings : IDealerSettings
{
	/// <summary>
	/// Initializes a new instance of the dealer settings class.
	/// </summary>
	public DealerSettings()
	{
		DownTimeInHours = new BindableProperty<int>(48);
		HasArmor = new BindableProperty<bool>(true);
		HasWeapons = new BindableProperty<bool>(true);
	}

	public IBindableProperty<int> DownTimeInHours { get; }
	public IBindableProperty<bool> HasArmor { get; }
	public IBindableProperty<bool> HasWeapons { get; }

	public int[] GetDownTimeInHoursValues()
		=> new int[] { 24, 48, 72, 96, 120, 144, 168 };
}

/// <summary>
/// The market settings class.
/// </summary>
internal sealed class MarketSettings : IMarketSettings
{
	/// <summary>
	/// Initializes a instance of the market settings class.
	/// </summary>
	public MarketSettings()
	{
		RestockInterval = new BindableProperty<int>(24);
		MaximumDrugPrice = new BindableProperty<float>(1.15f);
		MinimumDrugPrice = new BindableProperty<float>(0.85f);
		RefreshInterval = new BindableProperty<int>(6);
		SpecialOfferChance = new BindableProperty<float>(0.15f);
	}

	public IBindableProperty<int> RestockInterval { get; }
	public IBindableProperty<float> MaximumDrugPrice { get; }
	public IBindableProperty<float> MinimumDrugPrice { get; }
	public IBindableProperty<int> RefreshInterval { get; }
	public IBindableProperty<float> SpecialOfferChance { get; }

	public float[] GetMaximumDrugPriceValues()
		=> new float[] { 1.05f, 1.1f, 1.15f, 1.2f, 1.25f };

	public float[] GetMinimumDrugPriceValues()
		=> new float[] { 0.75f, 0.8f, 0.85f, 0.9f, 0.95f };

	public int[] GetRefreshIntervalValues()
		=> new int[] { 3, 6, 8, 12, 24 };

	public int[] GetRestockIntervalValues()
		=> new int[] { 24, 48, 72, 96, 120, 144, 168 };

	public float[] GetSpecialOfferChanceValues()
		=> new float[] { 0.5f, 0.10f, 0.15f, 0.20f, 0.25f };
}

/// <summary>
/// The player settings class.
/// </summary>
internal sealed class PlayerSettings : IPlayerSettings
{
	/// <summary>
	/// Initializes a instance of the player settings class.
	/// </summary>
	public PlayerSettings()
	{
		ExperienceMultiplier = new BindableProperty<float>(1);
		BagSizePerLevel = new BindableProperty<int>(50);
		LooseDrugsOnDeath = new BindableProperty<bool>(true);
		LooseDrugsWhenBusted = new BindableProperty<bool>(true);
		LooseMoneyOnDeath = new BindableProperty<bool>(true);
		LooseMoneyWhenBusted = new BindableProperty<bool>(true);
	}

	public IBindableProperty<float> ExperienceMultiplier { get; }
	public IBindableProperty<int> BagSizePerLevel { get; }
	public IBindableProperty<bool> LooseDrugsOnDeath { get; }
	public IBindableProperty<bool> LooseDrugsWhenBusted { get; }
	public IBindableProperty<bool> LooseMoneyOnDeath { get; }
	public IBindableProperty<bool> LooseMoneyWhenBusted { get; }

	public float[] GetExperienceMultiplierValues()
		=> new float[] { 0.75f, 0.8f, 0.85f, 0.9f, 0.95f, 1f, 1.05f, 1.1f, 1.15f, 1.2f, 1.25f };

	public int[] GetBagSizePerLevelValues()
		=> new int[] { 50, 75, 100, 125, 150 };
}

/// <summary>
/// The trafficking settings class.
/// </summary>
internal sealed class TraffickingSettings : ITraffickingSettings
{
	/// <summary>
	/// Initializes a instance of the trafficking settings class.
	/// </summary>
	public TraffickingSettings()
	{
		BustChance = new BindableProperty<float>(0.1f);
		DiscoverDealer = new BindableProperty<bool>(false);
		WantedLevel = new BindableProperty<int>(2);
	}

	public IBindableProperty<float> BustChance { get; }
	public IBindableProperty<bool> DiscoverDealer { get; }
	public IBindableProperty<int> WantedLevel { get; }

	public float[] GetBustChanceValues()
		=> new float[] { 0.05f, 0.1f, 0.15f, 0.2f, 0.25f, 0.3f, 0.35f, 0.4f, 0.45f, 0.5f };

	public int[] GetWantedLevelValues()
		=> new int[] { 1, 2, 3 };
}
