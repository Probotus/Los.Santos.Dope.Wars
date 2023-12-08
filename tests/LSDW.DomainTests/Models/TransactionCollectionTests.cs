using LSDW.Domain.Enumerators;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Models;

namespace LSDW.DomainTests.Models;

[TestClass]
public sealed partial class TransactionCollectionTests : DomainTestBase
{
	private readonly ITransactionCollection _transactions;

	public TransactionCollectionTests()
	{
		IPlayer player = GetService<IPlayer>();
		_transactions = player.Transactions;
	}

	private readonly IEnumerable<ITransaction> _existingTransactions = new List<ITransaction>()
	{
		new Transaction(TransactionType.BUY, DrugType.COKE, 15, 90),
		new Transaction(TransactionType.SELL, DrugType.COKE, 10, 110),
		new Transaction(TransactionType.BUY, DrugType.LSD, 25, 45),
		new Transaction(TransactionType.SELL, DrugType.LSD, 20, 50)
	};
}
