using System.Xml.Serialization;

using LSDW.Domain.Interfaces.Models;
using LSDW.Infrastructure.Factories;

namespace LSDW.Infrastructure.Models;

/// <summary>
/// The player state class.
/// </summary>
[XmlRoot("Player")]
public sealed class PlayerState
{
	/// <summary>
	/// Initializes a instance of the player state class.
	/// </summary>
	public PlayerState()
	{
		Exp = default;
		Drugs = Array.Empty<DrugState>();
		Transactions = Array.Empty<TransactionState>();
	}

	/// <summary>
	/// Initializes a instance of the player state class.
	/// </summary>
	/// <param name="player">The player instance to use.</param>
	public PlayerState(IPlayer player)
	{
		Exp = player.Exp;
		Drugs = InfrastructureFactory.CreateDrugStates(player.Drugs);
		Transactions = InfrastructureFactory.CreateTransactionStates(player.Transactions);
	}

	/// <summary>
	/// The player experience points.
	/// </summary>
	[XmlAttribute("Experience")]
	public int Exp { get; set; }

	/// <summary>
	/// The player drugs.
	/// </summary>
	[XmlArray("Drugs")]
	[XmlArrayItem("Drug")]
	public DrugState[] Drugs { get; set; }

	/// <summary>
	/// The player transactions.
	/// </summary>
	[XmlArray("Transactions")]
	[XmlArrayItem("Transaction")]
	public TransactionState[] Transactions { get; set; }
}
