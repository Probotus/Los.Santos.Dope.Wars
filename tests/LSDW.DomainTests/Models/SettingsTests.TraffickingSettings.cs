using LSDW.Domain.Interfaces.Models;

namespace LSDW.DomainTests.Models;

public partial class SettingsTests
{
	[TestMethod]
	public void GetBustChanceValuesTest()
	{
		ITraffickingSettings settings = _settings.Trafficking;

		float[] values = settings.GetBustChanceValues();

		Assert.IsNotNull(values);
		Assert.AreNotEqual(0, values.Length);
	}

	[TestMethod]
	public void GetWantedLevelValuesTest()
	{
		ITraffickingSettings settings = _settings.Trafficking;

		int[] values = settings.GetWantedLevelValues();

		Assert.IsNotNull(values);
		Assert.AreNotEqual(0, values.Length);
	}
}
