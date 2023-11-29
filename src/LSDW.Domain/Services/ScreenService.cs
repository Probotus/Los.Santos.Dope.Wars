using GTA.UI;

using LSDW.Domain.Interfaces.Services;

namespace LSDW.Domain.Services;

/// <summary>
/// The screen service class.
/// </summary>
/// <remarks>
/// Wrapper for the <see cref="GTA.UI.Screen"/> methods and properties.
/// </remarks>
[ExcludeFromCodeCoverage]
internal sealed class ScreenService : IScreenService
{
	public float Width => GTA.UI.Screen.Width;
	public float Height => GTA.UI.Screen.Height;
	public Size Resolution => GTA.UI.Screen.Resolution;
	public float AspectRatio => GTA.UI.Screen.AspectRatio;
	public float ScaledWidth => GTA.UI.Screen.ScaledWidth;
	public bool IsFadedIn => GTA.UI.Screen.IsFadedIn;
	public bool IsFadedOut => GTA.UI.Screen.IsFadedOut;
	public bool IsFadingIn => GTA.UI.Screen.IsFadingIn;
	public bool IsFadingOut => GTA.UI.Screen.IsFadingOut;
	public bool AreScreenKillEffectsEnabled => GTA.UI.Screen.AreScreenKillEffectsEnabled;
	public bool IsHelpTextDisplayed => GTA.UI.Screen.IsHelpTextDisplayed;

	public void FadeIn(int time)
		=> GTA.UI.Screen.FadeIn(time);

	public void FadeOut(int time)
		=> GTA.UI.Screen.FadeOut(time);

	public bool IsEffectActive(ScreenEffect effectName)
		=> GTA.UI.Screen.IsEffectActive(effectName);

	public void StartEffect(ScreenEffect effectName, int duration = 0, bool looped = false)
		=> GTA.UI.Screen.StartEffect(effectName, duration, looped);

	public void StopEffect(ScreenEffect effectName)
		=> GTA.UI.Screen.StopEffect(effectName);

	public void StopEffects()
		=> GTA.UI.Screen.StopEffects();
}
