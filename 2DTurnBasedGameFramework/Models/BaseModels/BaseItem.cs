using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DTurnBasedGameFramework.Interfaces;

namespace _2DTurnBasedGameFramework.Models.BaseModels
{
    public abstract class BaseItem : IItem
    {
        /// <inheritdoc />
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <inheritdoc />
        public string Name { get; set; }
        /// <inheritdoc />
        public int Attack { get; set; }
        /// <inheritdoc />
        public int Defense { get; set; }
        /// <inheritdoc />
        public int SpellPower { get; set; }
        /// <inheritdoc />
        public int Hitpoints { get; set; }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        protected BaseItem()
        {
        }
        /// <summary>
        /// Makes an item with nothing but a name.
        /// </summary>
        /// <param name="name">The name of the item</param>
        protected BaseItem(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Makes an item with a name and possible some randomly generated stats.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="randomStats">If true, it generates an item with random stats. Each stat can be a value between 0 and 10</param>
        protected BaseItem(string name, bool randomStats):this(name)
        {
            Random random = new Random();

            if (!randomStats) return;
            Attack = random.Next(0, 10);
            Defense = random.Next(0, 10);
            SpellPower = random.Next(0, 10);
            Hitpoints = random.Next(0, 10);
        }
        /// <summary>
        /// Makes an item with a name and the specified stats. If a stat is not specified it defaults to 0.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="spellPower"></param>
        /// <param name="hitpoints"></param>
        protected BaseItem(string name, int attack = 0, int defense = 0, int spellPower = 0, int hitpoints=0):this(name)
        {
            Attack = attack;
            Defense = defense;
            SpellPower = spellPower;
            Hitpoints = hitpoints;
        }

        /// <summary>
        /// Does nothing by default, but can be overriden to add a special effect to the item.
        /// </summary>
        protected virtual void SpecialEffect()
        {
            // No special effect.
        }
        /// <summary>
        /// Does nothing by default, but can be overriden to add a special effect to the item.
        /// </summary>
        /// <param name="creature">The creature to affect.</param>
        protected virtual void SpecialEffect(BaseCreature creature)
        {
            // No special effect.
        }

        /// <summary>
        /// Returns a string that shows the stats the item gives. Seperated by a Env.NewLine.
        /// </summary>
        /// <returns>A string that shows the stats the item gives</returns>
        public override string ToString()
        {
            return $"Atk: {Attack}{Environment.NewLine}" +
                   $"Def: {Defense}{Environment.NewLine}" +
                   $"SP: {SpellPower}{Environment.NewLine}" +
                   $"HP: {Hitpoints}{Environment.NewLine}";
        }
    }
}
