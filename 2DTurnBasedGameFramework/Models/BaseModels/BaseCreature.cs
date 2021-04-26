using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using _2DTurnBasedGameFramework.Interfaces;
using _2DTurnBasedGameFramework.Interfaces.ObserverPattern;
using CustomRange = _2DTurnBasedGameFramework.Helpers.CustomRange;

namespace _2DTurnBasedGameFramework.Models.BaseModels
{
    /// <summary>
    /// <para>The Base class for all creatures.</para> Contains properties for stats, items and position,
    /// in addition to the methods: Hit(), ReceiveHit() and InteractWithWorldObject() +
    /// an overriden ToString().
    /// </summary>
    public abstract class BaseCreature : ICreature, ISubject
    {
        private bool _isDead;
        private List<IObserver> _observers;

        /// <inheritdoc />
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <inheritdoc />
        public bool IsDead
        {
            get => _isDead;
            set
            {
                _isDead = value;
                if (_isDead)
                {
                    Notify();
                }
            }
        }
        /// <inheritdoc />
        public string Name { get; set; }
        /// <inheritdoc />
        public int Attack { get; set; }
        /// <inheritdoc />
        public int Defense { get; set; }
        /// <inheritdoc />
        public int Hitpoints { get; set; }
        /// <inheritdoc />
        public CustomRange Damage { get; set; }
        /// <inheritdoc />
        public int SpellPower { get; set; }
        /// <inheritdoc />
        public bool IsCaster { get; set; }

        /// <summary>
        /// The creature's possessions. Each Item held increases power according to the item's stats.
        /// <remarks><para>Items should only be added to via the Loot method.</para></remarks>
        /// </summary>
        public List<BaseItem> Items { get; set; } = new List<BaseItem>();
        /// <inheritdoc />
        public Point Position { get; set; } = Point.Empty;

        // TODO: abstract the stats into a Stats class?

        #region Constructors
        /// <summary>
        /// Empty contructor.
        /// </summary>
        protected BaseCreature() { }

        /// <summary>
        /// The base constructor for a non-caster creature.
        /// </summary>
        /// <param name="name">Name of the creature type.</param>
        /// <param name="attack">The attack bonus of the creature.</param>
        /// <param name="defense">The defense bonus of the creature.</param>
        /// <param name="hitpoints">Total HP for the creature.</param>
        /// <param name="damage">The damage range for the creature. (can go over the limit with the Attack bonus)</param>
        protected BaseCreature(string name, int attack, int defense, int hitpoints, CustomRange damage)
        {
            Name = name;
            Attack = attack;
            Defense = defense;
            Hitpoints = hitpoints;
            Damage = damage;
            _observers = new List<IObserver>();
        }

        /// <summary>
        /// The base constructor for a non-caster creature with an initial position set.
        /// </summary>
        /// <param name="name">Name of the creature type.</param>
        /// <param name="attack">The attack bonus of the creature.</param>
        /// <param name="defense">The defense bonus of the creature.</param>
        /// <param name="hitpoints">Total HP for the creature.</param>
        /// <param name="damage">The damage range for the creature. (can go over the limit with the Attack bonus)</param>
        /// <param name="position">The initial position of the creature in a <c>World</c></param>
        protected BaseCreature(string name, int attack, int defense, int hitpoints, CustomRange damage, Point position) : this
            (name, attack, defense, hitpoints, damage)
        {
            Position = position;
        }

        /// <summary>
        /// The base constructor for a caster creature.
        /// </summary>
        /// <param name="name">Name of the creature type.</param>
        /// <param name="attack">The attack bonus of the creature.</param>
        /// <param name="defense">The defense bonus of the creature.</param>
        /// <param name="hitpoints">Total HP for the creature.</param>
        /// <param name="damage">The damage range for the creature. (can go over the limit with the Attack bonus)</param>
        /// <param name="isCaster">Determines wheter or not the creature is a caster.</param>
        protected BaseCreature(string name, int attack, int defense, int hitpoints, CustomRange damage, bool isCaster) : this
            (name, attack, defense, hitpoints, damage)
        {
            IsCaster = isCaster;
            if (IsCaster) SpellPower = 10;
        }

