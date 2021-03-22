using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DTurnBasedGameFramework.Interfaces;
using _2DTurnBasedGameFramework.Models.BaseModels;

namespace _2DTurnBasedGameFramework.Models
{
    public class Item : BaseItem
    {
        public Item()
        { }
        public Item(string name, int attack, int defense, int spellPower, int hitpoints)
            : base(name, attack, defense, spellPower, hitpoints)
        { }

        public Item(string name):base(name) {}

        public Item(string name, bool randomStats):base(name, randomStats) { }
    }
}
