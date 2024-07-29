using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameObject colliderObj = other.gameObject;
        if (colliderObj.CompareTag("humanbody"))
        {

            DashAction dashAction = colliderObj.GetComponent<DashAction>();
            if (dashAction != null) {
                dashAction.Refresh();
            }
            else
            {
                dashAction = colliderObj.AddComponent<DashAction>();
                dashAction.StartAction();
                Debug.Log("player get dash item " + other.gameObject.name);
                gameObject.SetActive(false);
            }

        }
       

    }

    private void OnTriggerExit2D(Collider2D other) {
        
    }

}
