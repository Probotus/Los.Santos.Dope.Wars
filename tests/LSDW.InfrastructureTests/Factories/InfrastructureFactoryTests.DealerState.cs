using LSDW.Domain.Interfaces.Models;
using LSDW.Infrastructure.Factories;
using LSDW.Infrastructure.Models;

namespace LSDW.InfrastructureTests.Factories;

public partial class InfrastructureFactoryTests
{
	[TestMethod]
	public void CreateDealerStateTest()
	{
		IDealer dealer = GetDealer();

		DealerState state =
			InfrastructureFactory.CreateDealerState(dealer);

		Assert.IsNotNull(state);
		Assert.AreEqual(dealer.Discovered, state.Discovered);
		Assert.IsTrue(state.ShouldSerializeDiscovered());
		Assert.AreEqual(dealer.Hash, state.Hash);
		Assert.AreEqual(dealer.Name, state.Name);
		Assert.IsTrue(state.ShouldSerializeName());
		Assert.AreEqual(dealer.Money, state.Money);
		Assert.IsTrue(state.ShouldSerializeMoney());
		Assert.AreEqual(dealer.Position, state.Position);
	}

	[TestMethod]
	public void CreateDealerStatesTest()
	{
		List<IDealer> dealers = [GetDealer(), GetDealer()];

		DealerState[] states =
			InfrastructureFactory.CreateDealerStates(dealers);

		Assert.IsNotNull(states);
		Assert.AreEqual(dealers.Count, states.Length);
	}

	[TestMethod]
	public void CreateDealerTest()
	{
		DealerState state = GetDealerState();

		IDealer dealer =
			InfrastructureFactory.CreateDealer(_settings, _worldServiceMock.Object, state);

		Assert.IsNotNull(state);
		Assert.AreEqual(state.Discovered, dealer.Discovered);
		Assert.AreEqual(state.Hash, dealer.Hash);
		Assert.AreEqual(state.Name, dealer.Name);
		Assert.AreEqual(state.Money, dealer.Money);
		Assert.AreEqual(state.Position, dealer.Position);
	}

	[TestMethod]
	public void CreateDealersTest()
	{
		DealerState[] states = [GetDealerState(), GetDealerState()];

		IEnumerable<IDealer> dealers =
			InfrastructureFactory.CreateDealers(_settings, _worldServiceMock.Object, states);

		Assert.IsNotNull(dealers);
		Assert.AreEqual(states.Length, dealers.Count());
	}
}
