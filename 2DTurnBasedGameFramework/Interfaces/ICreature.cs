using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DTurnBasedGameFramework.Interfaces
{
    /// <summary>
    /// Describes a creatures stats, name, position and atk/defense behaviour.
    /// </summary>
    public interface ICreature
    {
        #region Properties
        int Id { get; set; }

        /// <summary>
        /// The attack stat for the creature. Gives bonus to damage dealt when attacking.
        /// </summary>
        int Attack { get; set; }

        /// <summary>
        /// The defense stat for the creature. Reduces damage taken from attacks.
        /// </summary>
        int Defense { get; set; }

        /// <summary>
        /// The Spell Power stat for the creature. Increases the effectiveness of spells cast.
        /// </summary>
        int SpellPower { get; set; }

        /// <summary>
        /// The amount of hit points the creature has.
        /// </summary>
        int Hitpoints { get; set; }

        /// <summary>
        /// The name of the creature type. (e.g. Medusa, Azure Dragon, Swashbuckler...)
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Determines whether or not the creature can cast magic.
        /// </summary>
        bool IsCaster { get; set; }

        /// <summary>
        /// The current position for the creature stack in the world.
        /// </summary>
        Point Position { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Controls the behaviour of the creature, when it is hitting another creature.
        /// </summary>
        /// <returns>The damage dealt</returns>
        int Hit();

        /// <summary>
        /// Controls the behaviour of the creature, when it is getting hit.
        /// </summary>
        /// <returns>The damage taken</returns>
        int ReceiveHit(int damage);
        #endregion
    }
}
