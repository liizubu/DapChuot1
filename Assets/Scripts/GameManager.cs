using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public int timeLimit;

    public float m_curTimeLimit;
    private int m_score;
    private int m_bestScore;

    public GameState state;
    public float CurTimeLimit { get => m_curTimeLimit; set => m_curTimeLimit = value; }
    public int Score { get => m_score; set => m_score = value; }
    public int BestScore { get => m_bestScore; set => m_bestScore = value; }

    public override void Awake()
    {

        MakeSingleton(false);
        base.Start();
        state = GameState.Starting;
        m_curTimeLimit = timeLimit;

        state = GameState.Starting;



    }
    public override void Start()
    {


        if (AudioController.Ins)
        {
            AudioController.Ins.PlayBackgroundMusic();
        }
    }
    public void Update()
    {
        if (state != GameState.Playing) return;
        m_curTimeLimit -= Time.deltaTime;

        if (m_curTimeLimit <= 20)
        {
            if (GUIManager.Ins)
            {
                GUIManager.Ins.x2Money.Show(true);
            }

        }

        if (m_curTimeLimit <= 18.5)
        {
            if (GUIManager.Ins)
            {
                GUIManager.Ins.x2Money.Show(false);
            }
        }
        if (m_curTimeLimit <= 0 && state != GameState.Gameover)
        {
            state = GameState.Gameover;


            if (GUIManager.Ins)
            {
                GUIManager.Ins.GameOverDialog.Show(true);
                if (AudioController.Ins)
                {
                    AudioController.Ins.PlaySound(AudioController.Ins.gameover);
                }
            }
            Debug.Log("GameOver...");
        }
        if (GUIManager.Ins)
        {
            GUIManager.Ins.UpdateTimeBar((float)m_curTimeLimit, (float)timeLimit);
        }

    }
    public void Quit()
    {
        Application.Quit();
        if (AudioController.Ins)
        {
            AudioController.Ins.PlaySound(AudioController.Ins.button);
        }
    }
    public void PlayGame()
    {
        state = GameState.Playing;
        if (AudioController.Ins)
        {
            AudioController.Ins.PlaySound(AudioController.Ins.button);
        }
        if (GUIManager.Ins)
        {
            GUIManager.Ins.ShowGamePlay(true);
        }
    }

    public void AddScore()
    {
        if (state != GameState.Playing) return;


        Pref.bestScore = m_score;

        Debug.Log(m_score);
        if (GUIManager.Ins)
        {
            GUIManager.Ins.UpdateScore(m_score);
        }
    }



}
