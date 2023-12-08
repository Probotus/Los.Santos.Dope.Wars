using LSDW.Application.Interfaces.Infrastructure.Services;
using LSDW.Application.Missions;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Interfaces.Services;

namespace LSDW.ApplicationTests.Missions;

[TestClass]
public sealed partial class StreetTraffickingTests : ApplicationTestBase
{
	private readonly IDealerCollection _dealers;
	private readonly IInfrastructureService _infrastructureManager;
	private readonly IDomainService _domainManager;
	private readonly StreetTrafficking _streetTrafficking;

	public StreetTraffickingTests()
	{
		_dealers = GetService<IDealerCollection>();
		_infrastructureManager = MockHelper.GetInfrastructureManager();
		_domainManager = MockHelper.GetDomainManager();
		_streetTrafficking = new StreetTrafficking(_dealers, _infrastructureManager, _domainManager, null);
	}
}
