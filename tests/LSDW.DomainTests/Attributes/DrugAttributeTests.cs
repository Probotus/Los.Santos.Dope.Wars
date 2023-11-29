using LSDW.Domain.Attributes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LSDW.DomainTests.Attributes;

[TestClass]
public sealed class DrugAttributeTests
{
	[TestMethod]
	[ExpectedException(typeof(ArgumentOutOfRangeException))]
	public void AverageValueException()
	{
		_ = new DrugAttribute(string.Empty, string.Empty)
		{
			AverageValue = -1
		};
	}

	[TestMethod]
	[ExpectedException(typeof(ArgumentOutOfRangeException))]
	public void ProbabilityException()
	{
		_ = new DrugAttribute(string.Empty, string.Empty)
		{
			Probability = -1
		};
	}
}
