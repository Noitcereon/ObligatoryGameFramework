using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DTurnBasedGameFramework.Interfaces
{
    public interface IWorldObject
    {
        /// <summary>
        /// A GUID for the object.
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Determines whether creatures can interact with this object or not.
        /// </summary>
        bool IsInteractable { get; set; }

        /// <summary>
        /// Determines whether the object is removeable.
        /// </summary>
        bool IsRemovable { get; set; }

        /// <summary>
        /// The World Objects placement in the world.
        /// </summary>
        Point Position { get; set; }

        string Name { get; set; }
    }
}
