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
    public abstract class ItemWorldObject : IWorldObject
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public Point Position { get; set; }
        public bool IsInteractable { get; set; }
        public bool IsRemovable { get; set; }
        private readonly TraceSource _logger;

        protected ItemWorldObject(string name, Point position)
        {
            _logger = new TraceSource("ItemWorldObject", SourceLevels.Information);
            Name = name;
            Position = position;
            IsInteractable = true;
            IsRemovable = true;
        }

        protected ItemWorldObject(string name, Point position, bool isInteractable, bool isRemovable)
        {
            Name = name;
            IsInteractable = isInteractable;
            IsRemovable = isRemovable;
            Position = position;
        }
        
        public virtual void OnInteraction()
        {
            if (!IsInteractable) { return; }

            _logger.TraceEvent(TraceEventType.Information, Id);
            if (IsRemovable)
            {
                Position = new Point(-1, -1);
            }
        }
    }
}
