﻿using GTA.UI;

using LSDW.Domain.Interfaces.Services;

namespace LSDW.Domain.Services;

/// <summary>
/// The notification service class.
/// </summary>
/// <remarks>
/// Wrapper for the <see cref="GTA.UI.Screen"/> and <see cref="Notification"/> methods.
/// </remarks>
[ExcludeFromCodeCoverage]
internal sealed class NotificationService : INotificationService
{
	public void Hide(int handle)
		=> Notification.Hide(handle);

	public int Show(string message, bool blinking = false)
		=> Notification.Show(message, blinking);

	public int Show(NotificationIcon icon, string sender, string subject, string message, bool fadeIn = false, bool blinking = false)
		=> Notification.Show(icon, sender, subject, message, fadeIn, blinking);

	public void Show(string sender, string subject, string message, bool blinking = false)
		=> Show(NotificationIcon.Default, sender, subject, message, false, blinking);

	public void Show(string subject, string message, bool blinking = false)
		=> Show("Anonymous", subject, message, blinking);

	public void ShowHelpText(string helpText, int duration = -1, bool beep = true, bool looped = false)
		=> GTA.UI.Screen.ShowHelpText(helpText, duration, beep, looped);

	public void ShowHelpTextThisFrame(string helpText)
		=> GTA.UI.Screen.ShowHelpTextThisFrame(helpText);

	public void ShowHelpTextThisFrame(string helpText, bool beep)
		=> GTA.UI.Screen.ShowHelpTextThisFrame(helpText, beep);

	public void ShowSubtitle(string message, int duration = 2500)
		=> GTA.UI.Screen.ShowSubtitle(message, duration);

	public void ShowSubtitle(string message, int duration, bool drawImmediately = true)
		=> GTA.UI.Screen.ShowSubtitle(message, duration, drawImmediately);
}