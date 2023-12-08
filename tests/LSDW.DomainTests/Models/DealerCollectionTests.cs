using System.ComponentModel;

using LSDW.Domain.Interfaces.Models;

namespace LSDW.DomainTests.Models;

[TestClass]
public sealed partial class DealerCollectionTests : DomainTestBase
{
	private readonly IDealerCollection _dealers;
	private CollectionChangeAction _changing;
	private CollectionChangeAction _changed;

	public DealerCollectionTests()
	{
		_changing = default;
		_changed = default;
		_dealers = GetService<IDealerCollection>();
		_dealers.CollectionChanging += (s, e) => _changing = e.Action;
		_dealers.CollectionChanged += (s, e) => _changed = e.Action;
	}
}
