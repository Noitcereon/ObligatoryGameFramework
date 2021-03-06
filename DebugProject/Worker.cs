using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DTurnBasedGameFramework;
using _2DTurnBasedGameFramework.AbstractFactory.BaseFactories;
using _2DTurnBasedGameFramework.AbstractFactory.Factories;
using _2DTurnBasedGameFramework.Helpers;
using _2DTurnBasedGameFramework.Models;
using _2DTurnBasedGameFramework.Models.BaseModels;
using _2DTurnBasedGameFramework.Prefabs;
using DebugProject.CustomCreatures;

namespace DebugProject
{
    public class Worker
    {
        public void Start()
        {
            World world = new World(20, 20);

            world.GenerateWorld();
            world.WriteWorldToConsole();

            PrefabCreatures creatures = new PrefabCreatures();
            var centaur = creatures.Centaur;
            var mage = creatures.Mage;
            var peasant = creatures.Peasant;

            ICreatureFactory creatureFactory = new CreatureFactory();
            var ogre = creatureFactory.CreateCreature("Ogre", 10, 10, 50, new CustomRange(5, 10));

            var vampire = creatureFactory.CreateCreature<VampiricCreature>("Vampire", 10, 5, 30, new CustomRange(3, 7));

            vampire.Attach(world);
            ogre.Attach(world);

            mage.Loot(new Item("Staff", 2));

            Console.WriteLine(mage);
            Console.WriteLine(vampire);

            CombatLoop(vampire, ogre);

            Logger.Close();
        }


        private void CombatLoop(BaseCreature creature1, BaseCreature creature2)
        {
            while (!creature1.IsDead && !creature2.IsDead)
            {
                CombatRound(creature1, creature2);

                if (creature1.IsDead)
                {
                    Console.WriteLine($"{creature1.Name} died.");
                }
                else if (!creature1.IsDead && creature2.IsDead)
                {
                    Loot(creature2, creature1);
                    Console.WriteLine(creature1);
                }

                if (creature2.IsDead)
                {
                    Console.WriteLine($"{creature2.Name} died.");
                }
                else if (!creature2.IsDead && creature1.IsDead)
                {
                    Loot(creature1, creature2);
                    Console.WriteLine(creature2);
                }
            }
        }

        private void CombatRound(BaseCreature creature1, BaseCreature creature2)
        {
            Console.WriteLine($"{creature2.Name} takes {creature2.ReceiveHit(creature1.Hit())} damage from {creature1.Name}.");
            Console.WriteLine($"{creature1.Name} takes {creature1.ReceiveHit(creature2.Hit())} damage from {creature2.Name}.");
        }

        private void Loot(BaseCreature corpse, BaseCreature looter)
        {
            Console.WriteLine($"{looter.Name} loots {corpse.Name}'s corpse.");
            if (corpse.Items.Count == 0 || corpse.Items == null)
            {
                Console.WriteLine($"{looter.Name} found nothing.");
                return;
            }

            Console.WriteLine($"{looter.Name} picked up: ");
            foreach (var item in corpse.Items)
            {
                looter.Loot(item);
                Console.WriteLine($"- {item.Name}");
            }
        }
    }
}
