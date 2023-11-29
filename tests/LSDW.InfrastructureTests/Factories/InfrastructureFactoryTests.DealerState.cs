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

		DealerState state = InfrastructureFactory.CreateDealerState(dealer);

		Assert.IsNotNull(state);
		Assert.AreEqual(dealer.Discovered, state.Discovered);
		Assert.AreEqual(dealer.Hash, state.Hash);
		Assert.AreEqual(dealer.Name, state.Name);
		Assert.AreEqual(dealer.Money, state.Money);
		Assert.AreEqual(dealer.Position, state.Position);
		Assert.AreEqual(dealer.Zone, state.Zone);
	}

	[TestMethod]
	public void CreateDealerStatesTest()
	{
		List<IDealer> dealers = [GetDealer(), GetDealer()];

		DealerState[] states = InfrastructureFactory.CreateDealerStates(dealers);

		Assert.IsNotNull(states);
		Assert.AreEqual(dealers.Count, states.Length);
	}

	[TestMethod]
	public void CreateDealerTest()
	{
		DealerState state = GetDealerState();

		IDealer dealer = InfrastructureFactory.CreateDealer(state);

		Assert.IsNotNull(state);
		Assert.AreEqual(state.Discovered, dealer.Discovered);
		Assert.AreEqual(state.Hash, dealer.Hash);
		Assert.AreEqual(state.Name, dealer.Name);
		Assert.AreEqual(state.Money, dealer.Money);
		Assert.AreEqual(state.Position, dealer.Position);
		Assert.AreEqual(state.Zone, dealer.Zone);
	}

	[TestMethod]
	public void CreateDealersTest()
	{
		DealerState[] states = [GetDealerState(), GetDealerState()];

		IEnumerable<IDealer> dealers = InfrastructureFactory.CreateDealers(states);

		Assert.IsNotNull(dealers);
		Assert.AreEqual(states.Length, dealers.Count());
	}
}
