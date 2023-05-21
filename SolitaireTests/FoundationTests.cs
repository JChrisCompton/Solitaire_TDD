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
    public class FoundationPileTests
    {
        [TestMethod]
        public void CanCreateaFoundationPile()
        {
            var foundationPile = new FoundationPile();
            Assert.IsNotNull(foundationPile);
        }
        [TestMethod]
        public void AddedCardShouldBeFaceUp()
        {
            var card = new Card(5, SuitType.Heart, false);
            var foundationPile = new FoundationPile();
            foundationPile.AddCard(card);
            if (foundationPile.CardList.Count > 0)
            {
                Assert.AreEqual(card, foundationPile.CardList.Last<Card>());
            }
        }
    }
}
