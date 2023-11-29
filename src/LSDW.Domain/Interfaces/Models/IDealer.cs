using LSDW.Domain.Interfaces.Models.Base;
using LSDW.Domain.Interfaces.Services;

namespace LSDW.Domain.Interfaces.Models;

/// <summary>
/// The dealer interface.
/// </summary>
public interface IDealer : IPedestrianBase, ILoadable<IDrug>
{
	/// <summary>
	/// Has the dealer been discovered?
	/// </summary>
	bool Discovered { get; }

	/// <summary>
	/// The zone of the dealer.
	/// </summary>
	string Zone { get; }

	/// <summary>
	/// The dealer drug collection.
	/// </summary>
	IDrugCollection Drugs { get; }

	/// <summary>
	/// The money the dealer can use for trading.
	/// </summary>
	int Money { get; set; }

	/// <summary>
	/// Discovers the dealer.
	/// </summary>
	/// <remarks>
	/// This creates the <see cref="IPedestrianBase.Blip"/>.
	/// </remarks>
	/// <param name="worldProvider">The world provider to use.</param>
	void Discover(IWorldService worldProvider);
}
