using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LSDW.DomainTests.Models;

public sealed partial class PlayerTests
{
	[TestMethod]
	public void AddExperience()
	{
		_player.AddExperience(1000);

		Assert.AreEqual(1, _player.Level);
		Assert.AreEqual(50, _player.BagSize);
		Assert.AreEqual(2000, _player.Exp);
		Assert.AreEqual(8000, _player.ExpForNextLevel);
	}

	[TestMethod]
	[ExpectedException(typeof(ArgumentOutOfRangeException))]
	public void AddExperienceException()
		=> _player.AddExperience(0);

	[TestMethod]
	public void AddExperienceMaximumLevel()
	{
		_player.AddExperience(1999999999);

		_player.AddExperience(1);

		Assert.AreEqual(100, _player.Level);
		Assert.AreEqual(5000, _player.BagSize);
		Assert.AreEqual(1000000000, _player.Exp);
	}
}
