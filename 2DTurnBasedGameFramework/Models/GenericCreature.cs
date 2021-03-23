using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using _2DTurnBasedGameFramework.Models.BaseModels;
using Range = _2DTurnBasedGameFramework.Helpers.Range;

namespace _2DTurnBasedGameFramework.Models
{
    public class GenericCreature : BaseCreature
    {
        public GenericCreature():base()
        {
        }

        public GenericCreature(string name, int attack, int defense, int hitpoints, Range damage) : base(name, attack, defense, hitpoints, damage)
        {
        }

        public GenericCreature(string name, int attack, int defense, int hitpoints, Range damage, Point position) : base(name, attack, defense, hitpoints, damage, position)
        {
        }

        public GenericCreature(string name, int attack, int defense, int hitpoints, Range damage, bool isCaster) : base(name, attack, defense, hitpoints, damage, isCaster)
        {
        }

        public GenericCreature(string name, int attack, int defense, int hitpoints, Range damage, Point position, bool isCaster) : base(name, attack, defense, hitpoints, damage, position, isCaster)
        {
        }
    }
}
