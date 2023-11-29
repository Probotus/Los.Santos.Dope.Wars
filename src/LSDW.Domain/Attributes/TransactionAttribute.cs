namespace LSDW.Domain.Attributes;

/// <summary>
/// The transaction attribute class.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
internal sealed class TransactionAttribute : Attribute
{
	/// <summary>
	/// Initializes a instance of the transaction attribute class.
	/// </summary>
	/// <param name="description">The description of the transaction.</param>
	/// <param name="title">The title of the transaction.</param>
	/// <param name="subTitle">The sub title of the transaction.</param>
	public TransactionAttribute(string description, string title, string subTitle)
	{
		Description = description;
		Title = title;
		SubTitle = subTitle;
	}

	/// <summary>
	/// The description of the transaction.
	/// </summary>
	public string Description { get; }

	/// <summary>
	/// The title of the transaction.
	/// </summary>
	public string Title { get; }

	/// <summary>
	/// The sub title of the transaction.
	/// </summary>
	public string SubTitle { get; }
}
