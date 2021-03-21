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
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpellPower { get; set; }
        public int Hitpoints { get; set; }

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

        public override string ToString()
        {
            return $"Atk: {Attack}{Environment.NewLine}" +
                   $"Def: {Defense}{Environment.NewLine}" +
                   $"SP: {SpellPower}{Environment.NewLine}" +
                   $"HP: {Hitpoints}{Environment.NewLine}";
        }
    }
}
