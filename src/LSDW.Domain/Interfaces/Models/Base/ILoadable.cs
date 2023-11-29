namespace LSDW.Domain.Interfaces.Models.Base;

/// <summary>
/// The loadable interface.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ILoadable<T>
{
	/// <summary>
	/// Loads the <paramref name="values"/> into the collection.
	/// </summary>
	/// <param name="values">The values to load.</param>
	void Load(IEnumerable<T> values);
}
