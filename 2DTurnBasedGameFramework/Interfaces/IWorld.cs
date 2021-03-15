using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DTurnBasedGameFramework.Interfaces
{
    public interface IWorld
    {
        /// <summary>
        /// Determines the Width of the world.
        /// </summary>
        int X { get; set; }

        /// <summary>
        /// Determines the Height of the world.
        /// </summary>
        int Y { get; set; }
    }
}
