namespace SolitaireLibrary
{
    public class DeckPile
    {
        bool IsShuffled = false;
        public List<Card> Cards { get; set; }

        public DeckPile()
        {
            //Add comment for test Push
            Cards = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                for(int j = 1; j < 14; j++)
                Cards.Add(new Card(j, (SuitType)i));
            }
        }
        public void Shuffle()
        {
            IsShuffled = true;
            List<Card> shuffledCards = new List<Card>();
            Random rnd = new Random();
            int r;  // random integer
            //for (int i = 0; i < Cards.Count; i++)
            while (Cards.Count >= 1)
            {
                r = rnd.Next(0, Cards.Count);   // locate a random card 

                Card c = new SolitaireLibrary.Card(Cards[r].Value, Cards[r].Suit);

                shuffledCards.Add(c);
                
                //Cards.Remove(c);  This doesn't work, not sure why
                Cards.RemoveRange(r, 1);
            }
            Cards = shuffledCards;
        }
    }
}