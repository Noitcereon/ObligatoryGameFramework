using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DTurnBasedGameFramework.Interfaces;

namespace _2DTurnBasedGameFramework.Models.BaseModels
{
    public abstract class BaseWorldGenerator : IWorldGenerator
    {
        public IWorld World { get; set; }

        protected BaseWorldGenerator()
        {
            
        }

        protected BaseWorldGenerator(int x, int y)
        {
            World = new World(x, y);
        }

        protected BaseWorldGenerator(IWorld world)
        {
            World = world;
        }

        public virtual void GenerateWorld()
        {
            int y = 0;
            for (int x = 0; x < World.X; x++)
            {
                // Do something on the X axis
                if (x == 5 && y == 4)
                {
                    IWorldObject terrain = new ImpassableTerrain("Mountain", new Point(x, y));
                }
                for (int j = 0; j < World.Y; j++)
                {
                    // Do something on the Y axis
                    y = j;
                    if (y == 10)
                    {
                        IWorldObject item = new InteractableWorldObject("Bucket", new Point(x, y));
                    }
                }
            }
        }
    }
}
