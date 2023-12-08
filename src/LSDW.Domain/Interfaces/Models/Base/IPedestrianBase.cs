using GTA;
using GTA.Math;

namespace LSDW.Domain.Interfaces.Models.Base;

/// <summary>
/// The pedestrian base interface.
/// </summary>
public interface IPedestrianBase : INotifyPropertyBase, IInitializable
{
	/// <summary>
	/// The blip of the pedestrian.
	/// </summary>
	Blip? Blip { get; }

	/// <summary>
	/// The ped of the pedestrian.
	/// </summary>
	Ped? Ped { get; }

	/// <summary>
	/// The hash of the pedestrian.
	/// </summary>
	PedHash Hash { get; }

	/// <summary>
	/// The name of the pedestrian.
	/// </summary>
	string Name { get; }

	/// <summary>
	/// The position of the pedestrian.
	/// </summary>
	Vector3 Position { get; }

	/// <summary>
	/// Cleans up the pedestrian.
	/// </summary>
	/// <remarks>
	/// This deletes the <see cref="Blip"/> and the <see cref="Ped"/>.
	/// </remarks>
	void CleanUp();

	/// <summary>
	/// Creates the pedestrian.
	/// </summary>
	/// <remarks>
	/// This creates the <see cref="Ped"/>.
	/// </remarks>
	void Create();

	/// <summary>
	/// Creates a blip for the pedestrian.
	/// </summary>
	/// <param name="sprite">The blip sprite to use.</param>
	/// <param name="color">The blip color to use.</param>
	void CreateBlip(BlipSprite sprite, BlipColor color);

	/// <summary>
	/// Deletes the pedestrian.
	/// </summary>
	/// <remarks>
	/// This deletes the <see cref="Ped"/>.
	/// </remarks>
	void Delete();
}
