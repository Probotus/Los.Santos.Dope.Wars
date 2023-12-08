using System.Collections;

using LSDW.Domain.Enumerators;
using LSDW.Domain.Extensions;
using LSDW.Domain.Factories;
using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Models.Base;

namespace LSDW.Domain.Models;

/// <summary>
/// The drug collection class.
/// </summary>
internal sealed class DrugCollection : NotifyPropertyBase, IDrugCollection
{
	private IEnumerable<IDrug> _drugs;
	private int _count;
	private int _value;

	/// <summary>
	/// Initializes a new instance of the drug collection class.
	/// </summary>
	public DrugCollection()
	{
		_drugs = DomainFactory.GetAllDrugs();
		_drugs.ForEach(drug => drug.PropertyChanged += (s, e) => Recalculate());
	}

	public int Count { get => _count; private set => SetProperty(ref _count, value); }
	public int Value { get => _value; private set => SetProperty(ref _value, value); }

	public void Add(DrugType drugType, int quantity, int value)
	{
		IDrug drug = Find(drugType);
		drug.Add(quantity, value);
	}

	public IDrug Find(DrugType drugType)
	 => Find(drug => drug.Type.Equals(drugType));

	public IDrug Find(Func<IDrug, bool> expression)
		=> _drugs.FirstOrDefault(expression);

	public IEnumerable<IDrug> FindMany(Func<IDrug, bool> expression)
		=> _drugs.Where(expression);

	public IEnumerator<IDrug> GetEnumerator()
		=> _drugs.GetEnumerator();

	public void Load(IEnumerable<IDrug> values)
	{
		_drugs.ForEach(drug => drug.PropertyChanged -= (s, e) => Recalculate());
		_drugs = values;
		_drugs.ForEach(drug => drug.PropertyChanged += (s, e) => Recalculate());
		Recalculate();
	}

	public void Recalculate()
	{
		Count = _drugs.Sum(drug => drug.Quantity);
		Value = _drugs.Sum(drug => drug.Quantity * drug.Value);
	}

	public void Remove(DrugType drugType, int quantity)
	{
		IDrug drug = Find(drugType);
		drug.Remove(quantity);
	}

	IEnumerator IEnumerable.GetEnumerator()
		=> _drugs.GetEnumerator();
}
