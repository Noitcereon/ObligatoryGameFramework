﻿using System;
using System.Collections.Generic;
using System.Drawing;
using _2DTurnBasedGameFramework.Interfaces;
using Range = _2DTurnBasedGameFramework.Helpers.Range;

namespace _2DTurnBasedGameFramework.Models.BaseModels
{
    public class BaseCreature : ICreature
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Attack { get; set; }
        public int Defense { get; set; }
        public Range Damage { get; set; }
        public int SpellPower { get; set; }
        public int Hitpoints { get; set; }
        public string Name { get; set; }
        public bool IsCaster { get; set; }
        public Point Position { get; set; }

        public BaseCreature() { }

        public BaseCreature(string name, int attack, int defense, int hitpoints, Range damage, Point position)
        {
            Name = name;
            Damage = damage;
            Attack = attack;
            Defense = defense;
            Hitpoints = hitpoints;
            Position = position;
            SpellPower = 0;
            IsCaster = false;
        }

        public virtual int Hit()
        {
            Random random = new Random();

            int baseDamage = random.Next(Damage.From, Damage.To);
            int damageDealt = baseDamage + Attack;

            return damageDealt;
        }

        public virtual int ReceiveHit(int damage)
        {
            int damageTaken = damage - Defense;

            Hitpoints -= damageTaken;
            return damageTaken;
        }
    }
}