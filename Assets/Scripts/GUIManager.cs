using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : Singleton<GUIManager>
{
    public GameObject mainMenu;
    public GameObject gamePlay;
    public PauseDialog PauseDialog;
    public GameOverDialog GameOverDialog;
    public x2money x2Money;
    public Image timeBar;
    public Text scoreTxt;
    public Text bestScoreTxt;

    public override void Awake()
    {
        MakeSingleton(false);

    }
    public void Update()
    {
        UpdateBestScore();
    }
    public void ShowGamePlay(bool isShow)
    {
        if (gamePlay)
        {
            gamePlay.SetActive(isShow);
        }
        if (mainMenu)
        {
            mainMenu.SetActive(!isShow);
        }
    }

    public void UpdateScore(int score)
    {
        if (scoreTxt)
        {
            scoreTxt.text = score.ToString();
        }
    }
    public void UpdateBestScore()
    {
        if (bestScoreTxt)
        {
            bestScoreTxt.text = Pref.bestScore.ToString();
        }

    }
    public void UpdateTimeBar(float curTime, float totalTime)
    {
        float rate = curTime / totalTime;
        if (timeBar)
        {
            timeBar.fillAmount = rate;
        }
    }
}
