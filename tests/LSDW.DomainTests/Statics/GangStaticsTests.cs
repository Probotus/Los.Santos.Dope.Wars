using GTA;

using LSDW.Domain.Statics;

namespace LSDW.DomainTests.Statics;

[TestClass]
public sealed class GangStaticsTests : DomainTestBase
{
	[TestMethod]
	public void GetPedHashTest()
	{
		List<PedHash> pedHashes = [];

		for (int i = 0; i < 10; i++)
		{
			PedHash pedHash = GangStatics.GetPedHash();
			pedHashes.Add(pedHash);
		}

		Assert.AreEqual(10, pedHashes.Count);
	}

	[TestMethod]
	public void GetWeaponHashTest()
	{
		List<WeaponHash> weaponHashes = [];

		for (int i = 0; i < 10; i++)
		{
			WeaponHash weaponHash = GangStatics.GetWeaponHash();
			weaponHashes.Add(weaponHash);
		}

		Assert.AreEqual(10, weaponHashes.Count);
	}
}
