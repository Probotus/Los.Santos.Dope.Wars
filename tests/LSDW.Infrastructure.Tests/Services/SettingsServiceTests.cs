﻿using LSDW.Abstractions.Infrastructure.Services;
using LSDW.Abstractions.Models;
using static LSDW.Infrastructure.Factories.InfrastructureFactory;

namespace LSDW.Infrastructure.Tests.Services;

[TestClass]
public partial class SettingsServiceTests
{
	private static readonly ISettingsService _settingsService = GetSettingsService();
	private static readonly string _iniFileName = Settings.IniFileName;

	[ClassCleanup]
	public static void ClassCleanup()
	{
		if (File.Exists(_iniFileName))
			File.Delete(_iniFileName);
	}
}