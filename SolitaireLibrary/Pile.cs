using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace SolitaireLibrary
{
    public class Pile : iPile, iMove
    {
        private List<Card> InProgressCardList { get; set; } = new List<Card>();
        //private Pile InProgressCardList = new Pile();

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

        public bool MoveTo(Pile toPile, int startCardLoc = 0)
        {   // **************************************************************************************************
            // Okay... I remember there's a way to do a type(T) or something like, that which is more OO - but Ken, I'm on a role so that is a todo for the moment
            //
            //TODO: Do this the object oriented way instead of using temporary strings 
            //  there may also be a way to assign the name of StockPile as something else like "ThisIsThe_StockPile" not sure why I'd want to do that but for somereason it hit me just now.  Squirrel!!!  Stupid rabbit hole.
            // **************************************************************************************************

            //return false;
            //throw new NotImplementedException();
            //if (pile == null) return false;

            bool ret = true;    // initialize as no errors

            // determine where we are moving from
            var fromPile = (Pile)this;
            var fromPileType = this.GetType().Name.ToString();
            var destPileType = toPile.GetType().Name.ToString();
            Debug.Print($"* fromPile's type == " + fromPileType + ".");
            Debug.Print($"*  toPile's type  == " + destPileType + ".");

            // Ken - I assume it is best to now call the private specialized proc
            // depending on what is being moved where... b/c otherwise this proc becomes RATHER long.

            // Source pile has at least one card
            if (fromPile.CardList.Count < 1) { return false; }  /* TODO: log error */

            // Move from Stock to Talon
            if (fromPileType == "StockPile" &&
                destPileType == "TalonPile")
            {   // no errors yet
                ret = MoveStockToTalon((StockPile)fromPile, (TalonPile)toPile, 0);
                if(ret) { /* TODO: log move */ }
            }
            else if (fromPileType == "StockPile"
                && destPileType != "TalonPile")
            {   // Only valid destination from Stock is Talon, so this is an error
                ret = false;
                /* TODO: log error */
            }

            return ret;

        }

        private bool MoveStockToTalon(StockPile stock, TalonPile talon, int startCardLoc)
        {
            bool ret = true;    // initialize as no errors

            if (true) // Output param values
            {
                //DEBUG: print out the pile values
                Debug.Print("");
                Debug.Print("============= Initial Values =======================");
                Debug.Print("stock - \n | " + GetPileContents((Pile)stock));
                Debug.Print("talon - " + GetPileContents((Pile)talon));
                Debug.Print($"startCardLoc == {startCardLoc.ToString()}");
                Debug.Print("InProgressCardList - size == " + InProgressCardList.Count.ToString());
            }
            #region VerifyParameters
            // verify parameters
            if (InProgressCardList == null) return false;
            if (InProgressCardList.ToList().Count >= 1 ) return false;    //.cardList.Count() > 0
            if (startCardLoc < 0) return false;
            if (stock.CardList.Count <= startCardLoc) return false;     // .Count minus 1 ?
            if (startCardLoc > 13) return false;
            if (stock == null) return false;
            if (stock.CardList.Count < 1) return false;
            if (stock.CardList.Count >52) return false;
            if (talon == null) return false;
            if (talon.CardList.Count < 1) return false;
            if (talon.CardList.Count > 52) return false;
            // Verify these again as I had to use Pile for the parameter types (a more generic type) 
            if (stock.GetType().Name.ToString().ToLower() != (new StockPile()).GetType().Name.ToString().ToLower()) return false;
            if (talon.GetType().Name.ToString().ToLower() != (new TalonPile()).GetType().Name.ToString().ToLower()) return false;
            #endregion
            // TODO: for now assume startCardLoc == zero (1 card, the top one)

            // Remove the card from the stock pile
            // Store card in temp location
            //InProgressCardList.CardList.AddCard(stock.CardList[startCardLoc]);
            Card c = stock.CardList[startCardLoc];
            c.isFaceUp = true;  // flip the card before adding it to the pile
            InProgressCardList.Add(c);
            //InProgressCardList.CardList.Count should == 1
            stock.CardList.Remove(c);
            //            talon.CardList.Remove[startCardLoc]; why does this error?

            // add card to destination
            //talon.CardList.Add(InProgressCardList.Add(stock.CardList[startCardLoc]));
            talon.CardList.Insert(0, c);

            if (true) // Output param values
            {
                //DEBUG: print out the pile values
                Debug.Print("");
                Debug.Print("============= Before returning =====================");
                Debug.Print("»stock " + GetPileContents((Pile)stock));
                Debug.Print("»talon " + GetPileContents((Pile)talon));
                Debug.Print($"startCardLoc == {startCardLoc.ToString()}");
                Debug.Print("InProgressCardList - size == " + InProgressCardList.Count.ToString());
            }
            return ret;
        }

        private string GetPileContents(Pile pile)
        {
            // yeah not string builder, but I'm debugging
            string ret = $"Pile name == {pile.GetType().Name} size == {pile.CardList.Count.ToString()}:  ";
            if (pile == null)
            {
                ret = pile.GetType().Name.ToString(); // this work if it is null?
                return $"Pile  {ret}  has no cards!";
            }
                
            foreach (Card c in pile.CardList) { 
                if (c == null) continue;
                ret += $"{c.Value.ToString()}-{c.Suit} {c.isFaceUp.ToString()}, ";
            }
            return ret;
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