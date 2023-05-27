namespace SolitaireLibrary
{
    public class Card
    {
        
        

        public Card(int value, SuitType suit, bool faceup = false)
        {
            Value = value;
            if (!isValidValue(value)) 
            { 
                throw new Exception("Invalid Card");
            }
            Suit = suit;
            isFaceUp = faceup;
        }

        public int Value { get;  }
        public SuitType Suit { get; }
        public bool isFaceUp { get; set; }
        private bool isValidValue(int value)
        {
            return value > 0 && value < 14;
        }
    }

    public enum SuitType
    {
        Heart,
        Spade,
        Club,
        Diamond
    }
}