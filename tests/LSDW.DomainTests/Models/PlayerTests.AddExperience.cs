using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Models;

namespace LSDW.DomainTests.Models;

public sealed partial class PlayerTests
{
	[TestMethod]
	public void AddExperience()
	{
		Player player = new(_settings);
		_settings.Player.ExperienceMultiplier.Value = 1.0f;

		player.AddExperience(1000);

		Assert.AreEqual(1, player.Level);
		Assert.AreEqual(50, player.BagSize);
		Assert.AreEqual(2000, player.Exp);
		Assert.AreEqual(8000, player.ExpForNextLevel);
	}

	[TestMethod]
	[ExpectedException(typeof(ArgumentOutOfRangeException))]
	public void AddExperienceException()
	{
		Player player = new(_settings);
		
		player.AddExperience(0);
	}

	[TestMethod]
	public void AddExperienceMaximumLevel()
	{
		Player player = new(_settings);
		_settings.Player.ExperienceMultiplier.Value = 1.0f;
		
		player.AddExperience(999999900);

		player.AddExperience(1);

		Assert.AreEqual(100, player.Level);
		Assert.AreEqual(5000, player.BagSize);
		Assert.AreEqual(1000000000, player.Exp);
	}

	[TestMethod]
	public void AddExperienceMultiplier()
	{		
		Player player = new(_settings);
		_settings.Player.ExperienceMultiplier.Value = 1.5f;
		
		player.AddExperience(1000);

		Assert.AreEqual(1, player.Level);
		Assert.AreEqual(50, player.BagSize);
		Assert.AreEqual(2500, player.Exp);
	}
}
