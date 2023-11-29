namespace LSDW.Domain.Attributes;

/// <summary>
/// The drug attribute class.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
internal sealed class DrugAttribute : Attribute
{
	private float _probability;
	private int _averageValue;

	/// <summary>
	/// Initializes a instance of the drug attribute class.
	/// </summary>
	/// <param name="name">The name of the drug.</param>
	/// <param name="description">The description of the drug.</param>
	internal DrugAttribute(string name, string description)
	{
		Name = name;
		Description = description;
	}

	/// <summary>
	/// The <see cref="Description"/> property is the description of the drug.
	/// </summary>
	public string Description { get; }

	/// <summary>
	/// The <see cref="Name"/> property is the name of the drug.
	/// </summary>
	public string Name { get; }

	/// <summary>
	/// The <see cref="AverageValue"/> property is the average value of the drug.
	/// </summary>
	/// <remarks>
	/// A value greater 0.
	/// </remarks>
	public int AverageValue
	{
		get => _averageValue;
		set => SetAveragePrice(value);
	}

	/// <summary>
	/// The availability probability property of a drug.
	/// </summary>
	/// <remarks>
	/// A value between 0 and 1.
	/// </remarks>
	public float Probability
	{
		get => _probability;
		set => SetProbability(value);
	}

	private void SetAveragePrice(int value)
	{
		if (value <= 0)
			throw new ArgumentOutOfRangeException(nameof(value), "The average value must be grater than 0.");

		_averageValue = value;
	}

	private void SetProbability(float value)
	{
		if (value is < 0 or > 1)
			throw new ArgumentOutOfRangeException(nameof(value), "The probability value must be between 0 and 1");

		_probability = value;
	}
}
