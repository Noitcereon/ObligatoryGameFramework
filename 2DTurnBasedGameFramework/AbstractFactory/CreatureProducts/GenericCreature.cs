using System.Drawing;
using _2DTurnBasedGameFramework.Models.BaseModels;
using CustomRange = _2DTurnBasedGameFramework.Helpers.CustomRange;

namespace _2DTurnBasedGameFramework.AbstractFactory.CreatureProducts
{
    /// <summary>
    /// A generic creature. Used in the creation of new creatures in the CreatureFactory.
    /// </summary>
    public class GenericCreature : BaseCreature
    {
        public GenericCreature():base()
        {
        }

        public GenericCreature(string name, int attack, int defense, int hitpoints, CustomRange damage) : base(name, attack, defense, hitpoints, damage)
        {
        }

        public GenericCreature(string name, int attack, int defense, int hitpoints, CustomRange damage, Point position) : base(name, attack, defense, hitpoints, damage, position)
        {
        }

        public GenericCreature(string name, int attack, int defense, int hitpoints, CustomRange damage, bool isCaster) : base(name, attack, defense, hitpoints, damage, isCaster)
        {
        }

        public GenericCreature(string name, int attack, int defense, int hitpoints, CustomRange damage, Point position, bool isCaster) : base(name, attack, defense, hitpoints, damage, position, isCaster)
        {
        }

        /// <inheritdoc />
        public override int DamageModifier()
        {
            return Attack;
        }

        /// <inheritdoc />
        public override void AdditionalHitModification()
        {
            // No special behaviour.
        }
    }
}
