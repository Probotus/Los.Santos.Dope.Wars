using GTA.Math;

using LSDW.Domain.Enumerators;
using LSDW.Domain.Extensions;
using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;

namespace LSDW.InfrastructureTests.Services;

public partial class StateServiceTests
{
	[TestMethod]
	public void SaveTest()
		=> _stateService.Save();

	[TestMethod]
	public void BigSaveTest()
	{
		for (int i = 0; i < 100; i++)
		{
			_player.AddExperience(i + 1 * 100);
			_player.Transactions.Add(
				DomainFactory.CreateTransaction(
					type: TransactionType.SELL,
					drugType: DrugType.COKE,
					quantity: 10,
					value: 100
					)
				);
		}

		_player.Drugs.ForEach(d => d.Add(10, d.AverageValue));

		for (int i = 0; i < 100; i++)
		{
			IDealer dealer = DomainFactory.CreateDealer(Vector3.Zero, $"Test{i}");
			dealer.Drugs.ForEach(d => d.Add(10, d.AverageValue));
			_dealers.Add(dealer);
		}

		_stateService.Save();
	}
}
