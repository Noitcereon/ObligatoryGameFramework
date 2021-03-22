using _2DTurnBasedGameFramework.Models.BaseModels;

namespace _2DTurnBasedGameFramework.AbstractFactory.CreatureProducts
{
    public class MeleeCreature : BaseCreature
    {
        public MeleeCreature()
        {
        }
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
    }
}
