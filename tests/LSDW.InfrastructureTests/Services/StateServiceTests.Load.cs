namespace LSDW.InfrastructureTests.Services;
public partial class StateServiceTests
{
	[TestMethod]
	public void LoadTest()
		=> _stateService.Load();

	[TestMethod]
	public void LoadNoSaveTest()
		=> _stateService.Load();
}
