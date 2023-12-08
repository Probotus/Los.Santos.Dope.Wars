using System.ComponentModel;

using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Models.Base;

namespace LSDW.DomainTests.Models;

public sealed partial class TransactionCollectionTests
{
	[TestMethod]
	public void LoadTest()
	{
		int countChanging = int.MaxValue;
		int countChanged = int.MaxValue;
		int valueChanging = int.MaxValue;
		int valueChanged = int.MaxValue;
		List<ITransaction> transactions = GetTransactions();
		_transactions.PropertyChanging += (s, e) =>
		{
			if (e is not PropertyChangingEventArgs<int> ev)
				return;
			if (ev.PropertyName == nameof(_transactions.Count))
				countChanging = ev.Value;
			if (ev.PropertyName == nameof(_transactions.Value))
				valueChanging = ev.Value;
		};
		_transactions.PropertyChanged += (s, e) =>
		{
			if (e is not PropertyChangedEventArgs<int> ev)
				return;
			if (ev.PropertyName == nameof(_transactions.Count))
				countChanged = ev.Value;
			if (ev.PropertyName == nameof(_transactions.Value))
				valueChanged = ev.Value;
		};

		_transactions.Load(transactions);

		Assert.AreEqual(transactions.Count, _transactions.Count);
		Assert.AreEqual(CollectionChangeAction.Refresh, _changing);
		Assert.AreEqual(CollectionChangeAction.Refresh, _changed);
		Assert.AreNotEqual(int.MaxValue, countChanging);
		Assert.AreNotEqual(int.MaxValue, countChanged);
		Assert.AreNotEqual(int.MaxValue, valueChanging);
		Assert.AreNotEqual(int.MaxValue, valueChanged);
	}
}
