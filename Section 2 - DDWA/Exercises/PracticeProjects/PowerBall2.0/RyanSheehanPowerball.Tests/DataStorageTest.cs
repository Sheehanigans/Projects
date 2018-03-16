using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RyanSheehanPowerball;
using System.IO;

namespace RyanSheehanPowerball.Tests
{
    [TestFixture]
    public class DataStorageTest
    {
        private const string _filePath = @"C:\Repos\ryan-sheehan-individual-work\Exercises\Powerball\RyanSheehanPowerball\Data\PowerballPicksTest.txt";
        private const string _seed = @"C:\Repos\ryan-sheehan-individual-work\Exercises\Powerball\RyanSheehanPowerball\Data\Seed.txt";

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }

            File.Copy(_seed, _filePath);
        }

        [Test]
        public void CanReadDataFromFile()
        {
            PickRepository repo = new PickRepository(_filePath);

            List<Pick> picks = repo.List();

            Assert.AreEqual(4, picks.Count);

            Pick check = picks[0];

            Assert.AreEqual(101, check.PickID);
            Assert.AreEqual("Ryan", check.FirstName);
            Assert.AreEqual("Sheehan", check.LastName);
            Assert.AreEqual(1, check.PickNumbers[0]);
            Assert.AreEqual(2, check.PickNumbers[1]);
            Assert.AreEqual(3, check.PickNumbers[2]);
            Assert.AreEqual(4, check.PickNumbers[3]);
            Assert.AreEqual(5, check.PickNumbers[4]);
            Assert.AreEqual(6, check.Powerball);
        }

        [Test]
        public void CanAddPickToFile()
        {
            PickRepository repo = new PickRepository(_filePath);

            Pick newPick = new Pick();
            newPick.PickID = 105;
            newPick.FirstName = "Ryan";
            newPick.LastName = "Sheehan";
            newPick.PickNumbers[0] = 1;
            newPick.PickNumbers[1] = 2;
            newPick.PickNumbers[2] = 3;
            newPick.PickNumbers[3] = 4;
            newPick.PickNumbers[4] = 5;
            newPick.Powerball = 6;

            repo.Add(newPick);

            List<Pick> picks = repo.List();

            Assert.AreEqual(5, picks.Count());

            Pick check = picks[4];

            Assert.AreEqual(105, check.PickID);
            Assert.AreEqual("Ryan", check.FirstName);
            Assert.AreEqual("Sheehan", check.LastName);
            Assert.AreEqual(1, check.PickNumbers[0]);
            Assert.AreEqual(2, check.PickNumbers[1]);
            Assert.AreEqual(3, check.PickNumbers[2]);
            Assert.AreEqual(4, check.PickNumbers[3]);
            Assert.AreEqual(5, check.PickNumbers[4]);
            Assert.AreEqual(6, check.Powerball);
        }
    }
}
