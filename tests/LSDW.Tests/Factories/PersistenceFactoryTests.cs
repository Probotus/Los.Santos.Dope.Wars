﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using GTA.Math;
using LSDW.Classes.Persistence;
using LSDW.Core.Enumerators;
using LSDW.Core.Factories;
using LSDW.Core.Helpers;
using LSDW.Core.Interfaces.Classes;
using LSDW.Factories;
using LSDW.Interfaces.Actors;
using LSDW.Core.Extensions;

namespace LSDW.Tests.Factories;

[TestClass]
public class PersistenceFactoryTests
{
	[TestMethod]
	public void CreateDrugStateTest()
	{
		IDrug drug = DrugFactory.CreateDrug();

		DrugState state = PersistenceFactory.CreateDrugState(drug);

		Assert.IsNotNull(state);
		Assert.AreEqual(drug.DrugType, state.DrugType);
		Assert.AreEqual(drug.Quantity, state.Quantity);
		Assert.AreEqual(drug.Price, state.Price);
	}

	[TestMethod()]
	public void CreateDrugTest()
	{
		DrugState state = new()
		{
			DrugType = DrugType.HASH,
			Quantity = 15,
			Price = 12
		};

		IDrug drug = PersistenceFactory.CreateDrug(state);

		Assert.IsNotNull(drug);
		Assert.AreEqual(state.DrugType, drug.DrugType);
		Assert.AreEqual(state.Quantity, drug.Quantity);
		Assert.AreEqual(state.Price, drug.Price);
	}

	[TestMethod]
	public void CreateDrugStatesTest()
	{
		IEnumerable<IDrug> drugs = DrugFactory.CreateAllDrugs();

		List<DrugState> states = PersistenceFactory.CreateDrugStates(drugs);

		Assert.IsNotNull(states);
		Assert.AreEqual(drugs.Count(), states.Count);
	}

	[TestMethod]
	public void CreateDrugsTest()
	{
		List<DrugState> states = new()
		{
			new() {DrugType = DrugType.HASH,Quantity = 15,Price = 12},
			new() { DrugType = DrugType.CANA, Quantity = 25, Price = 23}
		};

		IEnumerable<IDrug> drugs = PersistenceFactory.CreateDrugs(states);

		Assert.IsNotNull(drugs);
		Assert.IsTrue(drugs.Any());
		Assert.AreEqual(states.Count, drugs.Count());
	}

	[TestMethod]
	public void CreateInventoryStateTest()
	{
		IEnumerable<IDrug> drugs = DrugFactory.CreateAllDrugs();
		int money = RandomHelper.GetInt();
		IInventory inventory = InventoryFactory.CreateInventory(drugs, money);

		InventoryState state = PersistenceFactory.CreateInventoryState(inventory);

		Assert.IsNotNull(state);
		Assert.AreEqual(money, state.Money);
		Assert.AreEqual(drugs.Count(), state.Drugs.Count);
	}

	[TestMethod]
	public void CreateInventoryTest()
	{
		InventoryState state = new()
		{
			Money = 25000,
			Drugs = new()
			{
				new() { DrugType = DrugType.HASH, Quantity = 15, Price = 12 },
				new() { DrugType = DrugType.CANA, Quantity = 25, Price = 23 }
			}
		};

		IInventory inventory = PersistenceFactory.CreateInventory(state);

		Assert.IsNotNull(inventory);
		Assert.AreEqual(state.Money, inventory.Money);
		Assert.AreEqual(state.Drugs.Count, inventory.Count);
	}

