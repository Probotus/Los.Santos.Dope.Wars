using System.ComponentModel;

using LSDW.Application.Services;
using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;

using Moq;

namespace LSDW.ApplicationTests.Services;


public sealed partial class MarketServiceTests
{
	[TestMethod]
	public void AdditionalDealerTest()
	{
		IDrugCollection drugs = GetService<IDrugCollection>();
		drugs.Load(DomainFactory.GetAllDrugs());
		Mock<IDealer> mock = new();
		mock.SetupAllProperties();
		mock.Setup(x => x.Discover()).Raises(x => x.PropertyChanged += null, new PropertyChangedEventArgs(nameof(IDealer.Discovered)));
		mock.Setup(x => x.Drugs).Returns(drugs);

		MarketService marketService = new(_domainServiceMock.Object, _infraServiceMock.Object);

		_dealers.Add(mock.Object);
		mock.Object.Discover();
	}
}
