﻿using LSDW.Interfaces.Classes;
using CF = LSDW.Factories.CharacterFactory;
using IF = LSDW.Factories.InventoryFactory;

namespace LSDW.Tests.Classes;

[TestClass]
public class PlayerCharacterTests
{
	[TestMethod]
	public void AddExperienceTest()
	{
		IPlayerCharacter character = CF.CreatePlayerCharacter();
		int pointsToAdd = 500;

		character.AddExperience(pointsToAdd);

		Assert.IsTrue(Equals(character.CurrentExperience, pointsToAdd));
	}

	[TestMethod]
	public void CurrentLevelTest()
	{
		IPlayerCharacter character = CF.CreatePlayerCharacter();
		int pointsToAdd = 1500;

		character.AddExperience(pointsToAdd);

		Assert.IsTrue(Equals(character.CurrentLevel, 1));
	}

	[TestMethod]
	public void MaximumInventoryQuantityTest()
	{
		IPlayerCharacter character = CF.CreatePlayerCharacter();
		int pointsToAdd = 7500;

		character.AddExperience(pointsToAdd);

		Assert.IsTrue(Equals(character.MaximumInventoryQuantity, 120));
	}

	[TestMethod]
	public void NextLevelExperienceTest()
	{
		IInventoryCollection drugs = IF.CreatePlayerInventory();
		int spentMoney = 1000,
			earnedMoney = 2000,
			experience = earnedMoney - spentMoney;

		IPlayerCharacter player = CF.CreatePlayerCharacter(drugs, spentMoney, earnedMoney, experience);

		Assert.IsTrue(Equals(player.NextLevelExperience, 6727));
	}
}