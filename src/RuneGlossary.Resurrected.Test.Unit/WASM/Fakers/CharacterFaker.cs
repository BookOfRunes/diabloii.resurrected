using AutoBogus;
using RuneGlossary.Resurrected.WASM.Models;

namespace RuneGlossary.Resurrected.Test.Unit.WASM.Fakers
{
	public class CharacterFaker : AutoFaker<Character>
	{
		public CharacterFaker()
		{
			RuleFor(c => c.Filters, new List<ItemType>());
		}

		public CharacterFaker Filter(IEnumerable<ItemType> filters)
		{
			RuleFor(c => c.Filters, filters);

			return this;
		}
	}
}
