using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DTurnBasedGameFramework.Interfaces
{
    /// <summary>
    /// Contains properties for Attack, Defense, Hitpoints and Spellpower stats. 
    /// </summary>
    public interface IStats
    {
        /// <summary>
        /// The attack stat. Gives bonus to damage dealt when attacking.
        /// </summary>
        int Attack { get; set; }

        /// <summary>
        /// The defense stat. Reduces damage taken from attacks.
        /// </summary>
        int Defense { get; set; }

        /// <summary>
        /// The health stat. Determines how much damage something can take before they perish.
        /// </summary>
        int Hitpoints { get; set; }

        /// <summary>
        /// The Spell Power stat. Increases the effectiveness of spells cast.
        /// </summary>
        int SpellPower { get; set; }
    }
}
