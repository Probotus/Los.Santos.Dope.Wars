using LSDW.Application.Interfaces.Infrastructure.Services;
using LSDW.Application.Services;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Interfaces.Services;

namespace LSDW.ApplicationTests.Services;

[TestClass]
public sealed partial class MarketServiceTests : ApplicationTestBase
{
	private readonly IDealerCollection _dealers;
	private readonly IPlayer _player;
	private readonly IInfrastructureService _infrastructureManager;
	private readonly IDomainService _domainManager;
	private readonly MarketService _marketService;

	public MarketServiceTests()
	{
		_dealers = GetService<IDealerCollection>();
		_player = GetService<IPlayer>();
		_infrastructureManager = MockHelper.GetInfrastructureManager();
		_domainManager = MockHelper.GetDomainManager();
		_marketService = new MarketService(_dealers, _player, _infrastructureManager, _domainManager);
	}
}
