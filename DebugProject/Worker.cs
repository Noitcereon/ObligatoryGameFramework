using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DTurnBasedGameFramework.Models.BaseModels;

namespace DebugProject
{
    public class Worker
    {
        public void Start()
        {
            World world = new World(20, 20);

            world.GenerateWorld();
            world.WriteWorldToConsole();
        }
    }
}
