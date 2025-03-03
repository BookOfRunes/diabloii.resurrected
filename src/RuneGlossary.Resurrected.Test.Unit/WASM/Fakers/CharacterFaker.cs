using AutoBogus;
using RuneGlossary.Resurrected.WASM.Models;

namespace RuneGlossary.Resurrected.Test.Unit.WASM.Fakers
{
	public class CharacterFaker : AutoFaker<Character>
	{
		public CharacterFaker()
		{
			RuleFor(c => c.Level, f => f.Random.Int(1, 99));
		}

		public CharacterFaker Filter(IEnumerable<ItemType> filters)
		{
			RuleFor(c => c.Filters, new FilterData
			{
				ItemTypes = filters
			});

			return this;
		}
	}
}
