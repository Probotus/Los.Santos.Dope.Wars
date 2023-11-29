using System.Xml.Serialization;

using LSDW.Domain.Enumerators;
using LSDW.Infrastructure.Constants;

namespace LSDW.Infrastructure.Models;

/// <summary>
/// The transaction state class.
/// </summary>
[XmlRoot(XmlConstants.TransactionElementName)]
public sealed class TransactionState
{
	/// <summary>
	/// Initializes a instance of the transaction state class.
	/// </summary>
	public TransactionState()
	{ }

	/// <summary>
	/// Initializes a instance of the transaction state class.
	/// </summary>
	/// <param name="type">The type of the transaction.</param>
	/// <param name="drugType">The drug type of the transaction.</param>
	/// <param name="quantity">The drug quantity of the transaction.</param>
	/// <param name="value">The drug value of the transaction.</param>
	public TransactionState(TransactionType type, DrugType drugType, int quantity, int value)
	{
		Type = type;
		DrugType = drugType;
		Quantity = quantity;
		Value = value;
	}

	/// <summary>
	/// The type of the transaction.
	/// </summary>
	[XmlAttribute("Type")]
	public TransactionType Type { get; set; }

	/// <summary>
	/// The drug type of the transaction.
	/// </summary>
	[XmlAttribute("DrugType")]
	public DrugType DrugType { get; set; }

	/// <summary>
	/// The drug quantity of the transaction.
	/// </summary>
	[XmlAttribute("Quantity")]
	public int Quantity { get; set; }

	/// <summary>
	/// The drug value of the transaction.
	/// </summary>
	[XmlAttribute("Value")]
	public int Value { get; set; }
}
