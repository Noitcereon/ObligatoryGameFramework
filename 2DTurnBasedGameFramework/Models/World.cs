using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DTurnBasedGameFramework.Interfaces;

namespace _2DTurnBasedGameFramework.Models
{
    public class World : IWorld
    {
        public int X { get; set; }
        public int Y { get; set; }

        public World(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
