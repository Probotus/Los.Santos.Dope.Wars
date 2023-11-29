using System.Xml.Serialization;

namespace LSDW.Infrastructure.Constants;

/// <summary>
/// The xml constants class.
/// </summary>
internal static class XmlConstants
{
	internal const string NameSpace = "https://github.com/BoBoBaSs84/Los.Santos.Dope.Wars";
	internal const string NameSpacePreFix = "lsdw";
	internal const string DealerArrayName = "Dealers";
	internal const string DealerElementName = "Dealer";
	internal const string DrugArrayName = "Drugs";
	internal const string DrugElementName = "Drug";
	internal const string PlayerElementName = "Player";
	internal const string TransactionArrayName = "Transactions";
	internal const string TransactionElementName = "Transaction";

	/// <summary>
	/// Returns the necessary namespaces.
	/// </summary>
	internal static XmlSerializerNamespaces SerializerNamespaces => GetNameSpaces();

	private static XmlSerializerNamespaces GetNameSpaces()
	{
		XmlSerializerNamespaces namespaces = new();
		namespaces.Add(NameSpacePreFix, NameSpace);
		return namespaces;
	}
}
