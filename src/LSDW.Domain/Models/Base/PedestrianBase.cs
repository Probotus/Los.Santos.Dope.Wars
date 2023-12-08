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
	private readonly IWorldService _worldService;

	/// <summary>
	/// Initializes a instance of the pedestrian base class.
	/// </summary>
	/// <param name="worldService">The world service instance to use.</param>
	protected PedestrianBase(IWorldService worldService)
		=> _worldService = worldService;

	public Blip? Blip { get; private set; }
	public Ped? Ped { get; private set; }
	public PedHash Hash { get; private set; }
	public string Name { get; private set; } = string.Empty;
	public Vector3 Position { get; private set; }
	public bool Initialized { get; private set; }

	public void CleanUp()
	{
		Blip?.Delete();
		Ped?.Delete();
	}

	public virtual void Create()
	{
		if (Initialized.Equals(false))
			throw new InvalidOperationException($"{nameof(Initialized)}={Initialized}");

		Model model = ScriptHookHelper.GetPedModel(Hash);

		while (Ped is null)
			Ped = _worldService.CreatePed(model, Position);

		if (Name == string.Empty)
			Name = model.IsFemalePed ? NameStatics.GetFemaleName() : NameStatics.GetMaleName();

		model.MarkAsNoLongerNeeded();
	}

	public void CreateBlip(BlipSprite sprite, BlipColor color)
	{
		if (Initialized.Equals(false))
			throw new InvalidOperationException($"{nameof(Initialized)}={Initialized}");

		Blip = _worldService.CreateBlip(Position);
		Blip.Color = color;
		Blip.Sprite = sprite;
	}

	public void Delete()
		=> Ped?.Delete();

	/// <summary>
	/// Initializes the pedestrian object completely.
	/// </summary>
	/// <param name="hash">The hash of the pedestrian.</param>	
	/// <param name="position">The position of the pedestrian.</param>
	/// <param name="name">The name of the pedestrian.</param>
	public void Initialize(PedHash hash, Vector3 position, string name = "")
	{
		Hash = hash;
		Position = position;
		Name = name;
		Initialized = true;
	}
}
