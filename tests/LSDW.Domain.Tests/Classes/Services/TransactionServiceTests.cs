﻿using LSDW.Abstractions.Domain.Models;
using LSDW.Abstractions.Domain.Services;
using LSDW.Abstractions.Enumerators;
using LSDW.Domain.Factories;

namespace LSDW.Domain.Tests.Classes.Services;

[TestClass]
public class TransactionServiceTests
{
	[TestMethod]
	public void CommitDepositSuccessTest()
	{
		IDrug drug = DomainFactory.CreateDrug(DrugType.COKE, 10, 90);
		IPlayer player = DomainFactory.CreatePlayer(32000);
		player.Inventory.Add(1000);
		IInventory inventory = DomainFactory.CreateInventory();
		inventory.Add(drug);

		ITransactionService transactionService =
			DomainFactory.CreateTransactionService(TransactionType.GIVE, inventory, player.Inventory, player.MaximumInventoryQuantity);

		bool success = transactionService.Commit(drug.Type, drug.Quantity, drug.CurrentPrice);

		Assert.IsTrue(success);
		Assert.AreEqual(0, inventory.TotalQuantity);
		Assert.AreEqual(drug.Quantity, player.Inventory.TotalQuantity);
		Assert.AreEqual(drug.Quantity * drug.CurrentPrice, player.Inventory.TotalValue);
		Assert.AreEqual(1000, player.Inventory.Money);
	}

	[TestMethod]
	public void CommitTrafficSuccessTest()
	{
		IDrug drug = DomainFactory.CreateDrug(DrugType.COKE, 10, 90);
		IPlayer player = DomainFactory.CreatePlayer();
		player.Inventory.Add(1000);
		IInventory inventory = DomainFactory.CreateInventory();
		inventory.Add(drug);

		ITransactionService transactionService =
			DomainFactory.CreateTransactionService(TransactionType.BUY, inventory, player.Inventory, player.MaximumInventoryQuantity);

		bool success = transactionService.Commit(drug.Type, drug.Quantity, drug.CurrentPrice);

		Assert.IsTrue(success);
		Assert.AreEqual(0, inventory.TotalQuantity);
		Assert.AreEqual(drug.Quantity, player.Inventory.TotalQuantity);
		Assert.AreEqual(drug.Quantity * drug.CurrentPrice, player.Inventory.TotalValue);
		Assert.AreEqual(100, player.Inventory.Money);
		Assert.AreEqual(900, inventory.Money);
	}

	[TestMethod]
	public void CommitTrafficNotEnoughMoneyTest()
	{
		IDrug drug = DomainFactory.CreateDrug(DrugType.COKE, 10, 90);
		IPlayer player = DomainFactory.CreatePlayer();
		player.Inventory.Add(800);
		IInventory inventory = DomainFactory.CreateInventory();
		inventory.Add(drug);

		ITransactionService transactionService =
			DomainFactory.CreateTransactionService(TransactionType.BUY, inventory, player.Inventory, player.MaximumInventoryQuantity);

		bool success = transactionService.Commit(drug.Type, drug.Quantity, drug.CurrentPrice);

		Assert.IsFalse(success);
		Assert.IsTrue(transactionService.Errors.Any());
	}

	[TestMethod]
	public void CommitDepositNotEnoughInventoryTest()
	{
		IDrug drug = DomainFactory.CreateDrug(DrugType.COKE, 100, 100);
		IPlayer player = DomainFactory.CreatePlayer();
		IInventory inventory = DomainFactory.CreateInventory();
		inventory.Add(drug);

		ITransactionService transactionService =
			DomainFactory.CreateTransactionService(TransactionType.GIVE, player.Inventory, inventory, 0);

		bool success = transactionService.Commit(drug.Type, drug.Quantity, drug.CurrentPrice);

		Assert.IsFalse(success);
		Assert.IsTrue(transactionService.Errors.Any());
	}
}
