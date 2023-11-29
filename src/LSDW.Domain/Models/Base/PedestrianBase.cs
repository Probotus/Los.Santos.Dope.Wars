using GTA;
using GTA.Math;

using LSDW.Domain.Helpers;
using LSDW.Domain.Interfaces.Models.Base;
using LSDW.Domain.Interfaces.Services;
using LSDW.Domain.Statics;

namespace LSDW.Domain.Models.Base;

/// <summary>
/// The pedestrian base class.
/// </summary>
internal abstract class PedestrianBase : NotifyPropertyBase, IPedestrianBase
{
	/// <summary>
	/// Initializes a instance of the pedestrian base class.
	/// </summary>
	/// <param name="hash">The hash of the pedestrian.</param>
	/// <param name="name">The name of the pedestrian.</param>
	/// <param name="position">The position of the pedestrian.</param>
	protected PedestrianBase(PedHash hash, string name, Vector3 position)
	{
		Hash = hash;
		Name = name;
		Position = position;
	}

	public Blip? Blip { get; private set; }
	public Ped? Ped { get; private set; }
	public PedHash Hash { get; }
	public string Name { get; private set; }
	public Vector3 Position { get; }

	public void CleanUp()
	{
		Blip?.Delete();
		Ped?.Delete();
	}

	public virtual void Create(IWorldService worldProvider)
	{
		Model model = ScriptHookHelper.GetPedModel(Hash);

		while (Ped is null)
			Ped = worldProvider.CreatePed(model, Position);

		if (Name == string.Empty)
			Name = model.IsFemalePed ? NameStatics.GetFemaleName() : NameStatics.GetMaleName();

		model.MarkAsNoLongerNeeded();
	}

	public void CreateBlip(IWorldService worldProvider, BlipSprite sprite, BlipColor color)
	{
		Blip = worldProvider.CreateBlip(Position);
		Blip.Color = color;
		Blip.Sprite = sprite;
	}

	public void Delete()
		=> Ped?.Delete();
}
