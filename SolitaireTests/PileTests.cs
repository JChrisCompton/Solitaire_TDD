using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolitaireLibrary;
using System;
using System.Collections;
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
            // Moving from Stock to Talon
            // • check that a card is removed from Stock
            // • check that a card is added to the Talon
            Debug.Print("\n\n\n");

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
            // When moving from Stock to Talon
            // • check that the card is moved to the right place
            // • check that the card is oriented correctly (always face up on the talon)
            var stockPile = new StockPile();
            var talonPile = new TalonPile();

            stockPile.CardList.Add(new Card(2, SuitType.Spade, false));  // card to move
            stockPile.CardList.Add(new Card(3, SuitType.Spade, false));  // card[0] after the move
            stockPile.CardList.Add(new Card(4, SuitType.Spade, false));  // card[0] after the move
            talonPile.CardList.Add(new Card(5, SuitType.Diamond, true));
            talonPile.CardList.Add(new Card(6, SuitType.Diamond, true));
            talonPile.CardList.Add(new Card(7, SuitType.Diamond, true));

            int pileHeightBefore = stockPile.CardList.Count();

            // Make the move
            bool isSuccess = stockPile.MoveTo(talonPile);
            // was there an error, or success?
            Assert.IsTrue(isSuccess);


            /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
            * Assert.AreEqual(a, b);    // this fails EVEN THOUGH ALL THREE PROPERTIES are equal.
            * Failure error is: 
            *
            * Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException
            *         HResult = 0x80131500
            * Message = Assert.AreEqual failed.Expected:< SolitaireLibrary.Card >.Actual:< SolitaireLibrary.Card >.
            * Source = Microsoft.VisualStudio.TestPlatform.TestFramework
            * StackTrace:
            *         at Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowAssertFailed(String assertionName, String message)
            * at Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual[T](T expected, T actual, IEqualityComparer`1 comparer, String message, Object[] parameters)
            * at Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual[T](T expected, T actual)
            * at SolitaireTests.PileTests.StockToTalon_MoveOne_CheckDestination() in D:\Code\Source\Repos\SolitaireTDD\SolitaireTests\PileTests.cs:line 99     
            * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

            // Verify the stock pile
            Assert.AreEqual(pileHeightBefore - 1, stockPile.CardList.Count()); // 1 less card 
            Card a = stockPile.CardList[0];
            Card b = new Card(3, SuitType.Spade, false);  // 3-Spade Down 
            Assert.AreEqual(a.Suit, b.Suit); 
            Assert.AreEqual(a.Value, b.Value);
            Assert.AreEqual(a.isFaceUp, b.isFaceUp);
            a = stockPile.CardList[1];
            b = new Card(4, SuitType.Spade, false);  // 4-Spade Down 
            Assert.AreEqual(a.Suit, b.Suit);
            Assert.AreEqual(a.Value, b.Value);
            Assert.AreEqual(a.isFaceUp, b.isFaceUp);

            // Verify the talon pile (in order)
            a = talonPile.CardList[0];
            b = new Card(2, SuitType.Spade, true);  // 2-Spade Flipped UP 
            Assert.AreEqual(a.Suit, b.Suit);
            Assert.AreEqual(a.Value, b.Value);
            Assert.AreEqual(a.isFaceUp, b.isFaceUp);
            a = talonPile.CardList[1];
            b = new Card(5, SuitType.Diamond, true);  // 5-Daimond Up 
            Assert.AreEqual(a.Suit, b.Suit);
            Assert.AreEqual(a.Value, b.Value);
            Assert.AreEqual(a.isFaceUp, b.isFaceUp);
            a = talonPile.CardList[2];
            b = new Card(6, SuitType.Diamond, true);  // 6-Daimond Up 
            Assert.AreEqual(a.Suit, b.Suit);
            Assert.AreEqual(a.Value, b.Value);
            Assert.AreEqual(a.isFaceUp, b.isFaceUp);
            a = talonPile.CardList[3];
            b = new Card(7, SuitType.Diamond, true);  // 7-Daimond Up 
            Assert.AreEqual(a.Suit, b.Suit);
            Assert.AreEqual(a.Value, b.Value);
            Assert.AreEqual(a.isFaceUp, b.isFaceUp);

            //Assert.AreEqual(1,2);
        }
    }
}
