using GTA;
using GTA.Math;

using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Interfaces.Services;
using LSDW.Domain.Models.Base;
using LSDW.Domain.Statics;

namespace LSDW.Domain.Models;

/// <summary>
/// The dealer class.
/// </summary>
internal sealed class Dealer : PedestrianBase, IDealer
{
	private readonly IDealerSettings _settings;
	private readonly IWorldService _worldService;

	private const int Accuracy = 5;
	private const float BlipScale = 0.75f;

	private bool _discovered;
	private int _money;

	/// <summary>
	/// Initializes a instance of the dealer class.
	/// </summary>
	/// <param name="settings">The settings instance to use.</param>
	/// <param name="worldService">The world service instance to use.</param>
	public Dealer(ISettings settings, IWorldService worldService) : base(worldService)
	{
		_settings = settings.Dealer;
		_worldService = worldService;

		Drugs = new DrugCollection();
		PropertyChanged += (s, e) => OnPropertyChanged(e.PropertyName);
	}

	public bool Discovered { get => _discovered; private set => SetProperty(ref _discovered, value); }
	public IDrugCollection Drugs { get; private set; }
	public int Money { get => _money; set => SetProperty(ref _money, value); }
	public string Zone { get; private set; } = string.Empty;

	public override void Create()
	{
		base.Create();

		if (Ped is not null)
		{
			Ped.Accuracy = Accuracy;
			Ped.MaxHealth = _settings.MaxHealth.Value;
			Ped.Money = Money;

			if (_settings.HasArmor.Value)
				Ped.Armor = _settings.MaxArmor.Value;

			if (_settings.HasWeapons.Value)
				Ped.Weapons.Give(GangStatics.GetWeaponHash(), 1000, true, true);
		}
	}

	public void Discover()
	{
		CreateBlip(BlipSprite.Drugs, BlipColor.White);

		if (Blip is not null)
		{
			Blip.Scale = BlipScale;
			Blip.IsShortRange = true;
		}

		Discovered = true;
	}

	public void Load(IEnumerable<IDrug> values)
		=> Drugs.Load(values);

	/// <summary>
	/// Initializes the dealer object completely.
	/// </summary>
	/// <param name="hash">The ped hash of the dealer.</param>
	/// <param name="position">The position of the dealer.</param>
	/// <param name="name">The name of the dealer.</param>
	/// <param name="discovered">Has the dealer been discovered?</param>
	/// <param name="money">The money of the dealer.</param>
	/// <param name="drugs">The dealer drug collection.</param>
	public void Initialize(PedHash hash, Vector3 position, string name, bool discovered, int money, IEnumerable<IDrug> drugs)
	{
		Initialize(hash, position, name);

		Discovered = discovered;
		Money = money;
		Zone = _worldService.GetZoneDisplayName(position);

		Load(drugs);
	}

	private void OnPropertyChanged(string propertyName)
	{
		if (propertyName == nameof(Money))
		{
			if (Ped is not null)
				Ped.Money = Money;
		}
	}
}
