namespace LSDW.Domain.Interfaces.Models.Base;

/// <summary>
/// The findable interface.
/// </summary>
public interface IFindable<T>
{
	/// <summary>
	/// Returns the found elements depending on the search expression.
	/// </summary>
	/// <param name="expression">The expression to search for.</param>
	/// <returns>Many or no result.</returns>
	IEnumerable<T> FindMany(Func<T, bool> expression);

	/// <summary>
	/// Returns the found element depending on the search expression.
	/// </summary>
	/// <param name="expression">The expression to search for.</param>
	/// <returns>One or no result.</returns>
	T Find(Func<T, bool> expression);
}
