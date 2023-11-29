using LSDW.Application.Interfaces.Infrastructure.Services;
using LSDW.Application.Missions;
using LSDW.Domain.Interfaces.Manager;
using LSDW.Domain.Interfaces.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LSDW.ApplicationTests.Missions;

[TestClass]
public sealed partial class StreetTraffickingTests : ApplicationTestBase
{
	private readonly IDealerCollection _dealers;
	private readonly ILoggerService _loggerService;
	private readonly IStateService _stateService;
	private readonly IDomainManager _domainManager;
	private readonly StreetTrafficking _streetTrafficking;

	public StreetTraffickingTests()
	{
		_dealers = GetService<IDealerCollection>();
		_loggerService = MockHelper.GetLoggerService();
		_stateService = MockHelper.GetStateService();
		_domainManager = MockHelper.GetDomainManager();
		_streetTrafficking = new StreetTrafficking(_dealers, _loggerService, _stateService, _domainManager);
	}
}
