using BB84.Extensions;

namespace LSDW.Savegame.Extractor;

internal class Program
{
	private static readonly string BasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), nameof(LSDW));
	private static readonly string SavFile = $"{nameof(LSDW)}.sav";
	private static readonly string XmlFile = $"{nameof(LSDW)}.xml";

	private static void Main()
	{
		try
		{
			FileInfo savFileInfo = new(Path.Combine(BasePath, SavFile));

			if (savFileInfo.Exists.Equals(false))
			{
				Console.WriteLine($"'{savFileInfo.FullName}' does not exist!");
				return;
			}

			byte[] fileContent = File.ReadAllBytes(savFileInfo.FullName).Decompress();

			string xmlFilePath = Path.Combine(Path.Combine(BasePath, XmlFile));

			File.WriteAllBytes(xmlFilePath, fileContent);

			Console.WriteLine($"Saved to '{xmlFilePath}'");
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
}
