using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseDialog : Dialog
{
    public override void Show(bool isShow)
    {
        if (AudioController.Ins)
        {
            AudioController.Ins.PlaySound(AudioController.Ins.button);
        }
        base.Show(isShow);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        if (AudioController.Ins)
        {
            AudioController.Ins.PlaySound(AudioController.Ins.button);
        }
        Time.timeScale = 1f;
        Close();
    }

    public void BackToMenu()
    {
        if (AudioController.Ins)
        {
            AudioController.Ins.PlaySound(AudioController.Ins.button);
        }
        Time.timeScale = 1f;
        if (SceneController.Ins)
        {
            SceneController.Ins.LoadCurrentScene();
        }
    }
}
