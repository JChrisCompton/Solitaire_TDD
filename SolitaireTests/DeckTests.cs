using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolitaireLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SolitaireTests
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void DeckShouldBeCreated()
        {
            DeckPile deck = new DeckPile();
            Assert.IsNotNull(deck);
            Assert.AreEqual(deck.Cards.Count, 52);
            for (int i = 0; i < deck.Cards.Count; i++)
            {
                Console.WriteLine($"Ordinance: {deck.Cards[i].Value} Suit: {deck.Cards[i].Suit}");
            }


        }
        [TestMethod]
        public void CardsInTheDeckShouldBeUnique()
        {
            DeckPile deck = new DeckPile();
            Assert.IsFalse(deck.Cards.Count != deck.Cards.Distinct<Card>().Count());
        }
        [TestMethod]
        public void DeckCanBeShuffled()
        {
            DeckPile deck1 = new DeckPile();
            DeckPile deck2 = new DeckPile();
            deck2.Shuffle();

            bool allCardsMatch = true;
            if (deck1.Cards.Count == deck2.Cards.Count)
            {

                for (int i = 0; i < deck1.Cards.Count; i++)
                {
                    if (deck1.Cards[i].Value != deck2.Cards[i].Value
                        || deck1.Cards[i].Suit != deck2.Cards[i].Suit)
                    {
                        allCardsMatch = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Ordinance: {deck1.Cards[i].Value} Suit: {deck1.Cards[i].Suit}"
                            + " == " 
                            + $"Ordinance: {deck2.Cards[i].Value} Suit: {deck2.Cards[i].Suit}");
                    }
                }

            }
            else
            {
                allCardsMatch = false;
            }

            Assert.IsFalse(allCardsMatch);
        }
    }
}
