using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolitaireLibrary;
using System.Diagnostics;
//using System.Runtime.CompilerServices;

namespace SolitaireTests
{
    [TestClass]
    public class StockPileTests
    {
        private GameBoard board;
        private StockPile stockPile;
        private int topCardIndex;
        [TestInitialize] public void Init() 
        {
            board = new GameBoard();
            stockPile = board.Stock;
            PopulateStock();
            topCardIndex = stockPile.CardList.Count -1;

        }
        private void PopulateStock()
        {
            stockPile.CardList.Add(new Card(2, SuitType.Spade, false));
            stockPile.CardList.Add(new Card(3, SuitType.Spade, false));
            stockPile.CardList.Add(new Card(4, SuitType.Spade, false));
        }
        [TestMethod]
        public void StockPileShouldBeCreated()
        {
            iPile stockPile = new StockPile();
        }

        [TestMethod]
        public void StockPileShouldHaveACard()
        {
            iPile stockPile = new StockPile();
            stockPile.CardList.Add(new Card(8, SuitType.Diamond, true));
            Assert.AreEqual(stockPile.CardList.Count, 1);
        }

        [TestMethod]
        public void StockPile_ShouldNot_BeAbleToAdd_FaceUpCards()
        {
            iPile stockPile = new StockPile();
            Assert.AreEqual(stockPile.AddCard(new Card(4, SuitType.Heart, true)), false);
            if (stockPile.CardList.Count>0)
            {
                Assert.AreNotEqual(stockPile.CardList.Last<Card>(), new Card(4, SuitType.Heart, true));
            }
            
        }
        [TestMethod]
        public void ShouldBeAbleToMoveCardFromStockToTalon()
        {
            GameBoard board = new GameBoard();
            board.Stock.AddCard(new Card(7, SuitType.Heart, false));
            Pile movePile = new Pile(); 
            StockPile fromPile = new StockPile();
            TalonPile toPile = new TalonPile(); 
            //board.Stock.Move(movePile, fromPile,  toPile);

        }
        [TestMethod]
        public void StockToTalon_MoveOne_CheckRemoval()
        {
            // Moving from Stock to Talon
            // • check that a card is removed from Stock
            // • check that a card is added to the Talon
            Debug.Print("\n\n\n");

            //var stockPile = new StockPile();
            var talonPile = new TalonPile();
            //PopulateStock();
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
            //var stockPile = new StockPile();
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
        [TestMethod]
        public void StockToStock_InValidMove()
        {
            var stockPile = new StockPile();
            var stockPile2 = new StockPile();

            stockPile.CardList.Add(new Card(2, SuitType.Spade, false));  // card to move

            // Make the illegal move
            bool isSuccess = stockPile.MoveTo(stockPile2);

            // was there an error, or success?
            Assert.IsFalse(isSuccess);
        }
        [TestMethod]
        public void StockToFoundation_InValidMove()
        {
            var stockPile = new StockPile();
            var foundationPile = new FoundationPile();

            stockPile.CardList.Add(new Card(2, SuitType.Spade, false));  // card to move

            // Make the illegal move
            bool isSuccess = stockPile.MoveTo(foundationPile);

            // was there an error, or success?
            Assert.IsFalse(isSuccess);
        }
        [TestMethod]
        public void StockToTableau_InValidMove()
        {
            var stockPile = new StockPile();
            var tableauPile = new TableauPile();

            stockPile.CardList.Add(new Card(2, SuitType.Spade, false));  // card to move

            // Make the illegal move
            bool isSuccess = stockPile.MoveTo(tableauPile);

            // was there an error, or success?
            Assert.IsFalse(isSuccess);
        }
        [TestMethod]
        public void TakeFromStockShouldNotBeNull()
        {
            Assert.IsNotNull(stockPile.TakeFrom(topCardIndex));
        }
        [TestMethod]
        public void TakeFromStockShouldHave1Card()
        {
            Assert.AreEqual(stockPile.TakeFrom(topCardIndex).CardList.Count, 1);
        }
        [TestMethod]
        public void ReturnedCardForTakeFromShouldEqualStartingTopCardOfStock()
        {
            var startingTopCard = stockPile.CardList[topCardIndex];
            var returnPile = stockPile.TakeFrom(topCardIndex);
            Assert.IsTrue(startingTopCard.Equals(returnPile.CardList.Last()));
        }
        [TestMethod]
        public void TopCardofStockShouldNotBeTheSameAfterTakeFrom()
        {
            var startingTopCard = stockPile.CardList[topCardIndex];
            stockPile.TakeFrom(topCardIndex);
            var newTopCard = stockPile.CardList.Last();
            Console.WriteLine(startingTopCard.Value + " " + startingTopCard.Suit);
            Console.WriteLine(newTopCard.Value + " " + newTopCard.Suit);

            Assert.IsFalse(startingTopCard.Equals(newTopCard)); 
        }
        [TestMethod]
        public void TakeFromEmptyStockPileShouldReturnNull()
        {
            stockPile = new StockPile();
            Assert.IsNull(stockPile.TakeFrom(0));
        }
        [TestMethod]
        public void TakeFromStockPileShouldReturnCardsFaceUp()
        {
            var returnPile = stockPile.TakeFrom(topCardIndex);
            foreach( Card card in returnPile.CardList)
            {
                Assert.IsTrue(card.isFaceUp);
            }
        }

    }
}
