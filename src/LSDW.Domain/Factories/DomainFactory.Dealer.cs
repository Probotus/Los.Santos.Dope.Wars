using GTA;
using GTA.Math;

using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Interfaces.Services;
using LSDW.Domain.Models;
using LSDW.Domain.Statics;

namespace LSDW.Domain.Factories;

public static partial class DomainFactory
{
	/// <summary>
	/// Creates a new dealer instance.
	/// </summary>
	/// <param name="settings">The settings instance to use.</param>
	/// <param name="worldService">The world service instance to use.</param>
	/// <param name="position">The position of the dealer.</param>
	/// <returns>A new dealer instance.</returns>
	public static IDealer CreateDealer(ISettings settings, IWorldService worldService, Vector3 position)
	{
		Dealer dealer = new(settings, worldService);
		PedHash hash = GangStatics.GetPedHash();
		dealer.Initialize(hash, position);
		return dealer;
	}

	/// <summary>
	/// Creates a saved dealer instance.
	/// </summary>
	/// <param name="settings">The settings instance to use.</param>
	/// <param name="worldService">The world service instance to use.</param>
	/// <param name="hash">The ped hash of the dealer.</param>
	/// <param name="position">The position of the dealer.</param>
	/// <param name="name">The name of the dealer.</param>
	/// <param name="discovered">Has the dealer been discovered?</param>
	/// <param name="money">The money of the dealer.</param>
	/// <param name="drugs">The dealer drug collection.</param>
	/// <returns>A saved dealer instance.</returns>
	public static IDealer CreateDealer(ISettings settings, IWorldService worldService, PedHash hash, Vector3 position, string name, bool discovered, int money, IEnumerable<IDrug> drugs)
	{
		Dealer dealer = new(settings, worldService);
		dealer.Initialize(hash, position, name, discovered, money, drugs);
		return dealer;
	}
}
