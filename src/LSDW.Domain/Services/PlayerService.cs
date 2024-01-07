﻿using System.Diagnostics.CodeAnalysis;

using GTA;
using GTA.Math;

using LSDW.Domain.Interfaces.Services;

namespace LSDW.Domain.Services;

/// <summary>
/// The player provider class.
/// </summary>
/// <remarks>
/// Wrapper for the <see cref="Player"/> methods and properties.
/// </remarks>
[ExcludeFromCodeCoverage]
internal sealed class PlayerService : IPlayerService
{
	public Ped Character
		=> Game.Player.Character;

	public int Money
	{
		get => Game.Player.Money;
		set => Game.Player.Money = value;
	}

	public int WantedLevel
	{
		get => Game.Player.WantedLevel;
		set => Game.Player.WantedLevel = value;
	}

	public bool CanStartMission
		=> Game.Player.CanStartMission;

	public bool CanControlCharacter
	{
		get => Game.Player.CanControlCharacter;
		set => Game.Player.CanControlCharacter = value;
	}

	public bool DispatchsCops
	{
		set => Game.Player.DispatchsCops = value;
	}

	public bool IsDead
		=> Game.Player.IsDead;

	public Vector3 Position
	{
		get => Game.Player.Character.Position;
		set => Game.Player.Character.Position = value;
	}

	public bool IsInRange(Vector3 position, float range)
		=> Game.Player.Character.IsInRange(position, range);

	public bool IsNearEntity(Entity entity, Vector3 bounds)
		=> Game.Player.Character.IsNearEntity(entity, bounds);

	public bool IsTargeting(Entity entity)
		=> Game.Player.IsTargeting(entity);
}
