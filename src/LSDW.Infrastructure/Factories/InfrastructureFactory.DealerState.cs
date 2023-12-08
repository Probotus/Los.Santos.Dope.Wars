using LSDW.Domain.Extensions;
using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Interfaces.Services;
using LSDW.Infrastructure.Models;

namespace LSDW.Infrastructure.Factories;

internal static partial class InfrastructureFactory
{
	/// <summary>
	/// Returns a new dealer state from a drug instance.
	/// </summary>
	/// <param name="dealer">The dealer instance to use.</param>
	/// <returns>The new dealer state.</returns>
	public static DealerState CreateDealerState(IDealer dealer)
		=> new(dealer);

	/// <summary>
	/// Returns a new dealer state array from a dealer collection instance.
	/// </summary>
	/// <param name="dealers">The dealer collection instance to use.</param>
	/// <returns>The new dealer state array.</returns>
	public static DealerState[] CreateDealerStates(IEnumerable<IDealer> dealers)
	{
		List<DealerState> states = [];
		dealers.ForEach(dealer => states.Add(CreateDealerState(dealer)));
		return [.. states];
	}

	/// <summary>
	/// Returns a new dealer instance from a drug state.
	/// </summary>
	/// <param name="settings">The settings instance to use.</param>
	/// <param name="worldService">The world service instance to use.</param>
	/// <param name="state">The dealer state to use.</param>
	/// <returns>The new dealer instance.</returns>
	public static IDealer CreateDealer(ISettings settings, IWorldService worldService, DealerState state)
		=> DomainFactory.CreateDealer(settings, worldService, state.Hash, state.Position, state.Name, state.Discovered, state.Money, CreateDrugs(state.Drugs));

	/// <summary>
	/// Returns a new dealer instance collection from a dealer state array.
	/// </summary>
	/// <param name="settings">The settings instance to use.</param>
	/// <param name="worldService">The world service instance to use.</param>
	/// <param name="states">The dealer state array to use.</param>
	/// <returns>The new dealer collection instance.</returns>
	public static IEnumerable<IDealer> CreateDealers(ISettings settings, IWorldService worldService, DealerState[] states)
	{
		List<IDealer> dealers = [];
		states.ForEach(state => dealers.Add(CreateDealer(settings, worldService, state)));
		return dealers;
	}
}
