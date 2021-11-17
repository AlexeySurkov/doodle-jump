namespace Model
{
    public class ModelHighscoreRecord
    {
        private int _score;
        private string _gamerName;

        public string GamerName { get => _gamerName; set => _gamerName = value; }
        public int Score { get => _score; set => _score = value; }

        public ModelHighscoreRecord(string parGamerName, int parScore)
        {
            Score = parScore;
            GamerName = parGamerName;
        }
    }
}
