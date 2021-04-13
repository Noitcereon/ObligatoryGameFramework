using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DTurnBasedGameFramework.Interfaces;
using _2DTurnBasedGameFramework.Interfaces.ObserverPattern;
using _2DTurnBasedGameFramework.Models.BaseModels;

namespace _2DTurnBasedGameFramework.Models
{
    /// <summary>
    /// Represents an interactable world object.
    /// </summary>
    public class InteractableWorldObject : BaseWorldObject, ISubject
    {
        private readonly Action<BaseCreature> _actionOnInteraction;
        private List<IObserver> _observers; 

        /// <summary>
        /// The constructor for an Item World Object
        /// </summary>
        /// <param name="item">The item that can be picked up, when interacting with this world object.</param>
        /// <param name="position">Position in the world.</param>
        public InteractableWorldObject(BaseItem item, Point position) : base(item.Name, position)
        {
            IsInteractable = true;
            IsRemovable = true;
            Item = item;
        }

        /// <summary>
        /// The constructor for an interactable object that is not an item.
        /// </summary>
        /// <param name="name">The name of the object</param>
        /// <param name="position">The position of the object in the world.</param>
        /// <param name="action">The code that gets triggered on interaction with the object.</param>
        public InteractableWorldObject(string name, Point position, Action<BaseCreature> action)
        {
            Name = name;
            IsInteractable = true;
            Position = position;
            _actionOnInteraction = action;
        }

        /// <summary>
        /// The constructor for an interactable object that is not an item.
        /// </summary>
        /// <param name="name">The name of the object</param>
        /// <param name="position">The position of the object in the world.</param>
        /// <param name="isRemovable">Determines if the object is removable or not.</param>
        /// <param name="action">The code that gets triggered on interaction with the object.</param>
        public InteractableWorldObject(string name, Point position, bool isRemovable, Action<BaseCreature> action)
        {
            Name = name;
            IsInteractable = true;
            IsRemovable = isRemovable;
            Position = position;
            _actionOnInteraction = action;
        }

        /// <inheritdoc />
        public override void OnInteraction(BaseCreature creature)
        {
            try
            {
                _actionOnInteraction.Invoke(creature);
                if (IsRemovable)
                {
                    Notify(); // Notifies the World it is placed in that it should be removed.
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Logger.Log(TraceEventType.Error, "Interaction with world object threw an exception.");
                Logger.Log(TraceEventType.Verbose, $"StackTrace: {e.StackTrace}");
            }
        }

        /// <inheritdoc />
        public void Attach(IObserver observer)
        {
            if (_observers == null) _observers = new List<IObserver>();
            if (_observers.Contains(observer)) return; // prevent the same observer from observing multiple times.
            _observers.Add(observer);
        }

        /// <inheritdoc />
        public void Notify()
        {
            _observers?.ForEach(o => o.Update(this));
        }
    }
}
