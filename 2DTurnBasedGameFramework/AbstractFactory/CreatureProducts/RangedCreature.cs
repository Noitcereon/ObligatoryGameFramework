using _2DTurnBasedGameFramework.Models.BaseModels;

namespace _2DTurnBasedGameFramework.AbstractFactory.CreatureProducts
{
    /// <summary>
    /// Creature created through the CreatureFactory (which inherits from ICreatureFactory)
    /// <remarks>Ranged is not yet implemented.</remarks>
    /// </summary>
    public class RangedCreature : BaseCreature
    {
        public RangedCreature()
        {
            
        }

        public RangedCreature(BaseCreature creature)
        {
            Id = creature.Id;
            Name = creature.Name;
            Attack = creature.Attack;
            Defense = creature.Defense;
            Damage = creature.Damage;
            Hitpoints = creature.Hitpoints;
            Position = creature.Position;
            // TODO: Implement Ranged Attack
        }


        /// <inheritdoc />
        public override int DamageModifier()
        {
            return Attack;
        }
    }
}
