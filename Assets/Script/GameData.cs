using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameData
{
    public Action<int> onChangeScore = delegate { };

    public int Score{ get; private set; }

    public void ClearScore()
    {
        Score = 0;
        onChangeScore?.Invoke(Score);
    }

    public void AddScore(int score)
    {
        Score += score;
        onChangeScore?.Invoke(Score);
    }
}
