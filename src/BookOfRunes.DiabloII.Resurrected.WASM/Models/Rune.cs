namespace BookOfRunes.DiabloII.Resurrected.WASM.Models
{
	public record Rune : INotifyPropertyChanged
	{

		public required int Id { get; init; }

		private bool selected = true;
		public bool Selected
		{
			get { return selected; }
			set { selected = value; PropertyChanged?.Invoke(this, EventArgs.Empty); }
		}
		public required string Name { get; init; }
		public required int? Level { get; init; }
		public required string InHelmet { get; init; } = null!;
		public required string InBodyArmor { get; init; } = null!;
		public required string InShield { get; init; } = null!;
		public required string InWeapon { get; init; } = null!;

		public event EventHandler<EventArgs> PropertyChanged;
	}
}
