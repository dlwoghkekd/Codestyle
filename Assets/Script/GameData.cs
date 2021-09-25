using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameData
{
    public event Action<int> OnChangeScore = delegate { };

    public int Score{ get; private set; }

    public void ClearScore()
    {
        Score = 0;
        OnChangeScore?.Invoke(Score);
    }

    public void AddScore(int score)
    {
        Score += score;
        OnChangeScore?.Invoke(Score);
    }
}
