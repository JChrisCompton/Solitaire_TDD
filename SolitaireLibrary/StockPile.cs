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
            var addCard = CardList[StartCardIndex]; //TODO 3 card pull not coded for
            addCard.isFaceUp = true; //TODO Too much knowledge of the Card class?
            returnPile.CardList.Add(addCard);
            CardList.Remove(CardList[StartCardIndex]);
            return returnPile;
        }

        public bool Undo(Pile? movePile)
        {
            if (movePile == null || movePile.CardList.Count == 0) return false;
            foreach( Card card in movePile.CardList )
            {
                card.isFaceUp = false;
                CardList.Add(card);
            }
            return true;
        }
    }
}