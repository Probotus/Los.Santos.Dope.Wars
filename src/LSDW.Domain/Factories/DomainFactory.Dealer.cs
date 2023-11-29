using GTA;
using GTA.Math;

using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Models;

namespace LSDW.Domain.Factories;

public static partial class DomainFactory
{
	/// <summary>
	/// Returns a new dealer instance.
	/// </summary>
	/// <param name="position">The position of the dealer.</param>
	/// <param name="zone">The zone of the dealer.</param>
	/// <returns>A new dealer instance.</returns>
	public static IDealer CreateDealer(Vector3 position, string zone)
		=> new Dealer(position, zone);

	/// <summary>
	/// Returns a new dealer instance.
	/// </summary>
	/// <param name="discovered">Has the dealer been discovered?</param>
	/// <param name="hash">The ped hash of the dealer.</param>
	/// <param name="name">The name of the dealer.</param>
	/// <param name="money">The money of the dealer.</param>
	/// <param name="position">The position of the dealer.</param>
	/// <param name="zone">The zone of the dealer.</param>
	/// <param name="drugs">The dealer drug collection.</param>
	/// <returns>A new dealer instance.</returns>
	public static IDealer CreateDealer(bool discovered, PedHash hash, string name, int money, Vector3 position, string zone, IEnumerable<IDrug> drugs)
		=> new Dealer(discovered, hash, name, money, position, zone, drugs);
}
