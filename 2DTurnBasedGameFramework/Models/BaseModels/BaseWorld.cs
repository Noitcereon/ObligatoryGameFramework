using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using _2DTurnBasedGameFramework.AbstractFactory.Factories;
using _2DTurnBasedGameFramework.Interfaces;
using _2DTurnBasedGameFramework.Interfaces.ObserverPattern;
using _2DTurnBasedGameFramework.Prefabs;

namespace _2DTurnBasedGameFramework.Models.BaseModels
{
    /// <summary>
    /// Contains the properties and methods that define the world.
    /// </summary>
    public abstract class BaseWorld : IWorld, IObserver
    {
        private readonly PrefabCreatures _premadeCreatures = new PrefabCreatures();

        /// <inheritdoc />
        public int X { get; set; }
        /// <inheritdoc />
        public int Y { get; set; }

        /// <summary>
        /// A list of all the objects in the world. It is used to keep track of locations of the objects
        /// and to remove objects from the world, when applicable.
        /// </summary>
        public List<BaseWorldObject> WorldObjects { get; private set; } = new List<BaseWorldObject>();

        /// <summary>
        /// A list of all the creatures in the world. It is used to keep track of locations of the creatures and
        /// to remove them from the world when they die.
        /// </summary>
        public List<BaseCreature> Creatures { get; private set; } = new List<BaseCreature>();

        /// <summary>
        /// A world constructor. Defines the size of the world.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        protected BaseWorld(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// A very simple world generator. Can be overwritten.
        /// You ought to always reset WorldObjects and Creatures List at the beginning.
        /// </summary>
        public virtual void GenerateWorld()
        {
            WorldObjects = new List<BaseWorldObject>();
            Creatures = new List<BaseCreature>();
            Random random = new Random();
            for (int x = 0; x < X; x++)
            {
                for (int y = 0; y < Y; y++)
                {
                    PlaceObject(random.Next(1, 11), x, y);
                }
            }
            Logger.Log(TraceEventType.Information, "Generated world.");
        }

        /// <summary>
        /// Used in the default world generator to add objects to the world at pseudo-random locations.
        /// </summary>
        /// <param name="randomifier">A pseudo random number. If the number is divisible by 10 and the remainder is 0 you place a mountain
        /// else if you divide by 8 and the remainder is 0 you get an item, else if you divide by 2 and the remainder is 0 you place a creature.</param>
        /// <param name="x">x coordinate for the object</param>
        /// <param name="y">y coordinate for the object</param>
        protected virtual void PlaceObject(int randomifier, int x, int y)
        {
            if(WorldObjects.Contains(WorldObjects.Find(obj => obj.Position == new Point(x, y)))) return;
            if(Creatures.Contains(Creatures.Find(obj => obj.Position == new Point(x, y)))) return;

            if (randomifier % 10 == 0)
            {
                WorldObjects.Add(new ImpassableTerrain("Mountain", new Point(x, y)));
            }
            else if (randomifier % 8 == 0)
            {
                WorldObjects.Add(new InteractableWorldObject(new Item("Angel Statue"), new Point(x, y)));
            }
            else if (randomifier % 2 == 0)
            {
                Random random = new Random();
                BaseCreature creature;
                switch (random.Next(0, 3))
                {
                    case 0:
                        creature = _premadeCreatures.Centaur;
                        break;
                    case 1:
                        creature = _premadeCreatures.Goblin;
                        break;
                    case 2:
                        creature = _premadeCreatures.Mage;
                        break;
                    default:
                        creature = _premadeCreatures.Peasant;
                        break;
                }
                 
                creature.Position = new Point(x, y);
                creature.Attach(this);
                Creatures.Add(creature);
            }
        }

        /// <inheritdoc />
        public virtual void Update(ISubject subject)
        {
            if (subject is BaseCreature creature)
            {
                if (creature.IsDead)
                {
                    Creatures.Remove(creature);
                }
            }
            if (subject is InteractableWorldObject worldObject)
            {
                WorldObjects.Remove(worldObject);
            }
        }
    }
}
