using _2DTurnBasedGameFramework.Models.BaseModels;
using Range = _2DTurnBasedGameFramework.Helpers.Range;

namespace _2DTurnBasedGameFramework.AbstractFactory.BaseFactories
{
    public abstract class CreatureFactory
    {
        public abstract BaseCreature CreateCreature(string name, int atk, int def, int hp, Range dmgRange, bool isCaster);
    }
}
