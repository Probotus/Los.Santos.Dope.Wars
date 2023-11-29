using LSDW.Application.Interfaces.Infrastructure.Services;
using LSDW.Domain.Interfaces.Models;

namespace LSDW.InfrastructureTests.Services;

[TestClass]
public partial class StateServiceTests : InfrastructureTestBase
{
	private static readonly string SaveFilePath = Path.Combine(AppContext.BaseDirectory, $"{nameof(LSDW)}.sav");
	private readonly IDealerCollection _dealers;
	private readonly IStateService _stateService;
	private readonly IPlayer _player;

	public StateServiceTests()
	{
		_dealers = GetService<IDealerCollection>();
		_stateService = GetService<IStateService>();
		_player = GetService<IPlayer>();
	}

	[ClassCleanup]
	public static void ClassCleanup()
	{
		if (File.Exists(SaveFilePath))
			File.Delete(SaveFilePath);
	}
}
