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
            PlayerAnimation parentAnimtionCtl = colliderObj.GetComponentInParent<PlayerAnimation>();
            if (parentAnimtionCtl)
            {
                parentAnimtionCtl.PlayerDeath();
            }
        }
        Debug.Log("Trigger entered with " + other.gameObject.name);
    }

    // 当另一个触发体保持在当前触发体内时调用
    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Trigger staying with " + other.gameObject.name);
    }

    // 当另一个触发体退出当前触发体时调用
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger exited with " + other.gameObject.name);
    }


}
