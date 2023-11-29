using LSDW.Domain.Interfaces.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LSDW.DomainTests.Models;

[TestClass]
public sealed partial class DealerCollectionTests : DomainTestBase
{
	private readonly IDealerCollection _dealers;

	public DealerCollectionTests()
		=> _dealers = GetService<IDealerCollection>();
}
