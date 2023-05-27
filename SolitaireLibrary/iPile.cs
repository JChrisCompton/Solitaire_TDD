namespace SolitaireLibrary
{
    public interface iPile
    {
        List<Card> CardList { get; set; }

        bool AddCard(Card card); 

    }
}