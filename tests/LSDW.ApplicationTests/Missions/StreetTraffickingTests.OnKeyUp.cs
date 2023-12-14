using LSDW.Application.Interfaces.Application.Missions;
using LSDW.Application.Missions;
using LSDW.Domain.Enumerators;
using LSDW.Domain.Interfaces.Models;

using Moq;

namespace LSDW.ApplicationTests.Missions;

public sealed partial class StreetTraffickingTests
{
	[TestMethod]
	public void OnKeyUpTest()
	{
		Mock<IDealer> dealerMock = new();
		dealerMock.SetupAllProperties();
		_dealers.Add(dealerMock.Object);

		IStreetTrafficking streetTrafficking =
			new StreetTrafficking(_domainServiceMock.Object, _infrastructureServiceMock.Object, _traffickingMenuMock.Object);

		streetTrafficking.OnKeyUp(this, new(Keys.F10));
		streetTrafficking.OnKeyUp(this, new(Keys.F10));

		_dealers.Remove(dealerMock.Object);
		_stateServiceMock.Verify(v => v.Load(), Times.Once());
		_stateServiceMock.Verify(v => v.Save(), Times.Once());
		_loggerServiceMock.Verify(v => v.Information(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
		Assert.AreEqual(MissionStatus.STOPPED, streetTrafficking.Status);
	}
}
