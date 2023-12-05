using LSDW.Domain.Enumerators;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Models;

namespace LSDW.DomainTests.Models;

public sealed partial class PlayerTests
{
	[TestMethod]
	public void Load()
	{
		Player player = new(_settings);

		int experience = 10000;
		IEnumerable<IDrug> drugs = new List<IDrug>()
		{
			new Drug(DrugType.COKE, 10, 100),
			new Drug(DrugType.SMACK, 10, 80)
		};
		IEnumerable<ITransaction> transactions = new List<ITransaction>()
		{
			new Transaction(TransactionType.BUY, DrugType.COKE, 10, 100),
			new Transaction(TransactionType.FIND, DrugType.COKE, 10, 80)
		};

		player.Load(experience, drugs, transactions);

		Assert.AreEqual(experience, player.Exp);
		Assert.AreEqual(20, player.Drugs.Count);
		Assert.AreEqual(2, player.Transactions.Count);
	}
}
