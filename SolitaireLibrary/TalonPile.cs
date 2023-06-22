namespace SolitaireLibrary
{
    public class TalonPile : Pile
    {
        public TalonPile()
        {
            CardList = new List<Card>();
        }
        public bool MoveTo(Pile? sourcePile, Pile movePile) //TODO: Not liking passing around the whole pile when all we need is the type. 
        {
            if (sourcePile == null) return false;
            if (sourcePile.GetType() != typeof(StockPile))return false;
            if (movePile == null || movePile.CardList.Count == 0) return false;
            foreach (var card in movePile.CardList)
            {
                card.isFaceUp = true;
                CardList.Add(card);
            }
            return true;
        }
    }
}