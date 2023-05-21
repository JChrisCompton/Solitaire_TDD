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
    public class GameBoardTests
    {
        GameBoard board = new GameBoard();
        [TestMethod]
        public void CanCreateAGameBoard()
        {
            
            Assert.IsNotNull(board);
        }
        [TestMethod]
        public void GameBoardShouldHaveAStockPile()
        {
           
            Assert.IsNotNull(board.Stock);
        }
        [TestMethod]
        public void GameBoardShouldHaveATalonPile()
        {
            
            Assert.IsNotNull(board.Talon);  
        }
        [TestMethod]
        public void GameBoardShouldHaveFourFoundationPiles()
        {
            Assert.AreEqual(board.Foundation.Length, 4);
            for (int i = 0; i < board.Foundation.Length; i++)
            {
                Assert.IsNotNull(board.Foundation[i]);
            }
        }
        [TestMethod]
        public void GameBoardShouldHaveSevenTableauPiles()
        {
            Assert.AreEqual(board.Tableau.Length, 7);
            for (int i = 0; i < board.Tableau.Length; i++)
            {
                Assert.IsNotNull((board.Tableau[i]));
            }

        }
    }
}
