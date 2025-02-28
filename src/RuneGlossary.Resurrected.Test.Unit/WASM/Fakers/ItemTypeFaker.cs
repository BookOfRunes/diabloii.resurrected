using AutoBogus;
using RuneGlossary.Resurrected.WASM.Models;

namespace RuneGlossary.Resurrected.Test.Unit.WASM.Fakers
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
