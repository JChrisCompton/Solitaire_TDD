using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolitaireLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaireTests
{
    [TestClass]
    public class PileTests
    {
        // four types of piles


        [TestMethod]
        public void CreatePile()
        {
            var testPile = new Pile();
            Assert.IsNotNull(testPile);
        }

        [TestMethod]
        public void NewPileShouldHaveAnEmptyListOfCards()
        {
            var testPile = new Pile();
            Assert.AreEqual(testPile.CardList.Count(), 0);
        }
        [TestMethod]
        public void PileShouldHaveOneCardButDoesNot()
        {
            var testPile = new Pile();
            Assert.AreNotEqual(testPile.CardList.Count(), 1);
        }
        [TestMethod]
        public void PileShouldHaveOneCard()
        {
            var testPile = new Pile();
            testPile.CardList.Add(new Card(3, SuitType.Diamond, true));
            Assert.AreEqual(testPile.CardList.Count(), 1);
        }
    }
}
