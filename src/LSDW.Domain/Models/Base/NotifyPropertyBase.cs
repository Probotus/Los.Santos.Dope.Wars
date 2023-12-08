using System.ComponentModel;
using System.Runtime.CompilerServices;

using LSDW.Domain.Interfaces.Models.Base;

namespace LSDW.Domain.Models.Base;

/// <summary>
/// The notify property base class.
/// </summary>
public abstract class NotifyPropertyBase : INotifyPropertyBase
{
	/// <inheritdoc/>
	public event PropertyChangingEventHandler? PropertyChanging;
	/// <inheritdoc/>
	public event PropertyChangedEventHandler? PropertyChanged;

	/// <summary>
	/// Sets a new value for a property and notifies about the change.
	/// </summary>
	/// <typeparam name="T">The type to work with.</typeparam>
	/// <param name="fieldValue">The referenced field.</param>
	/// <param name="newValue">The new value for the property.</param>
	/// <param name="propertyName">The name of the calling property.</param>
	protected void SetProperty<T>(ref T fieldValue, T newValue, [CallerMemberName] string propertyName = "")
	{
		if (!EqualityComparer<T>.Default.Equals(fieldValue, newValue))
		{
			RaisePropertyChanging(propertyName, fieldValue);
			fieldValue = newValue;
			RaisePropertyChanged(propertyName, newValue);
		}
	}

	/// <summary>
	/// Raises the <see cref="PropertyChanged"/> event.
	/// </summary>
	/// <param name="propertyName">The name of the property that changed.</param>
	/// <param name="value">The value of the property that changed.</param>
	protected void RaisePropertyChanged<T>(string propertyName, T value)
		=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs<T>(propertyName, value));

	/// <summary>
	/// Raises the <see cref="PropertyChanging"/> event.
	/// </summary>
	/// <param name="propertyName">The name of the property that is changing.</param>
	/// <param name="value">The value of the property that is changing.</param>
	protected void RaisePropertyChanging<T>(string propertyName, T value)
		=> PropertyChanging?.Invoke(this, new PropertyChangingEventArgs<T>(propertyName, value));
}

/// <summary>
/// Provides data for the <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
/// </summary>
/// <typeparam name="T">The type to work with.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="PropertyChangedEventArgs{T}"/> class.
/// </remarks>
/// <param name="propertyName">The name of the property that changed.</param>
/// <param name="value">The value of the property that changed.</param>
public sealed class PropertyChangedEventArgs<T>(string propertyName, T value) : PropertyChangedEventArgs(propertyName)
{
	/// <summary>
	/// The value of the property that changed.
	/// </summary>
	public T Value { get; } = value;
}

/// <summary>
/// Provides data for the <see cref="INotifyPropertyChanging.PropertyChanging"/> event.
/// </summary>
/// <typeparam name="T">The type to work with.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="PropertyChangingEventArgs{T}"/> class.
/// </remarks>
/// <param name="propertyName">The name of the property that is changing.</param>
/// <param name="value">The value of the property that is changing.</param>
public sealed class PropertyChangingEventArgs<T>(string propertyName, T value) : PropertyChangingEventArgs(propertyName)
{
	/// <summary>
	/// The value of the property that is changing.
	/// </summary>
	public T Value { get; } = value;
}
