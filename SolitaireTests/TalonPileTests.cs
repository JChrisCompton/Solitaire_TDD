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
       
        [TestMethod]
        public void MoveToShouldNotAcceptNullSourcePile()
        {
            Pile? sourcePile = null;
            Assert.IsFalse(MoveStockToTalon(sourcePile, movePile));
        }
        [TestMethod]
        public void MoveToShouldNotAcceptAnEmptyMovePile()
        {
            Assert.IsFalse(MoveStockToTalon(sourcePile, movePile));
        }
        [TestMethod]
        public void MoveToShouldOnlyAcceptStockAsSourcePile()
        {
            sourcePile = board.Foundation[0];
            Assert.IsFalse(MoveStockToTalon(sourcePile, movePile));
        }

        private bool MoveStockToTalon(Pile sourcePile, Pile movePile)
        {
            return talonPile.MoveTo(sourcePile, movePile);
        }
    }
}
