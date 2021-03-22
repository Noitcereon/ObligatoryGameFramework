using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DTurnBasedGameFramework.Models;
using _2DTurnBasedGameFramework.Models.BaseModels;

namespace _2DTurnBasedGameFramework.Interfaces
{
    /// <summary>
    /// An interface that represents a world object. Example world objects: mountain, item, shrine.
    /// </summary>
    public interface IWorldObject
    {
        /// <summary>
        /// A GUID for the object.
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// A name to be read by the player and/or programmer to help understand the functionality of the object.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Determines whether creatures can interact with this object or not.
        /// </summary>
        bool IsInteractable { get; set; }

        /// <summary>
        /// Determines whether the object is removeable.
        /// </summary>
        bool IsRemovable { get; set; }

        /// <summary>
        /// If this property is NOT null, this world object is an Item that can be picked up.
        /// </summary>
        BaseItem Item { get; set; }

        /// <summary>
        /// The World Object's placement in the world.
        /// </summary>
        Point Position { get; set; }

        

        
    }
}
