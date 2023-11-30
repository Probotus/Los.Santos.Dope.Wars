using LSDW.Domain.Interfaces.Models.Base;

namespace LSDW.Domain.Models.Base;

/// <summary>
/// The bindable property class.
/// </summary>
/// <typeparam name="T">The value type to work with.</typeparam>
/// <remarks>
/// Initializes a instance of the bindable property class.
/// </remarks>
/// <param name="value">The value of the bindable property.</param>
public sealed class BindableProperty<T>(T value) : IBindableProperty<T> where T : IEquatable<T>
{
	private T _value = value;

	/// <inheritdoc/>
	public T Value
	{
		get => _value;
		set
		{
			if (!EqualityComparer<T>.Default.Equals(_value, value))
			{
				Changing?.Invoke(this, new BindablePropertyChangingEventArgs<T>(_value));
				_value = value;
				Changed?.Invoke(this, new BindablePropertyChangedEventArgs<T>(value));
			}
		}
	}

	/// <inheritdoc/>	
	public event EventHandler<BindablePropertyChangedEventArgs<T>>? Changed;

	/// <inheritdoc/>
	public event EventHandler<BindablePropertyChangingEventArgs<T>>? Changing;
}
