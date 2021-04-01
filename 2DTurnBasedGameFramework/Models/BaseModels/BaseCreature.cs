using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using _2DTurnBasedGameFramework.Interfaces;
using Range = _2DTurnBasedGameFramework.Helpers.Range;

namespace _2DTurnBasedGameFramework.Models.BaseModels
{
    /// <summary>
    /// <para>The Base class for all creatures.</para> Contains properties for stats, items and position,
    /// in addition to methods: Hit(), ReceiveHit() and InteractWithWorldObject().
    /// and an overriden ToString().
    /// </summary>
    public abstract class BaseCreature : ICreature
    {
        /// <inheritdoc />
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <inheritdoc />
        public bool IsDead { get; set; }
        /// <inheritdoc />
        public string Name { get; set; }
        /// <inheritdoc />
        public int Attack { get; set; }
        /// <inheritdoc />
        public int Defense { get; set; }
        /// <inheritdoc />
        public int Hitpoints { get; set; }
        /// <inheritdoc />
        public Range Damage { get; set; }
        /// <inheritdoc />
        public int SpellPower { get; set; }
        /// <inheritdoc />
        public bool IsCaster { get; set; }

        /// <summary>
        /// The creature's possessions. Each Item held increases power according to the item's stats.
        /// </summary>
        protected List<BaseItem> Items { get; set; } = new List<BaseItem>();
        /// <inheritdoc />
        public Point Position { get; set; } = Point.Empty;

        // TODO: abstract the stats into a Stats class?

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
        protected BaseCreature(string name, int attack, int defense, int hitpoints, Range damage)
        {
            Name = name;
            Attack = attack;
            Defense = defense;
            Hitpoints = hitpoints;
            Damage = damage;
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
        protected BaseCreature(string name, int attack, int defense, int hitpoints, Range damage, Point position) : this
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
        protected BaseCreature(string name, int attack, int defense, int hitpoints, Range damage, bool isCaster) : this
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
        protected BaseCreature(string name, int attack, int defense, int hitpoints, Range damage, Point position, bool isCaster) : this
            (name, attack, defense, hitpoints, damage)
        {
            IsCaster = isCaster;
            if (IsCaster) SpellPower = 10;
            Position = position;
        }

        /// <inheritdoc />
        public virtual void InteractWithWorldObject(BaseWorldObject worldObject)
        {
            if (worldObject.IsInteractable == false) return;

            if (worldObject.Item != null)
            {
                Loot(worldObject.Item);
            }
            else
            {
                // The behaviour of a non-item interactable world object, when interacted with.
                worldObject.OnInteraction(this);
            }
        }


        /// <inheritdoc />
        public void Loot(BaseItem item)
        {
            Items.Add(item);
            Attack += item.Attack;
            Defense += item.Defense;
            Hitpoints += item.Hitpoints;
            SpellPower += item.SpellPower;
        }

        /// <inheritdoc />
        public virtual int Hit()
        {
            Random random = new Random();

            int baseDamage = random.Next(Damage.From, Damage.To);

            // abstract dmg calculation into derived class?
            int damageDealt = baseDamage + Attack;

            return damageDealt;
        }


        /// <inheritdoc />
        public virtual int ReceiveHit(int damage)
        {
            // Maybe abstract the damage calculation away into a method overriden in a derived class?
            int damageTaken = damage - Defense;

            Hitpoints -= damageTaken;
            IsDead = Hitpoints <= 0;
            return damageTaken;
        }

        /// <summary>
        /// Prints creature's information (all stats and items). Basically a character sheet.
        /// </summary>
        /// <returns>A formatted character sheet</returns>
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
    }
}
