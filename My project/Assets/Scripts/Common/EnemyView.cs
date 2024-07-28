using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    // Start is called before the first frame update



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject colliderObj = other.gameObject;
        if (colliderObj.CompareTag("humanbody"))
        {
            
            PlayerStates playerStates = colliderObj.GetComponentInParent<PlayerStates>();
            PlayerAnimation parentAnimtionCtl = colliderObj.GetComponentInParent<PlayerAnimation>();
            int sheild = playerStates.GetDetectTimes();
            if(sheild == 1)
            {
                playerStates.DecreaseShield();
                Debug.Log("Sheild Consumer");
            }
            else
            {
                if (parentAnimtionCtl)
                {
                    parentAnimtionCtl.PlayerDeath();
                }
                Debug.Log("Player death");
            }
 
        }
        Debug.Log("Trigger entered with " + other.gameObject.name);
    }

    // ����һ�������屣���ڵ�ǰ��������ʱ����
    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Trigger staying with " + other.gameObject.name);
    }

    // ����һ���������˳���ǰ������ʱ����
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger exited with " + other.gameObject.name);
    }


}
