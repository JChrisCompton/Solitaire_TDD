namespace SolitaireLibrary
{
    public class Pile : iPile, iMove
    {
        private List<Card> InProgressCardList { get; set; } = new List<Card>();

        //list of cards
        public List<Card> CardList { get; set; } = new List<Card>();

        public Pile()
        {
        }        

        public virtual bool AddCard(Card card)
        {
            if (card.isFaceUp == false) return false;
            CardList.Add(card);
            return true;
        }

        public bool TakeFrom(Pile pile, int StartCardLoc = 0)
        //public Pile TakeFrom(Pile pile, int StartCardLoc)
        {
            Pile tempPile = new Pile();
            //return tempPile;
            return false;
        }

        public bool MoveTo(Pile sourcePile, Pile movePile)
        {
            throw new NotImplementedException();
        }

        //public void Undo(Pile movePile)
        //{
        //    throw new NotImplementedException();
        //}

        //void iMove.Move(Pile sourcePile, int startCardLoc, Pile destPile)
        //{
        //    throw new NotImplementedException();
        //}
    }
}