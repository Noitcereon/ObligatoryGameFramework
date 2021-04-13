using System.Drawing;
using _2DTurnBasedGameFramework;
using _2DTurnBasedGameFramework.AbstractFactory.Factories;
using _2DTurnBasedGameFramework.Helpers;
using _2DTurnBasedGameFramework.Models;
using _2DTurnBasedGameFramework.Models.BaseModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrameworkTesting
{
    [TestClass]
    public class CreatureTests
    {
        private readonly CreatureFactory _factory = new CreatureFactory();

        [TestMethod]
        public void CanLootItem()
        {
            BaseWorldObject pickUp = new InteractableWorldObject(new Item("Ring", true), Point.Empty);
            BaseCreature creature = _factory.CreateCreature("Wolf Rider", 5, 3, 24, new CustomRange(3, 6), false);

            int beforePickup = creature.Items.Count;
            creature.InteractWithWorldObject(pickUp);
            int afterPickup = creature.Items.Count;
            Assert.AreEqual(beforePickup + 1, afterPickup);
        }

        [TestMethod]
        public void GotStatsFromItems()
        {
            BaseWorldObject pickUp = new InteractableWorldObject(new Item("Ring", 5, 3, -2, 10), Point.Empty);
            BaseWorldObject pickUp2 = new InteractableWorldObject(new Item("Sword of the Novice", 2), Point.Empty);
            BaseWorldObject pickUp3 = new InteractableWorldObject(new Item("Angel Statue"), Point.Empty);
            BaseCreature creature = _factory.CreateCreature("Wolf Rider", 5, 3, 24, new CustomRange(3, 6), false);
            var creatureBeforeItemStats = creature;

            int expectedAtk = creatureBeforeItemStats.Attack + 7;
            int expectedDef = creatureBeforeItemStats.Defense + 3;
            int expectedSP = creatureBeforeItemStats.SpellPower - 2;
            int expectedHP = creatureBeforeItemStats.Hitpoints + 10;

            creature.InteractWithWorldObject(pickUp);
            creature.InteractWithWorldObject(pickUp2);
            creature.InteractWithWorldObject(pickUp3);

            Assert.AreEqual(expectedAtk, creature.Attack);
            Assert.AreEqual(expectedDef, creature.Defense);
            Assert.AreEqual(expectedSP, creature.SpellPower);
            Assert.AreEqual(expectedHP, creature.Hitpoints);
        }

        [TestMethod]
        public void ReceiveHit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Hit()
        {
            Assert.Fail();
        }
    }
}
