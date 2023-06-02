using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThongBao : Dialog
{
    public override void Show(bool isShow)
    {
        if (AudioController.Ins)
        {
            AudioController.Ins.PlaySound(AudioController.Ins.button);
        }
        base.Show(isShow);

    }
}
