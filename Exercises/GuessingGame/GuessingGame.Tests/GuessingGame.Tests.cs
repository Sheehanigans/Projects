using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GuessingGame.DLL;

namespace GuessingGame.Tests
{
    [TestFixture]
    public class GuessingGameTests
    {
        [Test]
        public void InvalidGuessTest()
        {
            GameManager gameInstance = new GameManager();
            gameInstance.Start();

            GuessResult actual = gameInstance.ProcessGuess(152);
            Assert.AreEqual(GuessResult.Invalid, actual);
        }
    }
}
