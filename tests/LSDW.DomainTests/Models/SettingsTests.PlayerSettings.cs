using LSDW.Domain.Interfaces.Models;

namespace LSDW.DomainTests.Models;

public partial class SettingsTests
{
	[TestMethod]
	public void GetExperienceMultiplierValuesTest()
	{
		IPlayerSettings settings = _settings.Player;

		float[] values = settings.GetExperienceMultiplierValues();

		Assert.IsNotNull(values);
		Assert.AreNotEqual(0, values.Length);
	}

	[TestMethod]
	public void GetBagSizePerLevelValuesTest()
	{
		IPlayerSettings settings = _settings.Player;

		int[] values = settings.GetBagSizePerLevelValues();

		Assert.IsNotNull(values);
		Assert.AreNotEqual(0, values.Length);
	}
}
