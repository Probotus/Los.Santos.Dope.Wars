using LSDW.Application.Interfaces.Application.Missions.Base;
using LSDW.Domain.Interfaces.Models;

namespace LSDW.Application.Interfaces.Application.Missions;

/// <summary>
/// The street trafficking mission interface.
/// </summary>
public interface IStreetTrafficking : IMissionBase, IMissionControl
{
	/// <summary>
	/// Discovers the drug dealers in the game world for the player.
	/// </summary>
	void Discover();

	/// <summary>
	/// Takes care of everything that needs to be done if a dealer is
	/// in the immediate vicinity of the player.
	/// </summary>
	void InProximity();

	/// <summary>
	/// Places the drug dealers in the game world and tracks them down
	/// for the player.
	/// </summary>
	void Track();
}
