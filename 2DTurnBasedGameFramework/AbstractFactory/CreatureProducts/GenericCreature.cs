using System.Drawing;
using _2DTurnBasedGameFramework.Models.BaseModels;
using Range = _2DTurnBasedGameFramework.Helpers.Range;

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

        public GenericCreature(string name, int attack, int defense, int hitpoints, Range damage) : base(name, attack, defense, hitpoints, damage)
        {
        }

        public GenericCreature(string name, int attack, int defense, int hitpoints, Range damage, Point position) : base(name, attack, defense, hitpoints, damage, position)
        {
        }

        public GenericCreature(string name, int attack, int defense, int hitpoints, Range damage, bool isCaster) : base(name, attack, defense, hitpoints, damage, isCaster)
        {
        }

        public GenericCreature(string name, int attack, int defense, int hitpoints, Range damage, Point position, bool isCaster) : base(name, attack, defense, hitpoints, damage, position, isCaster)
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
