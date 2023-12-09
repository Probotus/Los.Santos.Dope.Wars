using GTA;

using LSDW.Domain.Enumerators;
using LSDW.Domain.Extensions;

namespace LSDW.Domain.Statics;

/// <summary>
/// The gang statics class.
/// </summary>
internal static class GangStatics
{
	private static readonly Lazy<PedHash[]> Armenian = new(() => new PedHash[] { PedHash.ArmGoon01GMM, PedHash.ArmGoon02GMY });
	private static readonly Lazy<PedHash[]> Aztecas = new(() => new PedHash[] { PedHash.Azteca01GMY });
	private static readonly Lazy<PedHash[]> Ballas = new(() => new PedHash[] { PedHash.BallaEast01GMY, PedHash.BallaOrig01GMY, PedHash.Ballas01GFY, PedHash.BallaSout01GMY });
	private static readonly Lazy<PedHash[]> Families = new(() => new PedHash[] { PedHash.Famca01GMY, PedHash.Famdd01, PedHash.Famdnf01GMY, PedHash.Famfor01GMY, PedHash.Families01GFY });
	private static readonly Lazy<PedHash[]> Korean = new(() => new PedHash[] { PedHash.Korean01GMY, PedHash.Korean02GMY });
	private static readonly Lazy<PedHash[]> Lost = new(() => new PedHash[] { PedHash.Lost01GFY, PedHash.Lost01GMY, PedHash.Lost02GMY, PedHash.Lost03GMY });
	private static readonly Lazy<PedHash[]> Mexican = new(() => new PedHash[] { PedHash.MexGang01GMY, PedHash.MexGoon01GMY, PedHash.MexGoon02GMY, PedHash.MexGoon03GMY });
	private static readonly Lazy<PedHash[]> Polynesian = new(() => new PedHash[] { PedHash.PoloGoon01GMY, PedHash.PoloGoon02GMY });
	private static readonly Lazy<PedHash[]> Triad = new(() => new PedHash[] { PedHash.ChiGoon01GMM, PedHash.ChiGoon02GMM });
	private static readonly Lazy<PedHash[]> Salvador = new(() => new PedHash[] { PedHash.SalvaGoon01GMY, PedHash.SalvaGoon02GMY, PedHash.SalvaGoon03GMY });

	private static readonly Lazy<PedHash[]> PedHashes = new(() => new PedHash[]
	{
		PedHash.Families01GFY, PedHash.Famfor01GMY, PedHash.Famdnf01GMY, PedHash.Famca01GMY,
		PedHash.Ballas01GFY, PedHash.BallaEast01GMY, PedHash.BallaOrig01GMY, PedHash.BallaSout01GMY,
		PedHash.Vagos01GFY, PedHash.SalvaGoon02GMY, PedHash.SalvaGoon01GMY, PedHash.SalvaGoon03GMY,
		PedHash.Lost01GFY, PedHash.Lost01GMY, PedHash.Lost02GMY, PedHash.Lost03GMY,
		PedHash.PoloGoon01GMY, PedHash.PoloGoon02GMY, PedHash.Polynesian01AMY, PedHash.Polynesian01AMM,
		PedHash.MexGoon01GMY, PedHash.MexGoon02GMY, PedHash.MexGoon03GMY, PedHash.MexGang01GMY,
		PedHash.Korean01GMY, PedHash.Korean02GMY, PedHash.ArmGoon01GMM, PedHash.ArmGoon02GMY,
		PedHash.ChiGoon01GMM, PedHash.ChiGoon02GMM
	});

	private static readonly Lazy<WeaponHash[]> WeaponHashes = new(() => new WeaponHash[]
	{
		WeaponHash.Pistol, WeaponHash.CombatPistol, WeaponHash.MicroSMG, WeaponHash.SMG,
		WeaponHash.PumpShotgun, WeaponHash.SawnOffShotgun, WeaponHash.AssaultRifle,
		WeaponHash.CarbineRifle
	});

	/// <summary>
	/// Returns a random ped hash.
	/// </summary>
	/// <returns>The random ped hash.</returns>
	public static PedHash GetPedHash()
		=> PedHashes.Value.RandomChoice();

	/// <summary>
	/// Returns a random ped hash for a specific gang.
	/// </summary>
	/// <param name="type">The gang to work with.</param>
	/// <returns>The random gang ped hash.</returns>
	public static PedHash GetPedHash(GangType type) => type switch
	{
		GangType.Armenian => Armenian.Value.RandomChoice(),
		GangType.Aztecas => Aztecas.Value.RandomChoice(),
		GangType.Ballas => Ballas.Value.RandomChoice(),
		GangType.Families => Families.Value.RandomChoice(),
		GangType.Korean => Korean.Value.RandomChoice(),
		GangType.Triad => Triad.Value.RandomChoice(),
		GangType.Lost => Lost.Value.RandomChoice(),
		GangType.Mexican => Mexican.Value.RandomChoice(),
		GangType.Polynesian => Polynesian.Value.RandomChoice(),
		GangType.Salvador => Salvador.Value.RandomChoice(),
		_ => PedHash.Dealer01SMY,
	};

	/// <summary>
	/// Returns a random weapon hash.
	/// </summary>
	/// <returns>The random weapon hash.</returns>
	public static WeaponHash GetWeaponHash()
		=> WeaponHashes.Value.RandomChoice();
}
