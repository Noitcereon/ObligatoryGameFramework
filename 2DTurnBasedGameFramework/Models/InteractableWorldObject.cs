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
    /// <summary>
    /// Represents an interactable world object.
    /// </summary>
    public class InteractableWorldObject : BaseWorldObject
    {
        private Action<BaseCreature> _actionOnInteraction;

        public InteractableWorldObject(string name, Point position) : base(name, position)
        {
            IsInteractable = true;
            IsRemovable = true;
        }
        public InteractableWorldObject(BaseItem item, Point position) : base(item, position)
        {
            IsInteractable = true;
            IsRemovable = true;
        }

        /// <summary>
        /// The constructor for an interactable object that is not an item.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        /// <param name="isRemovable"></param>
        public InteractableWorldObject(string name, Point position, bool isRemovable, Action<BaseCreature> action)
        {
            Name = name;
            IsInteractable = true;
            IsRemovable = isRemovable;
            Position = position;
        }

        /// <inheritdoc />
        public override void OnInteraction(BaseCreature creature)
        {
            action.Invoke(creature);
            if (IsRemovable)
            {
                Position = new Point(-1, -1); // TODO: Remove from world in another way.
            }
        }
    }
}
