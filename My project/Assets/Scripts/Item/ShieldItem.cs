using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject colliderObj = other.gameObject;
        if (colliderObj.CompareTag("humanbody"))
        {
            // PlayerAnimation parentAnimtionCtl = colliderObj.GetComponentInParent<PlayerAnimation>();
            // if (parentAnimtionCtl)
            // {
            //     parentAnimtionCtl.PlayerDeath();
            // }
            PlayerStates playerStates = colliderObj.GetComponentInParent<PlayerStates>();

            if (playerStates != null) {
                playerStates.IncrementShield();

            }
            Debug.Log("player get shield item " + other.gameObject.name);


        }


    }

    // Start is called before the first frame update

    private void OnTriggerExit2D(Collider2D other)
    {

    }

}
