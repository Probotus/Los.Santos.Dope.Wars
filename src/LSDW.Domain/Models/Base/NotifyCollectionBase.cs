using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

using LSDW.Domain.Interfaces.Models.Base;

namespace LSDW.Domain.Models.Base;

/// <summary>
/// The notify collection base class.
/// </summary>
public abstract class NotifyCollectionBase : NotifyPropertyBase, INotifyCollectionBase, INotifyPropertyBase
{
	/// <inheritdoc/>
	public event CollectionChangedEventHandler? CollectionChanged;

	/// <inheritdoc/>
	public event CollectionChangingEventHandler? CollectionChanging;

	/// <summary>
	/// Raises the <see cref="CollectionChanged"/> event.
	/// </summary>
	/// <param name="action">The action that causes the change.</param>
	protected void RaiseCollectionChanged(CollectionChangeAction action)
		=> CollectionChanged?.Invoke(this, new(action));

	/// <summary>
	/// Raises the <see cref="CollectionChanged"/> event.
	/// </summary>
	/// <typeparam name="T">The type to work with.</typeparam>
	/// <param name="action">The action that causes the change.</param>
	/// <param name="item">The item that is changed.</param>
	protected void RaiseCollectionChanged<T>(CollectionChangeAction action, T item)
		=> CollectionChanged?.Invoke(this, new CollectionChangedEventArgs<T>(action, item));

	/// <summary>
	/// Raises the <see cref="CollectionChanging"/> event.
	/// </summary>
	/// <param name="action">The action that causes the change.</param>
	protected void RaiseCollectionChanging(CollectionChangeAction action)
		=> CollectionChanging?.Invoke(this, new(action));

	/// <summary>
	/// Raises the <see cref="CollectionChanging"/> event.
	/// </summary>
	/// <typeparam name="T">The type to work with.</typeparam>
	/// <param name="action">The action that causes the change.</param>
	/// <param name="item">The item that is changing.</param>
	protected void RaiseCollectionChanging<T>(CollectionChangeAction action, T item)
		=> CollectionChanging?.Invoke(this, new CollectionChangingEventArgs<T>(action, item));
}

/// <summary>
/// The collection changed event args class.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="CollectionChangedEventArgs"/> class.
/// </remarks>
/// <param name="action">The action that causes the change.</param>
public class CollectionChangedEventArgs(CollectionChangeAction action) : EventArgs
{
	/// <summary>
	/// The action that causes the change.
	/// </summary>
	public CollectionChangeAction Action { get; } = action;
}

/// <summary>
/// The collection changed event args class.
/// </summary>
/// <typeparam name="T">The type to work with.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="CollectionChangedEventArgs{T}"/> class.
/// </remarks>
/// <param name="action">The action that causes the change.</param>
/// <param name="item">The item that is changed.</param>
public sealed class CollectionChangedEventArgs<T>(CollectionChangeAction action, T item) : CollectionChangedEventArgs(action)
{
	/// <summary>
	/// The item that is changed.
	/// </summary>
	public T Item { get; } = item;
}

/// <summary>
/// The collection changing event args class.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="CollectionChangingEventArgs"/> class.
/// </remarks>
/// <param name="action">The action that causes the change.</param>
public class CollectionChangingEventArgs(CollectionChangeAction action) : EventArgs
{
	/// <summary>
	/// The action that causes the change.
	/// </summary>
	public CollectionChangeAction Action { get; } = action;
}

/// <summary>
/// The collection changing event args class.
/// </summary>
/// <typeparam name="T">The type to work with.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="CollectionChangingEventArgs{T}"/> class.
/// </remarks>
/// <param name="action">The action that causes the change.</param>
/// <param name="item">The item that is changing.</param>
public sealed class CollectionChangingEventArgs<T>(CollectionChangeAction action, T item) : CollectionChangingEventArgs(action)
{
	/// <summary>
	/// The item that is changing.
	/// </summary>
	public T Item { get; } = item;
}

/// <summary>
/// Represents the method that will handle the event of the <see cref="INotifyCollectionChanged"/> interface.
/// </summary>
/// <param name="sender">The source of the event.</param>
/// <param name="e">The argument that contains the event data.</param>
[SuppressMessage("Naming", "CA1711", Justification = "Event Handler Naming Conventions")]
public delegate void CollectionChangedEventHandler(object? sender, CollectionChangedEventArgs e);

/// <summary>
/// Represents the method that will handle the event of the <see cref="INotifyCollectionChanging"/> interface.
/// </summary>
/// <param name="sender">The source of the event.</param>
/// <param name="e">The argument that contains the event data.</param>
[SuppressMessage("Naming", "CA1711", Justification = "Event Handler Naming Conventions")]
public delegate void CollectionChangingEventHandler(object? sender, CollectionChangingEventArgs e);
