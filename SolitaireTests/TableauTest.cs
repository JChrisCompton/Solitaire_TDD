using SolitaireLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaireTests
{
    [TestClass]
    
    public class TableauTest
    {
        [TestMethod]
        public void CanCreateaTableauPile()
        {
            var tableauPile = new TableauPile();
            Assert.IsNotNull(tableauPile);
        }

        [TestMethod]
        public void AddedCardShouldNotBeFaceDown()
        {
            var tableauPile = new TableauPile();
            Card card = new Card(5, SuitType.Heart, false);
            tableauPile.AddCard(card);
            Assert.AreEqual(0, tableauPile.CardList.Count);
            if (tableauPile.CardList.Count > 0)
            {
                Assert.AreEqual(card, tableauPile.CardList.Last());
            }
        }
    }
}
