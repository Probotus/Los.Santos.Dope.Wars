using LSDW.Domain.Interfaces.Models;
using LSDW.Domain.Models.Base;

namespace LSDW.Domain.Models;

/// <summary>
/// The player class.
/// </summary>
internal sealed class Player : NotifyPropertyBase, IPlayer
{
	private readonly ISettings _settings;
	private const int LevelFactor = 3;
	private const int LevelMultiplicator = 1000;
	private const int MaximumLevel = 100;
	private int _bagSize;
	private int _exp;
	private int _expForNextLevel;
	private int _level;

	/// <summary>
	/// Initializes a new instance of the player class.
	/// </summary>
	public Player(ISettings settings)
	{
		_settings = settings;
		
		PropertyChanged += (s, e) => OnPropertyChanged(e.PropertyName);
		
		Exp = 1000;
		Drugs = new DrugCollection();
		Transactions = new TransactionCollection();
	}

	public int BagSize { get => _bagSize; private set => SetProperty(ref _bagSize, value); }
	public int Exp { get => _exp; private set => SetProperty(ref _exp, value); }
	public int ExpForNextLevel { get => _expForNextLevel; private set => SetProperty(ref _expForNextLevel, value); }
	public int Level { get => _level; private set => SetProperty(ref _level, value); }
	public IDrugCollection Drugs { get; }
	public ITransactionCollection Transactions { get; }

	public void AddExperience(int points)
	{
		if (Level == MaximumLevel)
			return;

		if (points < 1)
			throw new ArgumentOutOfRangeException(nameof(points), "Must be greater zero.");

		float expMultiplier = _settings.Player.ExperienceMultiplier.Value;

		if (expMultiplier != 1.0f)
			points = (int)Math.Abs(expMultiplier * points);

		if (Exp + points > 1000000000)
			points = 1000000000 - Exp;

		Exp += points;
	}

	public void Load(int experience, IEnumerable<IDrug> drugs, IEnumerable<ITransaction> transactions)
	{
		Exp = experience;
		Drugs.Load(drugs);
		Transactions.Load(transactions);
	}

	private void OnPropertyChanged(string propertyName)
	{
		if (propertyName == nameof(Exp))
		{
			CalculateNewLevel();
		}

		if (propertyName == nameof(Level))
		{
			BagSize = GetBagSizeByLevel();
			ExpForNextLevel = GetExpForNextLevel();
		}
	}

	/// <summary>
	/// Returns the current bag size based on the player level.
	/// </summary>
	/// <returns>The resulting bag size.</returns>
	private int GetBagSizeByLevel()
		=> Level * _settings.Player.BagSizePerLevel.Value;

	/// <summary>
	/// Returns the experience points needed for the next level.
	/// </summary>
	/// <returns>The resulting experience points.</returns>
	private int GetExpForNextLevel()
		=> (int)Math.Abs(Math.Pow(Level + 1, LevelFactor) * LevelMultiplicator);

	/// <summary>
	/// Calculates the new player level based on the experience points
	/// and the experience points needed for the next level.
	/// </summary>
	private void CalculateNewLevel()
	{
		while(Exp >= GetExpForNextLevel())
			Level++;
	}
}
