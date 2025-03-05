using AutoBogus;
using RuneDex.DiabloII.Resurrected.WASM.Models;

namespace RuneDex.DiabloII.Resurrected.Test.Unit.WASM.Fakers
{
	public class ItemTypeFaker : AutoFaker<ItemType>
	{
		public ItemTypeFaker()
		{
			RuleFor(it => it.Selected, false);
		}

		public ItemTypeFaker Selected()
		{
			RuleFor(it => it.Selected, true);

			return this;
		}
	}
}
