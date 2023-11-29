using BB84.Extensions;

namespace LSDW.Savegame.Extractor;

internal class Program
{
	private static void Main(string[] args)
	{
		try
		{
			if (args.Length == 0)
			{
				Console.WriteLine("Please provide path to save file!");
				return;
			}

			FileInfo fileInfo = new(args[0]);

			if (!fileInfo.Exists)
			{
				Console.WriteLine($"{fileInfo.FullName} does not exist!");
				return;
			}

			byte[] fileContent = File.ReadAllBytes(fileInfo.FullName).Decompress();

			string filePath = Path.Combine(fileInfo.DirectoryName!, $"{nameof(LSDW)}.xml");

			File.WriteAllBytes(filePath, fileContent);

			Console.WriteLine($"Saved to '{filePath}'");
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
}
