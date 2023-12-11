using System.Xml.Serialization;

using GTA;
using GTA.Math;

using LSDW.Domain.Interfaces.Models;
using LSDW.Infrastructure.Constants;
using LSDW.Infrastructure.Factories;

namespace LSDW.Infrastructure.Models;

/// <summary>
/// The dealer state class.
/// </summary>
[XmlRoot(XmlConstants.DealerElementName)]
public sealed class DealerState
{
	/// <summary>
	/// Initializes a instance of the dealer state class.
	/// </summary>
	public DealerState()
	{
		Name = string.Empty;
		Drugs = [];
	}

	/// <summary>
	/// Initializes a instance of the dealer state class.
	/// </summary>
	/// <param name="dealer">The dealer instance to use.</param>
	public DealerState(IDealer dealer)
	{
		Discovered = dealer.Discovered;
		Hash = dealer.Hash;
		Name = dealer.Name;
		Money = dealer.Money;
		Position = dealer.Position;
		Drugs = InfrastructureFactory.CreateDrugStates(dealer.Drugs);
	}

	/// <summary>
	/// Has the dealer been discovered?
	/// </summary>
	[XmlAttribute("Discovered")]
	public bool Discovered { get; set; }

	/// <summary>
	/// Should the discovered property be serialized?
	/// </summary>
	public bool ShouldSerializeDiscovered() => Discovered is not false;

	/// <summary>
	/// The ped hash of the dealer.
	/// </summary>
	[XmlAttribute("Hash")]
	public PedHash Hash { get; set; }

	/// <summary>
	/// The name of the dealer.
	/// </summary>
	[XmlAttribute("Name")]
	public string Name { get; set; }

	/// <summary>
	/// Should the name property be serialized?
	/// </summary>
	public bool ShouldSerializeName() => Name != string.Empty;

	/// <summary>
	/// The money the dealer can use for trading.
	/// </summary>
	[XmlAttribute("Money")]
	public int Money { get; set; }

	/// <summary>
	/// Should the money property be serialized?
	/// </summary>
	public bool ShouldSerializeMoney() => Money != default;

	/// <summary>
	/// The position of the dealer.
	/// </summary>
	[XmlElement("Position")]
	public Vector3 Position { get; set; }

	/// <summary>
	/// The dealer drugs.
	/// </summary>
	[XmlArray("Drugs")]
	[XmlArrayItem("Drug")]
	public DrugState[] Drugs { get; set; }
}
