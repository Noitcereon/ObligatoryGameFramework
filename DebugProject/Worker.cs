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
            World world = new World(20, 20);

            world.GenerateWorld();
            world.WriteWorldToConsole();

            PrefabCreatures creatures = new PrefabCreatures();
            var centaur = creatures.Centaur;
            var goblin = creatures.Goblin;
            var peasant = creatures.Peasant;

            Logger.Close();
        }
    }
}
