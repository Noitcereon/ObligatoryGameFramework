using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DTurnBasedGameFramework.Interfaces
{
    /// <summary>
    /// Interface descriping a basic item.
    /// </summary>
    public interface IItem : IStats
    {
        /// <summary>
        /// A GUID for the object.
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// The name of the item.
        /// <example>Examples: Simple Sword, Ring of Power, Helmet of Dexterity.</example>
        /// </summary>
        string Name { get; set; }

    }
}
