using _2DTurnBasedGameFramework.Models.BaseModels;

namespace _2DTurnBasedGameFramework.AbstractFactory.CreatureProducts
{
    /// <summary>
    /// Creature created through the CreatureFactory (which inherits from ICreatureFactory)
    /// </summary>
    public class MeleeCreature : GenericCreature
    {
        /// <summary>
        /// Empty constructor. Only here for json convertion.
        /// </summary>
        public MeleeCreature()
        {
        }
        /// <summary>
        /// Makes a MeleeCreature based on another BaseCreature's stats.
        /// </summary>
        /// <param name="creature"></param>
        public MeleeCreature(BaseCreature creature)
        {
            Id = creature.Id;
            Name = creature.Name;
            Attack = creature.Attack;
            Defense = creature.Defense;
            Damage = creature.Damage;
            Hitpoints = creature.Hitpoints;
            Position = creature.Position;
        }

        /// <inheritdoc />
        public override int DamageModifier()
        {
            return Attack;
        }

        /// <inheritdoc />
        public override void AdditionalHitModification()
        {
            // No special effect on hit.
        }
    }
}
