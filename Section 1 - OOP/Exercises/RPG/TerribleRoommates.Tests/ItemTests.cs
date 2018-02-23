using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TerribleRoommates.DLL.Containers;
using TerribleRoommates.DLL.Weapons;
using TerribleRoommates.DLL.Potions;

namespace TerribleRoommates.Tests
{
    [TestFixture]
    class ItemTests
    {
        [Test]
        public void CanAddCrossbowToBackPack()
        {
            Backpack bp = new Backpack("Small Backpack", 3,4);
            Crossbow bow = new Crossbow("Terrible crossbow", 3, 4);
            bool expected = true;
            bool actual = bp.Add(bow);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CannotAddTwoCrossboawsToBackpack()
        {
            Backpack bp = new Backpack("Small Backpack", 3, 4);
            Crossbow bow = new Crossbow("Terrible crossbow", 3, 4);
            Crossbow tooMany = new Crossbow("Janky crossbow", 3, 4);

            bool expected = false;

            bp.Add(bow);
            bool actual = bp.Add(tooMany);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanAddPotionToBackPack()
        {

            Backpack bp = new Backpack("Small Backpack", 3, 4);
            Heal heal = new Heal("Little potion", 3, 4);
            bool expected = true;
            bool actual = bp.Add(heal);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CannotAddFivePotionsToBackpack()
        {
            Backpack bp = new Backpack("Small Backpack", 3, 4);
            Heal heal1 = new Heal("Small heal potion", 1, 1);
            Heal heal2 = new Heal("Small heal potion", 1, 1);
            Heal heal3 = new Heal("Small heal potion", 1, 1);
            Heal heal4 = new Heal("Small heal potion", 1, 1);
            Heal heal5 = new Heal("Small heal potion", 1, 1);

            bool expected = false;

            bp.Add(heal1);
            bp.Add(heal2);
            bp.Add(heal3);
            bp.Add(heal4);
            bool actual = bp.Add(heal5);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddPotiontoBackpack()
        {
            //should allow
        }

        [Test]
        public void AddCrossbowToFannyPack()
        {
            //should NOT allow 
        }

        [Test]
        public void CannotAddNonPotionToFannyPack()
        {

        }
    }
}
