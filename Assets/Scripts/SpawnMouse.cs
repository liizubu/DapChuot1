using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMouse : MonoBehaviour
{

    Rigidbody2D m_rb;
    public Transform[] m_poitSpawn;
    public GameObject[] m_mouse;
    public GameObject[] stun;
    private bool m_isDead;
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

        if (GameManager.Ins.CurTimeLimit > 20)
        {
            InvokeRepeating("Spawn", 1.2f, 1.3f);
            Debug.Log("X2");
        }
        if (GameManager.Ins.CurTimeLimit <= 20)
        {
            InvokeRepeating("Spawn", 0.8f, 1f);
            Debug.Log("X3");

        }
    }
    public void Spawn()
    {
        if (GameManager.Ins.state != GameState.Playing) return;


        Instantiate(m_mouse[Random.Range(0, 5)], m_poitSpawn[Random.Range(0, 9)].position, Quaternion.identity);
    }

}
