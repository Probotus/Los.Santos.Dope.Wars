using GTA;

using LSDW.Domain.Enumerators;
using LSDW.Domain.Extensions;

using PedHashes = LSDW.Domain.Statics.GangStatics.PedHashes;

namespace LSDW.DomainTests.Statics;

public sealed partial class GangStaticsTests
{
	[DataTestMethod]
	[DataRow(GangType.None)]
	public void GetPedHashNoneTest(GangType type)
	{
		PedHash pedHash;

		pedHash = PedHashes.GetPedHash(type);

		Assert.AreEqual(PedHash.Dealer01SMY, pedHash);
	}

	[TestMethod]
	public void GetPedHashAllTest()
	{
		GangType[] gangTypes = GangType.None.GetValues().ToArray();
		List<PedHash> pedHashes = [];

		gangTypes.ForEach(type =>
		{
			PedHash pedHash = PedHashes.GetPedHash(type);
			pedHashes.Add(pedHash);
		});

		Assert.AreEqual(gangTypes.Length, pedHashes.Count);
	}
}
