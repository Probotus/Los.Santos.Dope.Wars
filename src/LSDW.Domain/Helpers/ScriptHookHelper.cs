using GTA;

namespace LSDW.Domain.Helpers;

/// <summary>
/// The script hook helper class.
/// </summary>
[ExcludeFromCodeCoverage]
public static class ScriptHookHelper
{
	/// <summary>
	/// Returns the requested <see cref="Ped"/> <see cref="Model"/>.
	/// </summary>
	/// <param name="pedHash">The ped hash parameter.</param>
	public static Model GetPedModel(PedHash pedHash)
		=> new Model(pedHash).RequestModel();

	/// <summary>
	/// Returns the requested <see cref="Vehicle"/> <see cref="Model"/>.
	/// </summary>
	/// <param name="vehicleHash">The vehicle hash parameter.</param>
	public static Model GetVehicleModel(VehicleHash vehicleHash)
		=> new Model(vehicleHash).RequestModel();

	/// <summary>
	/// Returns the requested <see cref="Weapon"/> <see cref="Model"/>.
	/// </summary>
	/// <param name="weaponHash">The weapon hash parameter.</param>
	public static Model GetWeaponModel(WeaponHash weaponHash)
		=> new Model(weaponHash).RequestModel();

	/// <summary>
	/// Attempts to load this <see cref="Model"/> into memory for a given period of time.
	/// </summary>
	/// <param name="model">The model to load into memory.</param>
	private static Model RequestModel(this Model model)
	{
		model.Request();
		while (!model.IsLoaded)
			Script.Wait(0);
		return model;
	}
}
