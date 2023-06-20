using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolitaireLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SolitaireTests
{
    [TestClass]
    public class TalonPileTests
    {
        private GameBoard board;
        private TalonPile talonPile;
        private Pile sourcePile;
        private Pile movePile;
        [TestInitialize]    
        public void InitTests()
        {
            board = new GameBoard();
            talonPile = board.Talon;
            sourcePile = board.Stock;
            movePile = new Pile();
        }


        [TestMethod]
        public void CanCreateTalonPile()
        {
            
            Assert.IsNotNull(talonPile);
        }

        [TestMethod]
        public void AddedCardShouldNotBeFaceDown()
        {
            Card card = new Card(5,SuitType.Heart,false);
            talonPile.AddCard(card);
            Assert.AreEqual(0,talonPile.CardList.Count);
            if (talonPile.CardList.Count > 0)
            {
                Assert.AreEqual(card, talonPile.CardList.Last());
            }
        }
        [TestClass]
        public class TalonPileMoveToTests
        {
            private GameBoard board;
            private TalonPile talonPile;
            private Pile sourcePile;
            private Pile movePile;
            [TestInitialize]
            public void InitTests()
            {
                board = new GameBoard();
                talonPile = board.Talon;
                sourcePile = board.Stock;
                movePile = new Pile();
                populateMovePile();
            }
            private void populateMovePile()
            {
                var card = new Card(4,SuitType.Heart,false);
                movePile.CardList.Add(card);    
            }
            [TestMethod]
            public void MoveToShouldNotAcceptNullSourcePile()
            {
                Pile? sourcePile = null;
                Assert.IsFalse(talonPile.MoveTo(sourcePile, movePile));
            }
            [TestMethod]
            public void MoveToShouldNotAcceptAnEmptyMovePile()
            {
                movePile = new Pile();
                Assert.IsFalse(talonPile.MoveTo(sourcePile, movePile));
            }
            [TestMethod]
            public void MoveToShouldOnlyAcceptStockAsSourcePile()
            {
                sourcePile = board.Foundation[0];
                Assert.IsFalse(talonPile.MoveTo(sourcePile, movePile));
            }
            [TestMethod]
            public void TalonPileLengthShouldIncreaseByCardsInMovePile()
            {
                var talonStartingLength = talonPile.CardList.Count;
                talonPile.MoveTo(sourcePile, movePile);
                var talonEndLength = talonPile.CardList.Count;
                Assert.AreEqual(movePile.CardList.Count, talonEndLength - talonStartingLength);
            }
            [TestMethod]
            public void TalonPileCardsShouldAllBeFaceUpAfterMoveTo()
            {
                talonPile.MoveTo(sourcePile, movePile);
                foreach(Card talonCard in talonPile.CardList)
                {
                    Assert.IsTrue(talonCard.isFaceUp);
                }
            }

        }

    }
}
