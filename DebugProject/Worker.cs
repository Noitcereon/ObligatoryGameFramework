using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DTurnBasedGameFramework;
using _2DTurnBasedGameFramework.Models;
using _2DTurnBasedGameFramework.Models.BaseModels;
using _2DTurnBasedGameFramework.Prefabs;

namespace DebugProject
{
    public class Worker
    {
        public void Start()
        {
            World world = new World(50, 20);

            world.GenerateWorld();
            world.WriteWorldToConsole();

            PrefabCreatures creatures = new PrefabCreatures();
            var centaur = creatures.Centaur;
            var goblin = creatures.Goblin;
            var peasant = creatures.Peasant;

            goblin.Loot(new Item("Club", 2));
            Console.WriteLine(goblin);
            Console.WriteLine(centaur);

            CombatLoop(centaur, goblin);

            Logger.Close();
        }

        private void CombatRound(BaseCreature c1, BaseCreature c2)
        {
            Console.WriteLine($"{c2.Name} takes {c2.ReceiveHit(c1.Hit())} damage from {c1.Name}.");
            Console.WriteLine($"{c1.Name} takes {c1.ReceiveHit(c2.Hit())} damage from {c2.Name}.");
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

        private void Loot(BaseCreature corpse, BaseCreature looter)
        {
            Console.WriteLine($"{looter.Name} loots {corpse.Name}'s corpse.");
            if (corpse.Items.Count == 0)
            {
                Console.WriteLine($"{looter.Name} found nothing.");
            }
            else
            {
                Console.WriteLine($"{looter.Name} picked up: ");
                foreach (var item in corpse.Items)
                {
                    looter.Loot(item);
                    Console.WriteLine($"- {item.Name}");
                }
            }
        }
    }
}
