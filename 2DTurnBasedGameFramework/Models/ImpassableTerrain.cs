using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DTurnBasedGameFramework.Models.BaseModels;

namespace _2DTurnBasedGameFramework.Models
{
    /// <summary>
    /// Impassable terrrain object. Non-interactable, non-removable.
    /// </summary>
    public class ImpassableTerrain : BaseWorldObject
    {
        /// <summary>
        /// Constructor for ImpassableTerrain.
        /// </summary>
        public ImpassableTerrain(string name, Point position) : base(name, position)
        {
            IsInteractable = false;
            IsRemovable = false;
        }

        /// <summary>
        /// Does nothing.
        /// </summary>
        public override void OnInteraction(BaseCreature creature)
        {
             // Do nothing.
        }
    }
}
