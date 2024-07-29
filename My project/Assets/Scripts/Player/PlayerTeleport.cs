using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerTeleport : MonoBehaviour
{
    // Start is called before the first frame update

    public int progress;
    Vector3 position = Vector3.zero;
    Rigidbody2D rb;

    void Start()
    {
        int defaultValue = 1; // 如果键不存在，则返回默认值

        progress = PlayerPrefs.GetInt("myIntKey", defaultValue);

        PlayerStates playerStates = GetComponent<PlayerStates>();

        playerStates.progress = progress;



        Debug.Log(progress);
        if (progress == 1)
        {
            GameObject point = GameObject.FindWithTag("bornpoint1");
            if (point != null)
            {
                position = point.transform.position;
            }
        }
        else if (progress == 2)
        {
            GameObject point = GameObject.FindWithTag("bornpoint2");
            if (point != null)
            {
                position = point.transform.position;
            }
        }
        else if (progress == 3)
        {
            GameObject point = GameObject.FindWithTag("bornpoint2");
            if (point != null)
            {
                position = point.transform.position;
            }
        }
            rb = GetComponent<Rigidbody2D>();
        Teleport();
    }

    public void Teleport()
    {
        Vector3 destination = position;


        if (rb != null)
        {
            rb.isKinematic = true;
        }

        transform.position = destination;

        if (rb != null)
        {
            rb.isKinematic = false;
        }

        Debug.Log("玩家已瞬移到位置：" + destination);
    }
}
