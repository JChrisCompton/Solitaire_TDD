namespace SolitaireLibrary
{
    public class GameBoard
    {
        public GameBoard()
        {
            Stock = new StockPile();
            Talon = new TalonPile();
            createFoundation();
            createTableau();

        }

        public StockPile? Stock { get; set; }
        public TalonPile? Talon { get; set; }
        public FoundationPile[] Foundation { get; set; }
        public TableauPile[] Tableau { get; set; }

        private void createFoundation()
        {
            Foundation = new FoundationPile[4];
            for (int foundations = 0; foundations <= 3; foundations++)
            {
                Foundation[foundations] = new FoundationPile();
            }

        }
        private void createTableau()
        {
            Tableau = new TableauPile[7];
            for (int i = 0; i < 7; i++)
            {
                Tableau[i] = new TableauPile();
            }
        }


    }
}