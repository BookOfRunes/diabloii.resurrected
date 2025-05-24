using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using STrain;

namespace BookOfRunes.DiabloII.Resurrected.Api
{
	[Authorize]
	public record SaveCharacterCommand : Command
	{
		public required string Name { get; init; }
		public required int Class { get; init; }
		public required int Level { get; init; }
	}

	public class SaveCharacterCommandValidator : AbstractValidator<SaveCharacterCommand>
	{
		public SaveCharacterCommandValidator()
		{
			RuleFor(c => c.Name).NotEmpty();
			RuleFor(c => c.Level).InclusiveBetween(1, 99);
		}
	}
}
