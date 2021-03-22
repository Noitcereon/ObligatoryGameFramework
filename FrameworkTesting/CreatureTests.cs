using System.Drawing;
using _2DTurnBasedGameFramework;
using _2DTurnBasedGameFramework.AbstractFactory.Factories;
using _2DTurnBasedGameFramework.Models;
using _2DTurnBasedGameFramework.Models.BaseModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrameworkTesting
{
    [TestClass]
    public class CreatureTests
    {
        private StandardCreatureFactory _factory = new StandardCreatureFactory();

        [TestMethod]
        public void LootItem()
        {
            BaseWorldObject pickUp = new InteractableWorldObject(new Item("Ring", true), Point.Empty);
            _factory.CreateCreature("")
        }
    }
}
