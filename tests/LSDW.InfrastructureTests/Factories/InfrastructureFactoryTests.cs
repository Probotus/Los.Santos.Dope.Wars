using GTA;
using GTA.Math;

using LSDW.Domain.Enumerators;
using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Interfaces.Services;
using LSDW.Infrastructure.Models;

using Moq;

namespace LSDW.InfrastructureTests.Factories;

[TestClass]
public partial class InfrastructureFactoryTests : InfrastructureTestBase
{
	private readonly ISettings _settings;
	private readonly Mock<IWorldService> _worldServiceMock;

	public InfrastructureFactoryTests()
	{
		_settings = GetService<ISettings>();
		_worldServiceMock = new Mock<IWorldService>();
		_worldServiceMock.SetupAllProperties();
	}

	private IDealer GetDealer()
	{
		IDealer dealer = DomainFactory.CreateDealer(
			settings: _settings,
			worldService: _worldServiceMock.Object,
			discovered: true,
			hash: PedHash.Dealer01SMY,
			name: "John Doe",
			money: 125,
			position: Vector3.Zero,
			drugs: DomainFactory.GetAllDrugs()
			);

		return dealer;
	}

	private static DealerState GetDealerState()
	{
		DealerState state = new()
		{
			Discovered = true,
			Drugs = [],
			Hash = PedHash.DeadHooker,
			Name = "Jane Doe",
			Money = 175,
			Position = Vector3.Zero
		};

		return state;
	}

	private static IDrug GetDrug()
	{
		IDrug drug = DomainFactory.CreateDrug(
			type: DrugType.HASH,
			quantity: 25,
			value: 35
			);

		return drug;
	}

	private static DrugState GetDrugState()
	{
		DrugState state = new()
		{
			Type = DrugType.MDMA,
			Quantity = 25,
			Value = 45
		};

		return state;
	}

	private static ITransaction GetTransaction()
	{
		ITransaction transaction = DomainFactory.CreateTransaction(
			type: TransactionType.FIND,
			drugType: DrugType.CRACK,
			quantity: 100,
			value: 100
			);

		return transaction;
	}

	private static TransactionState GetTransactionState()
	{
		TransactionState state = new()
		{
			Type = TransactionType.LOSE,
			DrugType = DrugType.KETA,
			Quantity = 10,
			Value = 100
		};

		return state;
	}
}
