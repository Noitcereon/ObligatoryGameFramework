using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DTurnBasedGameFramework.Models.BaseModels;

namespace _2DTurnBasedGameFramework.Models
{
    public class ImpassableTerrain : BaseWorldObject
    {
        public ImpassableTerrain(string name, Point position) : base(name, position)
        {
            IsInteractable = false;
            IsRemovable = false;
        }

        public override void OnInteraction(BaseCreature creature)
        {
            // Do nothing.
        }
    }
}
