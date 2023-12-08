using System.ComponentModel;

using LSDW.Domain.Enumerators;
using LSDW.Domain.Extensions;
using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;

using Moq;

namespace LSDW.DomainTests.Models;

[TestClass]
public sealed partial class TransactionCollectionTests : DomainTestBase
{
	private readonly ITransactionCollection _transactions;
	private CollectionChangeAction _changing;
	private CollectionChangeAction _changed;

	public TransactionCollectionTests()
	{
		_changing = default;
		_changed = default;
		IPlayer player = GetService<IPlayer>();
		_transactions = player.Transactions;
		_transactions.CollectionChanging += (s, e) => _changing = e.Action;
		_transactions.CollectionChanged += (s, e) => _changed = e.Action;
	}

	private List<ITransaction> GetTransactions()
	{
		Random random = new(Guid.NewGuid().GetHashCode());
		DrugType[] drugTypes = DrugType.COKE.GetValues().ToArray();
		TransactionType[] tranTypes = TransactionType.BUY.GetValues().ToArray();
		List<ITransaction> transactions = [];

		for (int i = 0; i < 20; i++)
		{
			DrugType drugType = drugTypes.RandomChoice();
			int value = drugType.GetAverageValue();
			int quantity = (int)Math.Ceiling(random.NextDouble() * i + 1 * 10);
			ITransaction transaction = DomainFactory.CreateTransaction(
				type: tranTypes.RandomChoice(),
				drugType: drugType,
				quantity: quantity,
				value: value
				);
			transactions.Add(transaction);
		}

		return transactions;
	}
}
