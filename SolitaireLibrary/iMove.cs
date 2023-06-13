namespace SolitaireLibrary
{
    public interface iMove
    {
        //bool Move(Pile fromPile, Pile toPile, int startCardLoc = 0);  // WAIT - I think I don't need this see MoveTo

        bool TakeFrom(Pile pile, int StartCardLoc = 0);
        // pile is a reference to the pile from which the card(s) should be taken
        // StartCardLocation is the specific card that should be taken
        //  multiple cards may be implied depending on combination of the pile type and StartCardLocation 

        bool MoveTo(
            // Pile fromPile is "this" pile
            Pile toPile // reference to the pile to where the cards will be moved
            , int StartCardLoc = 0 // the card to take. depending on the pile this may indicate multiple cards
            );
        //       WAIT - if I'm doing this on a pile... I do not need to specify the source DO I ???
        /// <summary>
        ///     fromPile     » "this" (reference to the pile from which the cards will be moved)
        ///     toPile       » reference to the pile to where the cards will be moved
        ///     StartCardLoc » integer that tells where the move should originate. 
        ///                  + depending on the pile This may cause multiple cards to be moved
        ///

        ///       
        ///     how do i specify "this" for my source pile?
        /// </summary>
        /// <param name="movePile"></param>
        /// <returns>bool</returns>


        //bool Undo(Pile movePile);

        //bool Move(Pile sourcePile, int startCardLoc, Pile destPile);
    }
}
