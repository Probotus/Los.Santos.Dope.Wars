using LSDW.Domain.Enumerators;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LSDW.DomainTests.Models;

public sealed partial class PlayerTests
{
	[TestMethod]
	public void Load()
	{
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

		_player.Load(experience, drugs, transactions);

		Assert.AreEqual(experience, _player.Exp);
		Assert.AreEqual(20, _player.Drugs.Count);
		Assert.AreEqual(2, _player.Transactions.Count);
	}
}
