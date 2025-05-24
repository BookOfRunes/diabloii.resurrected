namespace BookOfRunes.DiabloII.Resurrected.Infrastructure.Entities
{
	public record CharacterEntity
	{
		public int Id { get; set; }
		public UserEntity User { get; set; } = null!;
		public string Name { get; set; } = null!;
		public ClassEntity Class { get; set; } = null!;
		public int Level { get; set; }
	}
}
