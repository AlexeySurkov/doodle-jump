using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Model
{
    public class ModelHighcoresTable
    {
        private const string PATH_TO_HIGHSCORE_FILE = "highscores.txt";

        public List<ModelHighscoreRecord> _highscoreRecords = new List<ModelHighscoreRecord>();


        public ModelHighcoresTable()
        {
            if (File.Exists(PATH_TO_HIGHSCORE_FILE))
            {
                string[] v = File.ReadAllLines(PATH_TO_HIGHSCORE_FILE);
                foreach (var item in v)
                {
                    string[] v1 = item.Split(' ');

                    ModelHighscoreRecord highscoreString = new ModelHighscoreRecord(v1[0], Int32.Parse(v1[1]));
                    _highscoreRecords.Add(highscoreString);
                }
            }
            else
            {
                File.Create(PATH_TO_HIGHSCORE_FILE).Close();
            }
        }

        public void WriteFile()
        {
            var file = File.OpenWrite(PATH_TO_HIGHSCORE_FILE);

            _highscoreRecords.Sort(new Comparison<ModelHighscoreRecord>((firstGamerScore, secondGamerScore) => { return firstGamerScore.Score - secondGamerScore.Score; }));

            for (int i = 0; i < _highscoreRecords.Count && i < 10; i++)
            {
                string s = string.Format("{} {}\r\n", _highscoreRecords[i], _highscoreRecords[i].Score.ToString());
               
                file.Write(Encoding.UTF8.GetBytes(s), 0, Encoding.UTF8.GetBytes(s).Length);
            }

            file.Close();
        }

    }
}
