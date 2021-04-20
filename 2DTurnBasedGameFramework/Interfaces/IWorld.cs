using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DTurnBasedGameFramework.Models.BaseModels;

namespace _2DTurnBasedGameFramework.Interfaces
{
    /// <summary>
    /// Defines a basic world containing a width and a height (X and Y).
    /// </summary>
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
