using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DTurnBasedGameFramework;
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
                    creature1.Items.AddRange(creature2.Items);
                    Console.WriteLine(creature1);
                }

                if (creature2.IsDead)
                {
                    Console.WriteLine($"{creature2.Name} died.");
                }
                else if (!creature2.IsDead && creature1.IsDead)
                {
                    creature2.Items.AddRange(creature1.Items);
                    Console.WriteLine(creature2);
                }
            }

        }
    }
}
