using System.Collections;
using System.ComponentModel;

using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Models.Base;

namespace LSDW.Domain.Models;

/// <summary>
/// The transaction collection class.
/// </summary>
internal sealed class TransactionCollection : NotifyCollectionBase, ITransactionCollection
{
	private ICollection<ITransaction> _transactions;
	private int _count;
	private int _value;

	/// <summary>
	/// Initializes a instance of the transaction collection class.
	/// </summary>
	public TransactionCollection()
	{
		_transactions = new HashSet<ITransaction>();
		CollectionChanged += (s, e) => Recalculate();
	}

	public int Count { get => _count; private set => SetProperty(ref _count, value); }
	public int Value { get => _value; private set => SetProperty(ref _value, value); }

	public void Add(ITransaction transaction)
	{
		RaiseCollectionChanging(CollectionChangeAction.Add);
		_transactions.Add(transaction);
		RaiseCollectionChanged(CollectionChangeAction.Add, transaction);
	}

	public ITransaction Find(Func<ITransaction, bool> expression)
		=> _transactions.FirstOrDefault(expression);

	public IEnumerable<ITransaction> FindMany(Func<ITransaction, bool> expression)
		=> _transactions.Where(expression);

	public IEnumerator<ITransaction> GetEnumerator()
		=> _transactions.GetEnumerator();

	public void Load(IEnumerable<ITransaction> values)
	{
		RaiseCollectionChanging(CollectionChangeAction.Refresh);
		_transactions = new List<ITransaction>(values);
		RaiseCollectionChanged(CollectionChangeAction.Refresh);
	}

	public void Recalculate()
	{
		Count = _transactions.Count;
		Value = _transactions.Sum(t => t.TotalValue);
	}

	public void Remove(ITransaction transaction)
	{
		RaiseCollectionChanging(CollectionChangeAction.Remove, transaction);
		_transactions.Remove(transaction);
		RaiseCollectionChanged(CollectionChangeAction.Remove);
	}

	IEnumerator IEnumerable.GetEnumerator()
		=> _transactions.GetEnumerator();
}
