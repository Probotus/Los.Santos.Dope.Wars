using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;

using Moq;

namespace LSDW.ApplicationTests;

internal static partial class MockHelper
{
	internal static IDealer GetDealer(bool discovered = false)
	{
		Mock<IDealer> mock = new();
		mock.SetupAllProperties();
		mock.Setup(x => x.Drugs).Returns(DomainFactory.CreateDrugCollection());
		mock.Setup(x => x.Discovered).Returns(discovered);
		return mock.Object;
	}
}
