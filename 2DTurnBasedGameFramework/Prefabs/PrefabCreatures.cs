using _2DTurnBasedGameFramework.AbstractFactory.BaseFactories;
using _2DTurnBasedGameFramework.AbstractFactory.Factories;
using _2DTurnBasedGameFramework.Helpers;
using _2DTurnBasedGameFramework.Models.BaseModels;

namespace _2DTurnBasedGameFramework.Prefabs
{
    /// <summary>
    /// Contains some prefabricated creatures, ready for use.
    /// </summary>
    public class PrefabCreatures
    {
        // TODO: make Ready-For-Use creatures and items (in the Prefabs folder), for someone to set up a game fast.
        
        private static readonly ICreatureFactory Factory = new CreatureFactory();

        // Note: should probably be returned through methods, not properties.

        // Creatures (from weak, to strong)
        // Tier 1
        /// <summary>
        /// Peasant: 3 atk, 0 def, 5 hp, 1-1 dmg;
        /// </summary>
        public BaseCreature Peasant { get; set; } = Factory.CreateCreature("Peasant", 3, 0, 5, new CustomRange(1, 1));

        /// <summary>
        /// Goblin: 4 atk, 2 def, 10 hp, 1-3 dmg
        /// </summary>
        public BaseCreature Goblin { get; set; } = Factory.CreateCreature("Goblin", 4, 2, 8, new CustomRange(1, 3));

        /// <summary>
        /// Centaur: 4 atk, 3 def, 15 hp, 1-3 dmg
        /// </summary>
        public BaseCreature Centaur { get; set; } = Factory.CreateCreature("Centaur", 4, 3, 15, new CustomRange(1, 3));

        // Tier 2
        /// <summary>
        /// Wolf Rider: 5 atk, 4 def, 15 hp, 3-5 dmg
        /// </summary>
        public BaseCreature WolfRider { get; set; } = Factory.CreateCreature("Wolf Rider", 5, 4, 15, new CustomRange(3, 5));
        // gargoyle
        // harpie

        // Tier 3
        // woodelf
        // orc
        // golem

        // Tier 4
        // pegasus rider
        // medusa
        /// <summary>
        /// Mage: 5 atk, 4 def, 20 hp, 5-8 dmg, isCaster = true
        /// </summary>
        public BaseCreature Mage { get; set; } = Factory.CreateCreature("Mage", 5, 4, 20, new CustomRange(5, 8), true);

        // Tier 5
        // dendroid
        // thunderbird
        // gorgon

        // Tier 6
        // cyclops
        // dread knight
        // champion

        // Tier 7
        // black dragon
        // titan
        // chaos hydra
    }
}
