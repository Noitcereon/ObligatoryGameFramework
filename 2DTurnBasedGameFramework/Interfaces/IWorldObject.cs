using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DTurnBasedGameFramework.Interfaces
{
    public interface IWorldObject
    {
        /// <summary>
        /// Determines whether creatures can interact with this object or not.
        /// </summary>
        bool IsInteractable { get; set; }

        /// <summary>
        /// Determines whether the object is removeable.
        /// </summary>
        bool IsRemovable { get; set; }

        string Name { get; set; }
    }
}
