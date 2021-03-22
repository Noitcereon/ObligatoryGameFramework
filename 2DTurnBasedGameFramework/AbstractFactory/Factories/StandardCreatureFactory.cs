using System;
using _2DTurnBasedGameFramework.AbstractFactory.BaseFactories;
using _2DTurnBasedGameFramework.AbstractFactory.CreatureProducts;
using _2DTurnBasedGameFramework.Models;
using _2DTurnBasedGameFramework.Models.BaseModels;
using Range = _2DTurnBasedGameFramework.Helpers.Range;

namespace _2DTurnBasedGameFramework.AbstractFactory.Factories
{
    public class StandardCreatureFactory : CreatureFactory
    {
        public override BaseCreature CreateCreature(string name, int atk, int def, int hp, Range dmgRange, bool isCaster)
        {
            BaseCreature creature = new GenericCreature(name, atk, def, hp, dmgRange, isCaster);

            if (creature.IsCaster)
            {
                creature = new CasterCreature(creature);
            }

            return creature;
        }
    }
}
