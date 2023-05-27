using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolitaireLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        [TestMethod]
        public void StockToTalon_MoveOne_CheckRemoval()
        {
            Debug.Print("\n\n\n");
            // When moving from Stock to Talon check that a card is removed from Stock and added to Talon
            var stockPile = new StockPile();
            var talonPile = new TalonPile();

            stockPile.CardList.Add(new Card(2, SuitType.Spade, false));
            stockPile.CardList.Add(new Card(3, SuitType.Spade, false));
            stockPile.CardList.Add(new Card(4, SuitType.Spade, false));
            talonPile.CardList.Add(new Card(5, SuitType.Diamond, true));
            talonPile.CardList.Add(new Card(6, SuitType.Diamond, true));
            talonPile.CardList.Add(new Card(7, SuitType.Diamond, true));

            int stockPileHeightBefore = stockPile.CardList.Count();
            int talonPileHeightBefore = stockPile.CardList.Count();

            // Make the move
            bool isSuccess = stockPile.MoveTo(talonPile);
            
            // was there an error, or success?
            Assert.IsTrue(isSuccess);
            Assert.AreEqual(stockPileHeightBefore - 1, stockPile.CardList.Count());
            Assert.AreEqual(talonPileHeightBefore + 1, talonPile.CardList.Count());
        }
        [TestMethod]
        public void StockToTalon_MoveOne_CheckDestination()
        {
            // When moving from Stock to Talon check that the correct card is removed
            var stockPile = new StockPile();
            var talonPile = new TalonPile();

            stockPile.CardList.Add(new Card(2, SuitType.Spade, true));
            stockPile.CardList.Add(new Card(3, SuitType.Spade, true));
            stockPile.CardList.Add(new Card(4, SuitType.Spade, true));
            talonPile.CardList.Add(new Card(5, SuitType.Diamond, true));
            talonPile.CardList.Add(new Card(6, SuitType.Diamond, true));
            talonPile.CardList.Add(new Card(7, SuitType.Diamond, true));

            int pileHeightBefore = stockPile.CardList.Count();

            // Make the move
            bool isSuccess = stockPile.MoveTo(talonPile);

            //// was there an error, or success?
            //Assert.IsTrue(isSuccess);
            //Assert.AreEqual(pileHeightBefore - 1, stockPile.CardList.Count());

            Assert.AreEqual(1,2);
        }
    }
}
