﻿using LSDW.Classes;
using LSDW.Interfaces.Classes;

namespace LSDW.Factories;

/// <summary>
/// The character factory class.
/// </summary>
public static class CharacterFactory
{
	/// <summary>
	/// Should create a new player character instance.
	/// </summary>
	public static IPlayerCharacter CreatePlayer()
		=> new PlayerCharacter();

	/// <summary>
	/// Should create a new player character instance.
	/// </summary>
	/// <param name="inventory">The player inventory.</param>
	/// <param name="experience">The player experience points.</param>
	public static IPlayerCharacter CreatePlayer(IInventoryCollection inventory, int experience)
		=> new PlayerCharacter(inventory, experience);
}
