using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DTurnBasedGameFramework.Models.BaseModels;

namespace DebugProject
{
    public class World : BaseWorld
    {
        public World(int x, int y) : base(x, y)
        {
        }

        public void WriteWorldToConsole()
        {
            for (int y = 0; y < Y; y++)
            {
                for (int x = 0; x < X; x++)
                {
                    Point p = new Point(x, y);
                    if (WorldObjects.Exists(obj => obj.Position == p))
                    {
                        var worldObject = WorldObjects.Find(obj => obj.Position == p);
                        Console.Write(worldObject.IsInteractable ? "O " : "# ");
                    }
                    else if (Creatures.Exists(obj => obj.Position == p))
                    {
                        Console.Write("@ ");
                    }
                    else
                    {
                        Console.Write("x ");
                    }
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}
