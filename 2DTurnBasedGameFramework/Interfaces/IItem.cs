using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DTurnBasedGameFramework.Interfaces
{
    public interface IItem
    {
        /// <summary>
        /// A GUID for the object.
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// The bonus it gives to attack for the creature holding the item.
        /// </summary>
        int Attack { get; set; }

        /// <summary>
        /// The bonus it gives to defense for the creature holding the item.
        /// </summary>
        int Defense { get; set; }

        /// <summary>
        /// The bonus it gives to Spell Power for the creature holding the item.
        /// </summary>
        int SpellPower { get; set; }

        /// <summary>
        /// The bonus it gives to Hitpoints for the creature holding the item.
        /// </summary>
        int Hitpoints { get; set; }
    }
}
