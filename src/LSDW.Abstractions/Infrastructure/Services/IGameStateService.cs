﻿using LSDW.Abstractions.Domain.Models;

namespace LSDW.Abstractions.Infrastructure.Services;

/// <summary>
/// The game state service interface.
/// </summary>
public interface IGameStateService
{
	/// <summary>
	/// The loaded player instance.
	/// </summary>
	IPlayer Player { get; }

	/// <summary>
	/// The loaded dealer instance collection.
	/// </summary>
	ICollection<IDealer> Dealers { get; }

	/// <summary>
	/// Loads the game state from file.
	/// </summary>
	/// <remarks>
	/// If no save file is found, a new save file will be created.
	/// </remarks>
	/// <returns><see langword="true"/> or <see langword="false"/> if successful.</returns>
	bool Load();

	/// <summary>
	/// Saves the current game state.
	/// </summary>
	/// <returns><see langword="true"/> or <see langword="false"/> if successful.</returns>
	bool Save();
}
