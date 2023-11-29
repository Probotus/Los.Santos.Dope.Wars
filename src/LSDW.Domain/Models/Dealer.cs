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
	private const int Accuracy = 5;
	private const int Armor = 125;
	private const int MaxHealth = 150;
	private const float BlipScale = 0.75f;

	private bool _discovered;
	private int _money;

	/// <summary>
	/// Initializes a instance of the dealer class.
	/// </summary>
	/// <param name="position">The position of the dealer.</param>
	/// <param name="zone">The zone of the dealer.</param>
	internal Dealer(Vector3 position, string zone) : base(GangStatics.GetPedHash(), string.Empty, position)
	{
		Zone = zone;
		Drugs = new DrugCollection();

		PropertyChanged += (s, e) => OnPropertyChanged(e.PropertyName);
	}

	/// <summary>
	/// Initializes a instance of the dealer class.
	/// </summary>
	/// <param name="discovered">Has the dealer been discovered?</param>
	/// <param name="hash">The ped hash of the dealer.</param>
	/// <param name="name">The name of the dealer.</param>
	/// <param name="money">The money of the dealer.</param>
	/// <param name="position">The position of the dealer.</param>
	/// <param name="zone">The zone of the dealer.</param>
	/// <param name="drugs">The dealer drug collection.</param>
	internal Dealer(bool discovered, PedHash hash, string name, int money, Vector3 position, string zone, IEnumerable<IDrug> drugs) : base(hash, name, position)
	{
		Discovered = discovered;
		Money = money;
		Zone = zone;
		Drugs = new DrugCollection();
		Load(drugs);

		PropertyChanged += (s, e) => OnPropertyChanged(e.PropertyName);
	}

	public bool Discovered { get => _discovered; private set => SetProperty(ref _discovered, value); }
	public string Zone { get; }
	public IDrugCollection Drugs { get; }
	public int Money { get => _money; set => SetProperty(ref _money, value); }

	public override void Create(IWorldService worldProvider)
	{
		base.Create(worldProvider);

		if (Ped is null)
			return;

		Ped.Accuracy = Accuracy;
		Ped.Armor = Armor;
		Ped.MaxHealth = MaxHealth;
		Ped.Money = Money;
		Ped.Weapons.Give(GangStatics.GetWeaponHash(), 1000, true, true);
	}

	public void Discover(IWorldService worldProvider)
	{
		CreateBlip(worldProvider, BlipSprite.Drugs, BlipColor.White);

		if (Blip is null)
			return;

		Blip.Scale = BlipScale;
		Blip.IsShortRange = true;
		Discovered = true;
	}

	public void Load(IEnumerable<IDrug> values)
		=> Drugs.Load(values);

	private void OnPropertyChanged(string propertyName)
	{
		if (propertyName == nameof(Money))
		{
			if (Ped is not null)
				Ped.Money = Money;
		}
	}
}
