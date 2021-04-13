﻿using System;
using System.Diagnostics;
using _2DTurnBasedGameFramework.AbstractFactory.BaseFactories;
using _2DTurnBasedGameFramework.AbstractFactory.CreatureProducts;
using _2DTurnBasedGameFramework.Models;
using _2DTurnBasedGameFramework.Models.BaseModels;
using CustomRange = _2DTurnBasedGameFramework.Helpers.CustomRange;

namespace _2DTurnBasedGameFramework.AbstractFactory.Factories
{
    /// <summary>
    /// An implementation of the ICreatureFactory.
    /// </summary>
    public class CreatureFactory : ICreatureFactory
    {
        /// <inheritdoc />
        public BaseCreature CreateCreature(string name, int atk, int def, int hp, CustomRange dmgRange, bool isCaster)
        {
            try
            {
                BaseCreature creature = new GenericCreature(name, atk, def, hp, dmgRange, isCaster);

                if (creature.IsCaster)
                {
                    creature = new CasterCreature(creature);
                }
                return creature;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Logger.Log(TraceEventType.Critical, $"Creature creation error. Error message: {e.Message}");
                Logger.Log(TraceEventType.Verbose, $"StackTrace: {e.StackTrace}");
                throw;
            }
        }


        /// <inheritdoc />
        public BaseCreature CreateCreature(string name, int atk, int def, int hp, CustomRange dmgRange)
        {
            try
            {
                BaseCreature creature = new GenericCreature(name, atk, def, hp, dmgRange);

                return creature;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Logger.Log(TraceEventType.Critical, $"Creature creation error. Error message: {e.Message}");
                Logger.Log(TraceEventType.Verbose, $"StackTrace: {e.StackTrace}");
                throw;
            }
        }
    }
}
