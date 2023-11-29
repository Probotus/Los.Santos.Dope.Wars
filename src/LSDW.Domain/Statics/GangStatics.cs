using GTA;

using LSDW.Domain.Extensions;

namespace LSDW.Domain.Statics;

/// <summary>
/// The gang statics class.
/// </summary>
internal static class GangStatics
{
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
	/// Returns a random weapon hash.
	/// </summary>
	/// <returns>The random weapon hash.</returns>
	public static WeaponHash GetWeaponHash()
		=> WeaponHashes.Value.RandomChoice();
}
