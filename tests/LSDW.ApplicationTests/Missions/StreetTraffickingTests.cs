using LSDW.Application.Interfaces.Infrastructure.Managers;
using LSDW.Application.Missions;
using LSDW.Domain.Interfaces.Manager;
using LSDW.Domain.Interfaces.Models;

namespace LSDW.ApplicationTests.Missions;

[TestClass]
public sealed partial class StreetTraffickingTests : ApplicationTestBase
{
	private readonly IDealerCollection _dealers;
	private readonly IInfrastructureManager _infrastructureManager;
	private readonly IDomainManager _domainManager;
	private readonly StreetTrafficking _streetTrafficking;

	public StreetTraffickingTests()
	{
		_dealers = GetService<IDealerCollection>();
		_infrastructureManager = MockHelper.GetInfrastructureManager();
		_domainManager = MockHelper.GetDomainManager();
		_streetTrafficking = new StreetTrafficking(_dealers, _infrastructureManager, _domainManager, null);
	}
}
