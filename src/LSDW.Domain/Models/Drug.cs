using LSDW.Domain.Enumerators;
using LSDW.Domain.Extensions;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Models.Base;

namespace LSDW.Domain.Models;

/// <summary>
/// The drug class.
/// </summary>
internal sealed class Drug : NotifyPropertyBase, IDrug
{
	private int _quantity;
	private int _value;

	/// <summary>
	/// Initializes a instance of the drug class.
	/// </summary>
	/// <param name="type">The type of the drug.</param>
	/// <param name="quantity">The quantity of the drug.</param>
	/// <param name="value">The current value of the drug.</param>
	internal Drug(DrugType type, int? quantity = null, int? value = null)
	{
		Type = type;
		_quantity = quantity ?? default;
		_value = value ?? default;
	}

	public DrugType Type { get; }
	public string Name => Type.GetName();
	public string Description => Type.GetDescription();
	public int Quantity { get => _quantity; private set => SetProperty(ref _quantity, value); }
	public int Value { get => _value; private set => SetProperty(ref _value, value); }
	public int AverageValue => Type.GetAverageValue();
	public int TotalValue => Quantity * Value;
	public float Probability => Type.GetProbability();

	public void Add(int quantity, int value)
	{
		if (quantity < 1)
			throw new ArgumentOutOfRangeException(nameof(quantity), "Can't be smaller one.");

		if (value < 0)
			throw new ArgumentOutOfRangeException(nameof(value), "Can't be smaller zero.");

		Value = ((Value * Quantity) + (value * quantity)) / (Quantity + quantity);
		Quantity += quantity;
	}

	public void SetValues(int quantity, int value)
	{
		if (quantity < 0)
			throw new ArgumentOutOfRangeException(nameof(quantity), "Can't be smaller than zero.");

		if (value < 0)
			throw new ArgumentOutOfRangeException(nameof(value), "Can't be smaller than zero.");

		Quantity = quantity;
		Value = value;
	}

	public void Remove(int quantity)
	{
		if (quantity < 1)
			throw new ArgumentOutOfRangeException(nameof(quantity), "Can't be smaller than one.");

		if (Quantity - quantity < 0)
			throw new ArgumentOutOfRangeException(nameof(quantity), "The resulting quantity can't be lower zero.");

		Quantity -= quantity;
	}
}
