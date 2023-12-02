using LSDW.Domain.Interfaces.Models;

namespace LSDW.DomainTests.Models;

public partial class SettingsTests
{
	[TestMethod]
	public void GetMaximumDrugPriceValuesTest()
	{
		IMarketSettings settings = _settings.Market;

		float[] values = settings.GetMaximumDrugPriceValues();

		Assert.IsNotNull(values);
		Assert.AreNotEqual(0, values.Length);
	}

	[TestMethod]
	public void GetMinimumDrugPriceValuesTest()
	{
		IMarketSettings settings = _settings.Market;

		float[] values = settings.GetMinimumDrugPriceValues();

		Assert.IsNotNull(values);
		Assert.AreNotEqual(0, values.Length);
	}

	[TestMethod]
	public void GetRefreshIntervalValuesTest()
	{
		IMarketSettings settings = _settings.Market;

		int[] values = settings.GetRefreshIntervalValues();

		Assert.IsNotNull(values);
		Assert.AreNotEqual(0, values.Length);
	}

	[TestMethod]
	public void GetRestockIntervalValuesTest()
	{
		IMarketSettings settings = _settings.Market;

		int[] values = settings.GetRestockIntervalValues();

		Assert.IsNotNull(values);
		Assert.AreNotEqual(0, values.Length);
	}

	[TestMethod]
	public void GetSpecialOfferChanceValuesTest()
	{
		IMarketSettings settings = _settings.Market;

		float[] values = settings.GetSpecialOfferChanceValues();

		Assert.IsNotNull(values);
		Assert.AreNotEqual(0, values.Length);
	}
}
