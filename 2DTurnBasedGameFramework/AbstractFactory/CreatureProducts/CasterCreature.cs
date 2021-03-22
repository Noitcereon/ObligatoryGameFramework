using _2DTurnBasedGameFramework.Models.BaseModels;

namespace _2DTurnBasedGameFramework.AbstractFactory.CreatureProducts
{
    public class CasterCreature : BaseCreature
    {
        public CasterCreature() { }
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
