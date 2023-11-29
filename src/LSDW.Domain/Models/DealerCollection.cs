using System.Collections;
using System.ComponentModel;

using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Models.Base;

namespace LSDW.Domain.Models;

/// <summary>
/// The dealer collection class.
/// </summary>
internal sealed class DealerCollection : NotifyCollectionBase, IDealerCollection
{
	private ICollection<IDealer> _dealers;

	/// <summary>
	/// Initializes a new instance of the dealer collection class.
	/// </summary>
	public DealerCollection()
		=> _dealers = new HashSet<IDealer>();

	public int Count => _dealers.Count;

	public void Add(IDealer dealer)
	{
		RaiseCollectionChanging(CollectionChangeAction.Add, dealer);
		_dealers.Add(dealer);
		RaiseCollectionChanged(CollectionChangeAction.Add, dealer);
	}

	public IEnumerator<IDealer> GetEnumerator()
		=> _dealers.GetEnumerator();

	public void Load(IEnumerable<IDealer> values)
	{
		RaiseCollectionChanging(CollectionChangeAction.Refresh);
		_dealers = new List<IDealer>(values);
		RaiseCollectionChanged(CollectionChangeAction.Refresh);
	}

	public void Remove(IDealer dealer)
	{
		RaiseCollectionChanging(CollectionChangeAction.Remove, dealer);
		_dealers.Remove(dealer);
		RaiseCollectionChanged(CollectionChangeAction.Remove);
	}

	IEnumerator IEnumerable.GetEnumerator()
		=> _dealers.GetEnumerator();
}
