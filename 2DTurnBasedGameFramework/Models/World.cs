using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DTurnBasedGameFramework.Interfaces;
using _2DTurnBasedGameFramework.Models.BaseModels;

namespace _2DTurnBasedGameFramework.Models
{
    public class World : IWorld
    {
        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// A list of all the objects in the world. It is used to keep track of locations of the objects
        /// and to remove objects from the world, when applicable.
        /// </summary>
        public List<BaseWorldObject> WorldObjects { get; private set; }

        public World(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// A very simple world generator. Can be overwritten.
        /// </summary>
        public virtual void GenerateWorld()
        {
            WorldObjects = new List<BaseWorldObject>();
            Random random = new Random();
            for (int x = 0; x < X; x++)
            {
                for (int y = 0; y < Y; y++)
                {
                    PlaceObject(random.Next(1, 11), x, y);
                }
            }
        }

        /// <summary>
        /// Used in the simple world generator to add objects to the world at pseudo-random locations.
        /// </summary>
        /// <param name="randomifier">A random number. If the number is divisible by 10 and the remainder is 0 you place a mountain
        /// else if you divide by 8 and the remainder is 0 you get an item.</param>
        /// <param name="x">x coordinate for the object</param>
        /// <param name="y">y coordinate for the object</param>
        private void PlaceObject(int randomifier, int x, int y)
        {
            if (randomifier % 10 == 0)
            {
                WorldObjects.Add(new ImpassableTerrain("Mountain", new Point(x, y)));
            }
            else if (randomifier % 8 == 0)
            {
                WorldObjects.Add(new InteractableWorldObject("Item", new Point(x, y)));
            }
        }
    }
}
