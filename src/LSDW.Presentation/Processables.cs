using GTA;

using LSDW.Presentation.Menus.Base;

namespace LSDW.Presentation;
/// <summary>
/// The processables class.
/// </summary>
public sealed class Processables : Script
{
	/// <summary>
	/// Initializes a instance of the processables class.
	/// </summary>
	public Processables()
		=> Tick += (s, e) => MenuBase.Processables.Process();
}
