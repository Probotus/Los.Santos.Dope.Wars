namespace LSDW.Infrastructure.Statics;

/// <summary>
/// The file statics class.
/// </summary>
internal static class FileStatics
{
	/// <summary>
	/// The static constructor.
	/// </summary>
	static FileStatics()
	{
		BasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), nameof(LSDW));
		IniFileName = $"{nameof(LSDW)}.ini";
		LogFileName = $"{nameof(LSDW)}.log";
		SavFileName = $"{nameof(LSDW)}.sav";

		CreateDirectory();
	}

	/// <summary>
	/// The base path of the modification where all relevant things are saved.
	/// </summary>
	internal static string BasePath { get; }

	/// <summary>
	/// The name of the settings file.
	/// </summary>
	internal static string IniFileName { get; }

	/// <summary>
	/// The name of the log file.
	/// </summary>
	internal static string LogFileName { get; }

	/// <summary>
	/// The name of the savegame file.
	/// </summary>
	internal static string SavFileName { get; }

	private static void CreateDirectory()
		=> Directory.CreateDirectory(BasePath);
}
