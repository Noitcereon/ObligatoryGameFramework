using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DTurnBasedGameFramework.AbstractFactory.CreatureProducts;
using _2DTurnBasedGameFramework.Models.BaseModels;

namespace DebugProject.CustomCreatures
{
    public class VampiricCreature : MeleeCreature
    {
        public override void AdditionalHitModification()
        {
            Hitpoints += Attack / 2;
        }
        public VampiricCreature()
        {
            
        }
    }
}
