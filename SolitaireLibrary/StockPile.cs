namespace SolitaireLibrary
{
    public class StockPile : Pile
    {
        public StockPile()
        {
            CardList = new List<Card>();
        }

        override public bool AddCard(Card card)
        {
            return false;
        }
        public Pile TakeFrom(int StartCardIndex)
        {
            if (CardList.Count == 0) return null; 
            var returnPile = new Pile();
            var addCard = CardList[StartCardIndex];
            if (!addCard.isFaceUp) addCard.isFaceUp = true;
            returnPile.CardList.Add(addCard);
            CardList.Remove(CardList[StartCardIndex]);
            return returnPile;
        }

    }
}