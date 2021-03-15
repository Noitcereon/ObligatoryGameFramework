using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DTurnBasedGameFramework.Interfaces;

namespace _2DTurnBasedGameFramework.Models
{
    public class Item : IItem
    {
        public Guid Id { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpellPower { get; set; }
        public int Hitpoints { get; set; }
    }
}
