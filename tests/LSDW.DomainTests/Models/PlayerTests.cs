using LSDW.Domain.Interfaces.Models;

namespace LSDW.DomainTests.Models;

[TestClass]
public sealed partial class PlayerTests : DomainTestBase
{
	private readonly IPlayer _player;

	public PlayerTests()
		=> _player = GetService<IPlayer>();
}
