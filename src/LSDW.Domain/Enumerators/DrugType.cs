using System.ComponentModel;

using LSDW.Domain.Attributes;

namespace LSDW.Domain.Enumerators;

/// <summary>
/// The drug type enumerator.
/// </summary>
public enum DrugType
{
	/// <summary>
	/// The Cocaine drug type enumerator.
	/// </summary>
	[Drug("Cocaine", "Cocaine is a powerful stimulant and narcotic.", AverageValue = 100, Probability = 0.5f)]
	COKE,

	/// <summary>
	/// The Heroin drug type enumerator.
	/// </summary>
	[Drug("Heroin", "Heroin is a semi-synthetic, strongly analgesic opioid.", AverageValue = 80, Probability = 0.6f)]
	SMACK,

	/// <summary>
	/// The "Marijuana" drug type enumerator.
	/// </summary>
	[Drug("Marijuana", "Marijuana is a psychoactive drug from the Cannabis plant", AverageValue = 15, Probability = 0.9f)]
	CANA,

	/// <summary>
	/// The "Hashish" drug type enumerator.
	/// </summary>
	[Drug("Hashish", "Hashish refers to the resin extracted from the cannabis plant.", AverageValue = 20, Probability = 0.95f)]
	HASH,

	/// <summary>
	/// The "Mushrooms" drug type enumerator.
	/// </summary>
	[Drug("Mushrooms", "Psychoactive mushrooms, also known as magic mushrooms.", AverageValue = 25, Probability = 0.8f)]
	SHROOMS,

	/// <summary>
	/// The "Amphetamine" drug type enumerator.
	/// </summary>
	[Drug("Amphetamine", "Illegally trafficked amphetamine is also known as 'speed' or 'pep'.", AverageValue = 35, Probability = 0.75f)]
	SPEED,

	/// <summary>
	/// The "Angel Dust" drug type enumerator.
	/// </summary>
	[Drug("Angel Dust", "Also known as PCP or Peace Pill in the drug scene.", AverageValue = 30, Probability = 0.75f)]
	PCP,

	/// <summary>
	/// The "Methamphetamine" drug type enumerator.
	/// </summary>
	[Drug("Methamphetamine", "Methamphetamine is also known as meth, crystal or ice.", AverageValue = 125, Probability = 0.6f)]
	METH,

	/// <summary>
	/// The "Ketamine" drug type enumerator.
	/// </summary>
	[Drug("Ketamine", "Ketamine can greatly reduce the sensation of pain and cause unconsciousness.", AverageValue = 55, Probability = 0.8f)]
	KETA,

	/// <summary>
	/// The "Mescaline" drug type enumerator.
	/// </summary>
	[Drug("Mescaline", "In terms of effect, mescaline is a typical hallucinogen, also called peyotl.", AverageValue = 45, Probability = 0.7f)]
	PEYO,

	/// <summary>
	/// The "Ecstasy" drug type enumerator.
	/// </summary>
	[Drug("Ecstasy", "On the illegal market, Ecstasy, also XTC, is a term for so-called 'party pills'.", AverageValue = 15, Probability = 0.85f)]
	[Description()]
	XTC = 1 << 10,

	/// <summary>
	/// The "Acid" drug type enumerator.
	/// </summary>
	[Drug("Acid", "LSD, or 'acid', is sold in the form of small 'cardboards' printed with various designs.", AverageValue = 30, Probability = 0.8f)]
	LSD,

	/// <summary>
	/// The "Molly" drug type enumerator.
	/// </summary>
	[Drug("Molly", "MDMA, also known as 'Molly', is a white or off-white powder or crystal, purer than XTC.", AverageValue = 65, Probability = 0.7f)]
	MDMA,

	/// <summary>
	/// The "Crack" drug type enumerator.
	/// </summary>
	[Drug("Crack", "Crack and also known as 'rock', is a free base form of cocaine that can be smoked.", AverageValue = 75, Probability = 0.65f)]
	CRACK,

	/// <summary>
	/// The "Oxycodone" drug type enumerator.
	/// </summary>
	[Drug("Oxycodone", "A semi-synthetic opioid, highly addictive and a common drug of abuse.", AverageValue = 20, Probability = 0.9f)]
	OXY,
}
