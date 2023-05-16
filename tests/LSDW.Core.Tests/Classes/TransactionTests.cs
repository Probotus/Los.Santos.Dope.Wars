﻿using LSDW.Core.Classes;
using LSDW.Core.Enumerators;
using LSDW.Core.Interfaces.Classes;
using CF = LSDW.Core.Factories.PlayerFactory;
using DF = LSDW.Core.Factories.DrugFactory;
using IF = LSDW.Core.Factories.InventoryFactory;
using TF = LSDW.Core.Factories.TransactionFactory;

namespace LSDW.Core.Tests.Classes;

[TestClass]
public class TransactionTests
{
	[TestMethod]
	public void CommitSuccessTest()
	{
		IDrug cokeInStock = DF.CreateDrug(DrugType.COKE, 15, 1000);
		IInventory dealerInventory = IF.CreateInventory(new List<IDrug>() { cokeInStock });

		IPlayer player = CF.CreatePlayer();
		player.Inventory.Add(5000);

		List<TransactionObject> objects = new() { new(DrugType.COKE, 5, 900) };
		ITransaction transaction = TF.CreateTrafficTransaction(objects, player.MaximumInventoryQuantity);

		transaction.Commit(dealerInventory, player.Inventory);

		Assert.IsTrue(transaction.Result.Successful);
		Assert.IsTrue(transaction.Result.IsCompleted);
		Assert.AreEqual(1, transaction.Result.Messages.Count);
		Assert.AreEqual(4500, dealerInventory.Money);
		Assert.AreEqual(10, dealerInventory.TotalQuantity);
		Assert.AreEqual(500, player.Inventory.Money);
		Assert.AreEqual(5, player.Inventory.TotalQuantity);
	}

	[TestMethod]
	public void CommitFailedQuantityTest()
	{
		IDrug cokeInStock = DF.CreateDrug(DrugType.COKE, 250, 1000);
		IInventory dealerInventory = IF.CreateInventory(new List<IDrug>() { cokeInStock });

		IPlayer player = CF.CreatePlayer();
		player.Inventory.Add(500000);

		List<TransactionObject> objects = new() { new(DrugType.COKE, 150, 900) };
		ITransaction transaction = TF.CreateTrafficTransaction(objects, player.MaximumInventoryQuantity);

		transaction.Commit(dealerInventory, player.Inventory);

		Assert.IsFalse(transaction.Result.Successful);
		Assert.IsTrue(transaction.Result.IsCompleted);
		Assert.IsTrue(transaction.Result.Messages.Any());
	}

	[TestMethod]
	public void CommitFailedMoneyTest()
	{
		IDrug cokeInStock = DF.CreateDrug(DrugType.COKE, 25, 1000);
		IInventory dealerInventory = IF.CreateInventory(new List<IDrug>() { cokeInStock });

		IPlayer player = CF.CreatePlayer();
		player.Inventory.Add(500);

		List<TransactionObject> objects = new() { new(DrugType.COKE, 5, 900) };
		ITransaction transaction = TF.CreateTrafficTransaction(objects, player.MaximumInventoryQuantity);

		transaction.Commit(dealerInventory, player.Inventory);

		Assert.IsFalse(transaction.Result.Successful);
		Assert.IsTrue(transaction.Result.IsCompleted);
		Assert.IsTrue(transaction.Result.Messages.Any());
	}

	[TestMethod]
	public void CommitDepositSuccessTest()
	{
		IDrug cokeToDeposit = DF.CreateDrug(DrugType.COKE, 50, 850);
		IPlayer player = CF.CreatePlayer();
		IInventory warehouse = IF.CreateInventory();
		player.Inventory.Add(cokeToDeposit);
		player.Inventory.Add(1200);

		List<TransactionObject> objects = new() { new(cokeToDeposit) };
		ITransaction transaction = TF.CreateDepositTransaction(objects);

		transaction.Commit(player.Inventory, warehouse);

		Assert.IsTrue(transaction.Result.Successful);
		Assert.IsTrue(transaction.Result.IsCompleted);
		Assert.AreEqual(1, transaction.Result.Messages.Count);
		Assert.AreEqual(0, player.Inventory.TotalQuantity);
		Assert.AreEqual(0, player.Inventory.Count);
		Assert.AreEqual(1200, player.Inventory.Money);
		Assert.AreEqual(50, warehouse.TotalQuantity);
		Assert.AreEqual(1, warehouse.Count);
	}
}