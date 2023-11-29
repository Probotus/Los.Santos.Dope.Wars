using System.Xml.Serialization;

using LSDW.Domain.Enumerators;
using LSDW.Infrastructure.Constants;

namespace LSDW.Infrastructure.Models;

/// <summary>
/// The drug state class.
/// </summary>
[XmlRoot(XmlConstants.DrugElementName)]
public sealed class DrugState
{
	/// <summary>
	/// Initializes a instance of the drug state class.
	/// </summary>
	public DrugState()
	{ }

	/// <summary>
	/// Initializes a instance of the drug state class.
	/// </summary>
	/// <param name="type">The type of the drug.</param>
	/// <param name="quantity">The quantity of the drug.</param>
	/// <param name="value">The value of the drug.</param>
	public DrugState(DrugType type, int quantity, int value)
	{
		Type = type;
		Quantity = quantity;
		Value = value;
	}

	/// <summary>
	/// The type of the drug.
	/// </summary>
	[XmlAttribute("Type")]
	public DrugType Type { get; set; }

	/// <summary>
	/// The quantity of the drug.
	/// </summary>
	[XmlAttribute("Quantity")]
	public int Quantity { get; set; }

	/// <summary>
	/// The value of the drug.
	/// </summary>
	[XmlAttribute("Value")]
	public int Value { get; set; }

	/// <summary>
	/// Should the quantity be serialized?
	/// </summary>
	public bool ShouldSerializeQuantity() => Quantity != 0;

	/// <summary>
	/// Should the value be serialized?
	/// </summary>
	public bool ShouldSerializeValue() => Value != 0;
}
