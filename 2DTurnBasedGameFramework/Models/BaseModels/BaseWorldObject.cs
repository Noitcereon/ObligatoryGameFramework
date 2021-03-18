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

        protected BaseWorldObject(string name, Point position)
        {
            Name = name;
            Position = position;
            IsInteractable = true;
            IsRemovable = true;
        }

        protected BaseWorldObject(string name, Point position, bool isInteractable, bool isRemovable)
        {
            Name = name;
            IsInteractable = isInteractable;
            IsRemovable = isRemovable;
            Position = position;
        }
        
        public virtual void OnInteraction()
        {
            if (!IsInteractable) { return; }

            Logger.Log(TraceEventType.Information, $"{Name} was interacted with. ID: {Id}");

            if (IsRemovable)
            {
                Position = new Point(-1, -1);
            }
        }
    }
}
