using LSDW.Domain.Extensions;

namespace LSDW.Domain.Statics;

/// <summary>
/// The name statics class.
/// </summary>
internal static class NameStatics
{
	private static readonly Lazy<string[]> MaleFirstNames = new(() => new string[]
	{
		"Simon","John","Jack","Grant","Sandeep","Sylvester","Lionel","James","Garrett","Reinout","Eric",
		"Mihail","Jan","George","Jeffrey","Kevin","Paul","Hazem","David","Tete","Zainal","François","Michael",
		"Jack","William","Alejandro","Tawana","Willis","Jason","Hung-Fu","Michael","Stuart","Min","Rajesh",
		"Chris","Gabe","Russell","John","Ken","Magnus","Thierry","Andreas","Pete","Ken","Zheng","Stuart","Lolan",
		"Baris","Frank","Brian","David","Tengiz","John","Eric","Brandon","Michael","Jose","Kok-Ho","Ben","Chris",
		"Ovidiu","Ebru","Rob","Sean","Vidur","Benjamin","Paul","Suroor","Taylor","David","David","Dragan","Bob",
		"Chad","Michael","Pat","Karan","Shane","Sameer","Don"
	});

	private static readonly Lazy<string[]> FemaleFirstNames = new(() => new string[]
	{
		"Karen","Kitti","Barbara","Jo","Merav","Alice","Margie","Jae","Linda","Belinda","Carol","Janeth","Kathie",
		"Kim","Sandra","Diane","Barbara","Linda","Kimberly","Katie","Samantha","Yvonne","Erin","Shelley","Paula",
		"Lynn","Britta","Doris","Rebecca","Wendy","Cynthia","Annette","Laura","Wanida","Elizabeth","Denise","Jill",
		"Betsy","Susan","Jo","Stephanie","Paula","Ruth","Gigi","Linda","Nancy","Laura","Lori","Lorraine","Jillian",
		"Lori","Susan","Linda","Carole","Pamela","Candy","Mary","JoLynn","Kim","Amy","Janet","Deborah","Rachel",
		"Sharon","Anibal","Terri","Diane","Sheela","Mary","Olinda","Diane","Mary","Nicole","Karen","Gail","Bonnie",
		"Danielle","Mindy","Suchitra","Brenda","Janice","Angela","Janaina","Jean"
	});

	private static readonly Lazy<string[]> LastNames = new(() => new string[]
	{
		"Hillmann","Richins","Norman","King","Scardelis","Campbell","Duffy","Frintu","Okelberry","Smith",
		"Mohamed","Abercrombie","Kaliyath","Rothkugel","Mares","Mirchandani","Sam","Ellerbrock","Petculescu",
		"Cetinok","Hite","Gibson","Yukish","Dyck","Randall","McAskill-White","Poland","Johnson","Wilson","Hagens",
		"Keil","Song","Keyser","Cracium","Koch","Nartker","Preston","Berge","Ito","Saraiva","Hall","Raheem",
		"Harnpadoungsataya","Zimmerman","Rettig","Hamilton","Martin","Valdez","Dobney","Culbertson","Kleinerman",
		"Laszlo","Gubbels","Sousa","Walters","Koenigsbauer","Trenary","Tsoflias","Reátegui Alayo","Dempsey",
		"Benshoof","Munson","Connelly","Vande Velde","Miller","Singh","Johnson","Erickson","Hay","Sunkammurali",
		"Ting","Randall","Barbariol","Ingle","Baker","Adams","Meyyappan","Northup","Bradley","Martin"
	});

	/// <summary>
	/// Returns a random male name.
	/// </summary>
	/// <returns>A male name.</returns>
	public static string GetMaleName()
		=> string.Concat(GetMaleFirstName(), " ", GetLastName());

	/// <summary>
	/// Returns a random female name.
	/// </summary>
	/// <returns>A female name.</returns>
	public static string GetFemaleName()
		=> string.Concat(GetFemaleFirstName(), " ", GetLastName());

	private static string GetMaleFirstName()
		=> MaleFirstNames.Value.RandomChoice();

	private static string GetFemaleFirstName()
		=> FemaleFirstNames.Value.RandomChoice();

	private static string GetLastName()
		=> LastNames.Value.RandomChoice();
}
