using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DTurnBasedGameFramework.Interfaces;

namespace _2DTurnBasedGameFramework.Models.BaseModels
{
    public abstract class BaseWorldObject : IWorldObject
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public Point Position { get; set; }
        public bool IsInteractable { get; set; }
        public bool IsRemovable { get; set; }
        public BaseItem Item { get; set; }

        protected BaseWorldObject(string name, Point position)
        {
            Name = name;
            Position = position;
        }

        protected BaseWorldObject(string name, Point position, bool isInteractable, bool isRemovable)
        {
            Name = name;
            IsInteractable = isInteractable;
            IsRemovable = isRemovable;
            Position = position;
        }

        /// <summary>
        /// The constructor for an Item World Object
        /// </summary>
        /// <param name="position">Position in the world.</param>
        /// <param name="item">The item that can be picked up, when interacting with this world object.</param>
        protected BaseWorldObject(BaseItem item, Point position):this(item.Name, position)
        {
            IsInteractable = true;
            IsRemovable = true;
            Item = item;
        }

        public abstract void OnInteraction(BaseCreature creature);

    }
}
