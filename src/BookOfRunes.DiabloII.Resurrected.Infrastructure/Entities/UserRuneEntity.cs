namespace BookOfRunes.DiabloII.Resurrected.Infrastructure.Entities
{
	public record UserRuneEntity
	{
		public int Id { get; set; }
		public UserEntity User { get; set; } = null!;
		public RuneEntity Rune { get; set; } = null!;
	}
}
