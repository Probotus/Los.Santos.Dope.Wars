using LSDW.Domain.Models.Base;

namespace LSDW.Domain.Interfaces.Models.Base;

/// <summary>
/// The notify collection base interface.
/// </summary>
public interface INotifyCollectionBase : INotifyPropertyBase, INotifyCollectionChanged, INotifyCollectionChanging
{ }

/// <summary>
/// The notify collection changed interface.
/// </summary>
public interface INotifyCollectionChanged
{
	/// <summary>
	/// Occurs when the collection is changed.
	/// </summary>
	event CollectionChangedEventHandler? CollectionChanged;
}

/// <summary>
/// The notify collection changing interface.
/// </summary>
public interface INotifyCollectionChanging
{
	/// <summary>
	/// Occurs when the collection is changing.
	/// </summary>
	event CollectionChangingEventHandler? CollectionChanging;
}
