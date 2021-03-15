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
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpellPower { get; set; }
        public int Hitpoints { get; set; }

        protected BaseItem(int attack, int defense, int spellPower, int hitpoints)
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
