using LemonUI.Menus;

using LSDW.Application.Interfaces.Infrastructure.Services;
using LSDW.Application.Interfaces.Presentation.Menus;
using LSDW.Domain.Interfaces.Models;
using LSDW.Presentation.Menus.Base;

using RESX = LSDW.Presentation.Properties.Resources;

namespace LSDW.Presentation.Menus;

/// <summary>
/// The settings menu class.
/// </summary>
internal sealed partial class SettingsMenu : MenuBase, ISettingsMenu
{
	private readonly ISettings _settings;
	private readonly ISettingsService _settingsService;

	/// <summary>
	/// Initializes a new instance of the settings menu class.
	/// </summary>
	public SettingsMenu(ISettings settings, ISettingsService settingsService) : base(RESX.SettingsMenu_Title, RESX.SettingsMenu_SubTitle)
	{
		_settings = settings;
		_settingsService = settingsService;

		ItemCount = CountVisibility.Never;

		AddMenuItems();
	}
}
