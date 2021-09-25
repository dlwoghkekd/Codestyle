using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelGame : UIPanelBase
{
    [SerializeField] private TMPro.TMP_Text txtScore;

    public override void OnOpen()
    {
        base.OnOpen();

        GameManager.Instance.Data.onChangeScore -= OnChangeScore;
        GameManager.Instance.Data.onChangeScore += OnChangeScore;

        OnChangeScore(GameManager.Instance.Data.Score);
    }

    public override void OnClose()
    {
        base.OnClose();

        GameManager.Instance.Data.onChangeScore -= OnChangeScore;
    }

    private void OnChangeScore(int score)
    {
        if (score < 0)
            score = 0;

        string strScore = string.Empty;

        var arrScore = score.ToString().ToCharArray();

        foreach (var iter in arrScore)
        {
            strScore += Constant.FORM_SCORE.Format(iter);
        }

        txtScore.text = strScore;
    }
}