	[TestMethod]
	public void CreatePlayerStateTest()
	{
		IInventory inventory = InventoryFactory.CreateInventory();
		_ = inventory.Randomize(100);
		int experience = RandomHelper.GetInt(65000000, 450000000);
		IEnumerable<ILogEntry> logEntries = new List<ILogEntry>()
		{
			LogEntryFactory.CreateLogEntry(DateTime.Now, TransactionType.TRAFFIC, DrugType.COKE, 10, 1000),
			LogEntryFactory.CreateLogEntry(DateTime.Now.AddDays(-1), TransactionType.DEPOSIT, DrugType.METH, 15, 2500),
		};

		IPlayer player = PlayerFactory.CreatePlayer(inventory, experience, logEntries);
		PlayerState playerState = PersistenceFactory.CreatePlayerState(player);
		
		Assert.IsNotNull(playerState);
		Assert.AreEqual(experience, player.Experience);
		Assert.AreEqual(inventory.Count, player.Inventory.Count);
		Assert.AreEqual(inventory.TotalQuantity, player.Inventory.TotalQuantity);
		Assert.AreEqual(inventory.Money, player.Inventory.Money);
		Assert.AreEqual(logEntries.Count(), player.Transactions.Count);
	}

	[TestMethod]
	public void CreatePlayerTest()
	{
		PlayerState state = new()
		{
			Experience = 12000,
			Inventory = new()
			{
				Money = 25000,
				Drugs = new()
				{
					new() { DrugType = DrugType.HASH, Quantity = 13, Price = 22 },
					new() { DrugType = DrugType.CANA, Quantity = 21, Price = 13 }
				}
			}
		};

		IPlayer player = PersistenceFactory.CreatePlayer(state);

		Assert.IsNotNull(player);
		Assert.AreEqual(state.Experience, player.Experience);
		Assert.AreEqual(state.Inventory.Money, player.Inventory.Money);
		Assert.AreEqual(state.Inventory.Drugs.Count, state.Inventory.Drugs.Count);
	}

	[TestMethod()]
	public void CreateDealerStateTest()
	{
		IDealer dealer = ActorFactory.CreateDealer(new Vector3(287.011f, -991.685f, 33.108f));

		DealerState state = PersistenceFactory.CreateDealerState(dealer);

		Assert.IsNotNull(state);
	}

	[TestMethod()]
	public void CreateLogEntryStateTest()
	{
		ILogEntry logEntry = LogEntryFactory.CreateLogEntry(DateTime.Now, TransactionType.TRAFFIC, DrugType.COKE, 10, 1000);

		LogEntryState state = PersistenceFactory.CreateLogEntryState(logEntry);

		Assert.IsNotNull(state);
	}

	[TestMethod()]
	public void CreateLogEntryTest()
	{
		LogEntryState state = new()
		{
			DateTime = DateTime.Now,
			TransactionType = TransactionType.TRAFFIC,
			DrugType = DrugType.CANA,
			Quantity = 10,
			TotalValue = -100
		};

		ILogEntry logEntry = PersistenceFactory.CreateLogEntry(state);

		Assert.IsNotNull(logEntry);
	}

	[TestMethod()]
	public void CreateLogEntryStatesTest()
	{
		IEnumerable<ILogEntry> logEntries = new List<ILogEntry>()
		{
			LogEntryFactory.CreateLogEntry(DateTime.Now, TransactionType.TRAFFIC, DrugType.COKE, 10, 1000),
			LogEntryFactory.CreateLogEntry(DateTime.Now.AddDays(-1), TransactionType.DEPOSIT, DrugType.METH, 10, 0),
		};

		List<LogEntryState> states = PersistenceFactory.CreateLogEntryStates(logEntries);

		Assert.IsNotNull(states);
		Assert.IsTrue(states.Any());
		Assert.AreEqual(logEntries.Count(), states.Count);
	}

	[TestMethod()]
	public void CreateLogEntriesTest()
	{
		List<LogEntryState> states = new()
		{
			new() { DateTime = DateTime.Now, TransactionType = TransactionType.TRAFFIC, DrugType = DrugType.CANA, Quantity = 10, TotalValue = -100 },
			new() { DateTime = DateTime.Now.AddDays(-2), TransactionType = TransactionType.TRAFFIC, DrugType = DrugType.HASH, Quantity = 5, TotalValue = 5 },
		};

		IEnumerable<ILogEntry> logEntries = PersistenceFactory.CreateLogEntries(states);
		
		Assert.IsNotNull(logEntries);
		Assert.IsTrue(logEntries.Any());
		Assert.AreEqual(states.Count, logEntries.Count());
	}
}