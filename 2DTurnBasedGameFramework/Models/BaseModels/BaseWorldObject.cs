﻿using System;
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
        /// <inheritdoc />
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <inheritdoc />
        public string Name { get; set; }

        /// <inheritdoc />
        public Point Position { get; set; }

        /// <inheritdoc />
        public bool IsInteractable { get; set; }

        /// <inheritdoc />
        public bool IsRemovable { get; set; }

        /// <inheritdoc />
        public BaseItem Item { get; set; }

        /// <summary>
        /// Creates a world object with a name and a position. It is neither interactable nor removable.
        /// </summary>
        /// <param name="name">Name of the object.</param>
        /// <param name="position">The World Objects placement in the world.</param>
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
        /// <param name="item">The item that can be picked up, when interacting with this world object.</param>
        /// <param name="position">Position in the world.</param>
        protected BaseWorldObject(BaseItem item, Point position):this(item.Name, position)
        {
            IsInteractable = true;
            IsRemovable = true;
            Item = item;
        }

        /// <summary>
        /// Defines what happens, when a creature interacts with this WorldObject.
        /// </summary>
        /// <param name="creature"></param>
        public abstract void OnInteraction(BaseCreature creature);

    }
}
