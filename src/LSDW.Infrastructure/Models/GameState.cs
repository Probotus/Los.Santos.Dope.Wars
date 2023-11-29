using System.Xml.Serialization;

using LSDW.Domain.Interfaces.Models;
using LSDW.Infrastructure.Constants;
using LSDW.Infrastructure.Factories;

namespace LSDW.Infrastructure.Models;

/// <summary>
/// The game state class.
/// </summary>
[XmlRoot(nameof(LSDW), Namespace = XmlConstants.NameSpace)]
public sealed class GameState
{
	/// <summary>
	/// Initializes a instance of the game state class.
	/// </summary>
	public GameState()
	{
		Player = new();
		Dealers = [];
	}

	/// <summary>
	/// Initializes a instance of the game state class.
	/// </summary>
	/// <param name="player">The player instance to use.</param>
	/// <param name="dealers">The dealer collection instance to use.</param>
	public GameState(IPlayer player, IEnumerable<IDealer> dealers)
	{
		Player = InfrastructureFactory.CreatePlayerState(player);
		Dealers = InfrastructureFactory.CreateDealerStates(dealers);
	}

	/// <summary>
	/// The state of the player.
	/// </summary>	
	[XmlElement(XmlConstants.PlayerElementName)]
	public PlayerState Player { get; set; }

	/// <summary>
	/// The state of the dealer collection.
	/// </summary>
	[XmlArray(XmlConstants.DrugArrayName)]
	[XmlArrayItem(XmlConstants.DrugElementName)]
	public DealerState[] Dealers { get; set; }
}
