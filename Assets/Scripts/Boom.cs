using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MucTieu
{
    public override void Die()
    {
        if (GameManager.Ins.CurTimeLimit > 20)
        {
            GameManager.Ins.Score += dollar;
        }

        if (GameManager.Ins.CurTimeLimit <= 20)
        {
            GameManager.Ins.Score += 2 * dollar;
        }
        if (AudioController.Ins)
        {
            AudioController.Ins.PlaySound(AudioController.Ins.bomno);
        }

        if (deathVfx)
        {
            Instantiate(deathVfx, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