        /// <summary>
        /// The base constructor for a caster creature with an initial position set.
        /// </summary>
        /// <param name="name">Name of the creature type.</param>
        /// <param name="attack">The attack bonus of the creature.</param>
        /// <param name="defense">The defense bonus of the creature.</param>
        /// <param name="hitpoints">Total HP for the creature.</param>
        /// <param name="damage">The damage range for the creature. (can go over the limit with the Attack bonus)</param>
        /// <param name="position">The initial position of the creature in a <c>World</c></param>
        /// <param name="isCaster">Determines wheter or not the creature is a caster.</param>
        protected BaseCreature(string name, int attack, int defense, int hitpoints, CustomRange damage, Point position, bool isCaster) : this
            (name, attack, defense, hitpoints, damage)
        {
            IsCaster = isCaster;
            if (IsCaster) SpellPower = 10;
            Position = position;
        }
        #endregion

        #region Methods
        /// <inheritdoc />
        public void InteractWithWorldObject(BaseWorldObject worldObject)
        {
            if (worldObject.IsInteractable == false) return;

            if (worldObject.Item != null)
            {
                Loot(worldObject.Item);
                return;
            }

            // The behaviour of a non-item world object, when interacted with.
            worldObject.OnInteraction(this);
        }

        /// <inheritdoc />
        public void Loot(BaseItem item)
        {
            Items.Add(item);
            Attack += item.Attack;
            Defense += item.Defense;
            Hitpoints += item.Hitpoints;
            SpellPower += item.SpellPower;
            Logger.Log(TraceEventType.Information, "Item looted.");
        }

        /// <summary>
        /// This method calculates any additional damage, adding it on top of the base damage (number between Damage.From-Damage.To).
        /// <para>If you don't know what to add in this method just return the Attack stat.</para>
        /// </summary>
        /// <returns>Damage dealt in addition to base damage</returns>
        public abstract int DamageModifier();

        /// <summary>
        /// Any additional behaviour added to Hit() method. Such as healing on attack, enraging or similar.
        /// <para><remarks>Leave this method empty, if you do not want to add any behaviour.</remarks></para>
        /// </summary>
        public abstract void AdditionalHitModification();

        /// <inheritdoc />
        public virtual int Hit()
        {
            Random random = new Random();

            int baseDamage = random.Next(Damage.From, Damage.To);

            int damageDealt = baseDamage + DamageModifier();

            AdditionalHitModification();

            return damageDealt;
        }

        /// <inheritdoc />
        public virtual int ReceiveHit(int damage)
        {
            int damageTaken = damage - Defense;

            // Always take at least 1 damage.
            if (damageTaken <= 0) damageTaken = 1;
            Hitpoints -= damageTaken;
            IsDead = Hitpoints <= 0;
            return damageTaken;
        }

        /// <summary>
        /// Prints creature's information (all stats and items). Basically a character sheet.
        /// </summary>
        /// <returns>A formatted string representing the creature.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Name);
            sb.AppendLine($"Atk: {Attack}");
            sb.AppendLine($"Def: {Defense}");
            sb.AppendLine($"HP: {Hitpoints}");
            sb.AppendLine($"SP: {SpellPower}");
            sb.AppendLine($"Base dmg: {Damage.From}-{Damage.To}");
            sb.AppendLine($"Spellcaster: {(IsCaster ? "Yes" : "No")}");
            sb.AppendLine($"{(Items.Count <= 0 ? "Items: (none)" : "Items: ") }");
            string items = Items.Aggregate("", (current, item) => current + ($"{item.Name}\n" + item));
            sb.AppendLine(items);
            return sb.ToString();
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
        #endregion
    }
}