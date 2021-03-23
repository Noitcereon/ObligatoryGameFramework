using _2DTurnBasedGameFramework.Models.BaseModels;

namespace _2DTurnBasedGameFramework.AbstractFactory.CreatureProducts
{
    /// <summary>
    /// Creature created through the CreatureFactory (which inherits from ICreatureFactory)
    /// A caster creature can make use of its SpellPower stat to increase its damage.
    /// </summary>
    public class CasterCreature : BaseCreature
    {
        /// <summary>
        /// Empty constructor. Only here for json purposes.
        /// </summary>
        public CasterCreature() { }
        /// <summary>
        /// Creates a caster creature, based on a BaseCreature's stats.
        /// </summary>
        /// <param name="creature">The creature that will become a caster.</param>
        public CasterCreature(BaseCreature creature)
        {
            Id = creature.Id;
            Name = creature.Name;
            Attack = creature.Attack;
            Defense = creature.Defense;
            Damage = creature.Damage;
            Hitpoints = creature.Hitpoints;
            IsCaster = true;
            SpellPower = 10;
            Position = creature.Position;
        }

        
        public override int Hit()
        {
            return base.Hit() + SpellPower;
        }
    }
}
