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
        private TalonPile talonPile = new TalonPile();


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
    }
}
