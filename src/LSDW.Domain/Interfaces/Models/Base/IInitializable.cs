namespace LSDW.Domain.Interfaces.Models.Base;

/// <summary>
/// The initializable interface.
/// </summary>
public interface IInitializable
{
	/// <summary>
	/// Is the object completely initialized?
	/// </summary>
	bool Initialized { get; }
}
