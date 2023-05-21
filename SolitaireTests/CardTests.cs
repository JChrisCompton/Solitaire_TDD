using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolitaireLibrary;

namespace SolitaireTests
{
    [TestClass]
    public class CardTests
    {
        private Card newcard = new Card(3,SuitType.Spade, false);
        [TestMethod]
        public void ShouldBeAbleToCreateACard()
        {
            Assert.IsNotNull(newcard);
        }
        [TestMethod]
        public void CardShouldHaveAValue()
        {
            Assert.AreEqual(3, newcard.Value);
        }
        [TestMethod]
        public void CardShouldHaveASuit()
        {
            Assert.AreEqual(SuitType.Spade, newcard.Suit);
        }
        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
            
        public void CardShouldBeCreatedIfValidValueIsProvided(int cardval)
        {
            var ValidValueCard = new Card(cardval, SuitType.Spade, true);
            Assert.IsNotNull(ValidValueCard);   
        }
        [TestMethod]
        public void ACardCanBeCreatedWithASuiteValueAndOrientation()
        {
            Card fullcard = new Card(3, SuitType.Spade, true);
            Assert.IsNotNull(fullcard); 
        }
        [TestMethod]
        [DataRow(SuitType.Heart)]
        [DataRow(SuitType.Diamond)]
        [DataRow(SuitType.Spade)]
        [DataRow(SuitType.Club)]
        public void SuitShouldBeValid(SuitType testSuit)
        {
            var testCard = new Card(12,testSuit, true);
            Assert.AreEqual(testCard.Suit, testSuit);
        }
        [TestMethod]
        [DataRow(14)]
        [DataRow(-1)]
        [DataRow(int.MaxValue)]
        public void InvalidValueShouldThrowException(int cardval)
        {
            Assert.ThrowsException<Exception>(() => { Card InvalidCard = new Card(cardval, SuitType.Spade, true); }) ;
        }
    }
}