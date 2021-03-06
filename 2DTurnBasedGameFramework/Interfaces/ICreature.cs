using System;
using System.Collections.Generic;
using System.Drawing;
using _2DTurnBasedGameFramework.Models.BaseModels;
using CustomRange = _2DTurnBasedGameFramework.Helpers.CustomRange;

namespace _2DTurnBasedGameFramework.Interfaces
{
    /// <summary>
    /// Describes a creature's stats, name, position and attack/defense behaviour.
    /// </summary>
    public interface ICreature : IStats
    {
        #region Properties
        /// <summary>
        /// A GUID for the object.
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// The name of the creature type. (e.g. Medusa, Azure Dragon, Swashbuckler...)
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The creature's default damage range. Range has a From int value and a To int value. Both are inclusive.
        /// </summary>
        CustomRange Damage { get; set; }

        /// <summary>
        /// Determines if the creature is dead. This happens when the creature's hitpoints is 0 or below.
        /// </summary>
        bool IsDead { get; set; }

        /// <summary>
        /// Determines whether or not the creature can cast magic.
        /// </summary>
        bool IsCaster { get; set; }

        /// <summary>
        /// The current position of the creature in the world.
        /// </summary>
        Point Position { get; set; }
        #endregion

        #region Methods

        /// <summary>
        /// Adds an item to the Items property and adds the stats of the item to the creature.
        /// </summary>
        void Loot(BaseItem item);
        /// <summary>
        /// Controls the behavious of the creature, when it encounters a world object.
        /// </summary>
        void InteractWithWorldObject(BaseWorldObject worldObject);

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
