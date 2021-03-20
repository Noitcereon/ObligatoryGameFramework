using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DTurnBasedGameFramework.Interfaces;
using _2DTurnBasedGameFramework.Models.BaseModels;

namespace _2DTurnBasedGameFramework.Models
{
    public class InteractableWorldObject : BaseWorldObject
    {
        public InteractableWorldObject(string name, Point position) : base(name, position)
        {
            IsInteractable = true;
            IsRemovable = true;
        }

        public void OnInteraction(BaseCreature creature)
        {
            creature.InteractWithWorldObject();
            throw new NotImplementedException();
        }
    }
}
