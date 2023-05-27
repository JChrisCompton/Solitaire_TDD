using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolitaireLibrary;

namespace SolitaireTests
{
    [TestClass]
    public class StockPileTests
    {
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

    }
}
