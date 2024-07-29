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
        int defaultValue = 2; // ����������ڣ��򷵻�Ĭ��ֵ

        //progress = PlayerPrefs.GetInt("myIntKey", defaultValue);
        progress = GameGlobal.Instance.progress;

        int randomPos = Random.Range(1, 4); // �ڴˣ�upper bound�Ƿǰ�����
        PlayerStates playerStates = GetComponent<PlayerStates>();

        Debug.Log("PROGRESS EQUALS " + progress.ToString());

        playerStates.progress = PlayerPrefs.GetInt("myIntKey", defaultValue); ;



        Debug.Log(progress);
        if (randomPos == 1)
        {
            GameObject point = GameObject.FindWithTag("bornpoint1");
            if (point != null)
            {
                position = point.transform.position;
            }
        }
        else if (randomPos == 2)
        {
            GameObject point = GameObject.FindWithTag("bornpoint2");
            if (point != null)
            {
                position = point.transform.position;
            }
        }
        else if (randomPos == 3)
        {
            GameObject point = GameObject.FindWithTag("bornpoint3");
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

        Debug.Log(destination);
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        transform.position = destination;

        if (rb != null)
        {
            rb.isKinematic = false;
        }

        Debug.Log("�����˲�Ƶ�λ�ã�" + destination);
    }
}
