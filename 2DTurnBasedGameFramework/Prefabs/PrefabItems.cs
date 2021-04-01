using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DTurnBasedGameFramework.Models;
using _2DTurnBasedGameFramework.Models.BaseModels;

namespace _2DTurnBasedGameFramework.Prefabs
{
    /// <summary>
    /// Contains some prefabricated items, ready for use.
    /// </summary>
    public class PrefabItems
    {
        /// <summary>
        /// Ring of Power: SP: 10, HP: 2
        /// </summary>
        public BaseItem RingOfPower { get; set; } = new Item("Ring of Power", 0, 0, 10, 2);

        /// <summary>
        /// Sword: Atk: 3
        /// </summary>
        public BaseItem Sword { get; set; } = new Item("Sword", 3);

        /// <summary>
        /// Barbarian Axe: atk: 10, def: -5, HP: 5
        /// </summary>
        public BaseItem BarbarianAxe { get; set; } = new Item("Barbarian Axe", 10, -5, 0, 5);

        /// <summary>
        /// Wooden Shield: def: 5, hp 2
        /// </summary>
        public BaseItem WoodenShield { get; set; } = new Item("Wooden Shield", 0, 5, 0, 2);

        /// <summary>
        /// Breastplate: def: 10, SP: -2, HP: 5
        /// </summary>
        public BaseItem Breastplate { get; set; } = new Item("Breastplate", 0, 10, -2, 5);

        /// <summary>
        /// Helmet: random stats.
        /// </summary>
        public BaseItem Helmet { get; set; } = new Item("Helmet", true);

        /// <summary>
        /// Necklace: random stats.
        /// </summary>
        public BaseItem Necklace { get; set; } = new Item("Necklace", true);
    }
}
