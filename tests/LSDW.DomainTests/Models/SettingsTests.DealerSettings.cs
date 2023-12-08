using LSDW.Domain.Interfaces.Models;

namespace LSDW.DomainTests.Models;

public partial class SettingsTests
{
	[TestMethod]
	public void GetDownTimeInHoursValuesTest()
	{
		IDealerSettings settings = _settings.Dealer;

		int[] values = settings.GetDownTimeInHoursValues();

		Assert.IsNotNull(values);
		Assert.AreNotEqual(0, values.Length);
	}

	[TestMethod]
	public void GetMaxArmorValuesTest()
	{
		IDealerSettings settings = _settings.Dealer;

		int[] values = settings.GetMaxArmorValues();

		Assert.IsNotNull(values);
		Assert.AreNotEqual(0, values.Length);
	}

	[TestMethod]
	public void GetMaxHealthValuesTest()
	{
		IDealerSettings settings= _settings.Dealer;

		int[] values = settings.GetMaxHealthValues();

		Assert.IsNotNull(values);
		Assert.AreNotEqual(0, values.Length);
	}
}
