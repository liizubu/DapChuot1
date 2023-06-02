using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{

    public float fireRate;
    public float m_curFireRate;
    public GameObject hammer;
    GameObject m_hamerClone;

    public bool m_isShooted;


    private void Start()
    {
        //if (GameManager.Ins.state == GameState.Playing && hammer != null)
        //{
        //    m_hamerClone = Instantiate(hammer, Vector3.zero, Quaternion.identity);

        //}
    }

    //m_hamerClone = Instantiate(hammer, Vector3.zero, Quaternion.identity);


    private void Awake()
    {
        m_curFireRate = fireRate;
    }
    private void Update()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && !m_isShooted)
        {
            Shot(mousePos);
        }

        if (m_isShooted)
        {
            m_curFireRate -= Time.deltaTime;

            if (m_curFireRate <= 0)
            {
                m_isShooted = false;

                m_curFireRate = fireRate;
            }
        }
        if (m_hamerClone)
        {
            m_hamerClone.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
        }
    }
    public void Shot(Vector3 mousePos)
    {
        m_isShooted = true;

        Vector3 shootDir = Camera.main.transform.position - mousePos;

        shootDir.Normalize();

        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos, shootDir);
        if (hits != null && hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];

                if (hit.collider != null && (Vector3.Distance((Vector2)hit.collider.transform.position, (Vector2)mousePos) <= 0.4f))
                {
                    MucTieu muctieu = hit.collider.GetComponent<MucTieu>();
                    if (muctieu)
                    {
                        muctieu.Die();
                        GameManager.Ins.AddScore();
                    }






                }
            }
        }
    }

}

