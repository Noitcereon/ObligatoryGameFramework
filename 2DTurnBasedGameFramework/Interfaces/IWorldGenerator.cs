using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DTurnBasedGameFramework.Models;

namespace _2DTurnBasedGameFramework.Interfaces
{
    public interface IWorldGenerator
    {
        IWorld World { get; set; }

        void GenerateWorld();
    }
}
