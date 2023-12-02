namespace LSDW.Domain.Attributes;

/// <summary>
/// The menu attribute class.
/// </summary>
/// <param name="description">The description of the menu.</param>
/// <param name="title">The title of the menu.</param>
/// <param name="subTitle">The sub title of the menu.</param>
[AttributeUsage(AttributeTargets.Field)]
internal sealed class MenuAttribute(string description, string title, string subTitle) : Attribute
{
	/// <summary>
	/// Initializes a instance of the menu attribute class.
	/// </summary>
	/// <param name="description">The description of the menu.</param>
	/// <param name="title">The title of the menu.</param>
	public MenuAttribute(string description, string title) : this(description, title, string.Empty)
	{ }

	/// <summary>
	/// The description of the menu.
	/// </summary>
	public string Description { get; } = description;

	/// <summary>
	/// The title of the menu.
	/// </summary>
	public string Title { get; } = title;

	/// <summary>
	/// The sub title of the menu.
	/// </summary>
	public string SubTitle { get; set; } = subTitle;
}
