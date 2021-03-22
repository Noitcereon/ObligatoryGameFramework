using System;
using System.Diagnostics;
using _2DTurnBasedGameFramework.AbstractFactory.BaseFactories;
using _2DTurnBasedGameFramework.AbstractFactory.CreatureProducts;
using _2DTurnBasedGameFramework.Models;
using _2DTurnBasedGameFramework.Models.BaseModels;
using Range = _2DTurnBasedGameFramework.Helpers.Range;

namespace _2DTurnBasedGameFramework.AbstractFactory.Factories
{
    public class StandardCreatureFactory : CreatureFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Name of the creature. (e.g. Medusa, Dragon, Wolf Rider etc.)</param>
        /// <param name="atk">Attack bonus. Increases damage dealt.</param>
        /// <param name="def">Defense bonus. Decreases damage taken.</param>
        /// <param name="hp">Hitpoints. Determines how much damage to take before dying.</param>
        /// <param name="dmgRange">The base damage range for the creature.</param>
        /// <param name="isCaster">Determines if the creature is a caster or not. If it is, it gains additional damage from SpellPower</param>
        /// <returns>A creature that inherits from BaseCreature</returns>
        public override BaseCreature CreateCreature(string name, int atk, int def, int hp, Range dmgRange, bool isCaster)
        {
            try
            {
                BaseCreature creature = new GenericCreature(name, atk, def, hp, dmgRange, isCaster);

                if (creature.IsCaster)
                {
                    creature = new CasterCreature(creature);
                }
                return creature;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Logger.Log(TraceEventType.Critical, $"Creature creation error. Error message: {e.Message}");
                Logger.Log(TraceEventType.Verbose, $"StackTrace: {e.StackTrace}");
                throw;
            }
        }
    }
}
