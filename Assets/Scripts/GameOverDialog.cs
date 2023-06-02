using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverDialog : Dialog
{
    public Text totalScoreTxt;
    public Text bestScoreTxt;

    public override void Show(bool isShow)
    {
        base.Show(isShow);
        Time.timeScale = 0;

        if (totalScoreTxt && GameManager.Ins)
        {
            totalScoreTxt.text = GameManager.Ins.Score.ToString();
        }

        if (bestScoreTxt)
        {
            bestScoreTxt.text = Pref.bestScore.ToString();
        }


    }
    public void BackToMenu()
    {
        if (AudioController.Ins)
        {
            AudioController.Ins.PlaySound(AudioController.Ins.button);
        }
        Time.timeScale = 1;
        if (SceneController.Ins)
        {
            SceneController.Ins.LoadCurrentScene();
        }


    }
    public void Continue()
    {
        if (AudioController.Ins)
        {
            AudioController.Ins.PlaySound(AudioController.Ins.button);
        }
        Time.timeScale = 1;
        SceneManager.sceneLoaded += OnSceneLoadEvent;

        if (SceneController.Ins)
        {
            SceneController.Ins.LoadCurrentScene();
        }
    }
    public void Replay()
    {
        if (AudioController.Ins)
        {
            AudioController.Ins.PlaySound(AudioController.Ins.button);
        }
        GameManager.Ins.PlayGame();
    }

    private void OnSceneLoadEvent(Scene scene, LoadSceneMode mode)
    {
        if (GameManager.Ins)
        {
            GameManager.Ins.PlayGame();
        }
        SceneManager.sceneLoaded -= OnSceneLoadEvent;
    }
}

