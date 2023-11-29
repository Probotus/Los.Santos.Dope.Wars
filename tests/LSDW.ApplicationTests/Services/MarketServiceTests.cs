using LSDW.Application.Interfaces.Infrastructure.Services;
using LSDW.Application.Services;
using LSDW.Domain.Interfaces.Manager;
using LSDW.Domain.Interfaces.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LSDW.ApplicationTests.Services;

[TestClass]
public sealed partial class MarketServiceTests : ApplicationTestBase
{
	private readonly IDealerCollection _dealers;
	private readonly IPlayer _player;
	private readonly ILoggerService _loggerService;
	private readonly IDomainManager _domainManager;
	private readonly MarketService _marketService;

	public MarketServiceTests()
	{
		_dealers = GetService<IDealerCollection>();
		_player = GetService<IPlayer>();
		_loggerService = MockHelper.GetLoggerService();
		_domainManager = MockHelper.GetDomainManager();
		_marketService = new MarketService(_dealers, _player, _loggerService, _domainManager);
	}
}
