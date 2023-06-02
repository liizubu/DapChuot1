using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MucTieu : MonoBehaviour
{
    public int dollar;
    public GameObject deathVfx;
    public virtual void Die()
    {

    }

    public void Update()
    {
        StartCoroutine(waiter());
    }
    public IEnumerator waiter()
    {
        if (GameManager.Ins.state == GameState.Playing)
        {
            yield return new WaitForSeconds(1.2f);
            Object.Destroy(this.gameObject);
        }

        if (GameManager.Ins.state == GameState.Gameover)
        {
            Object.Destroy(this.gameObject);
        }
    }
}
