using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite sprite;
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
            ShieldAction shieldAction = colliderObj.GetComponent<ShieldAction>(); 
            if (shieldAction != null)
            {
                shieldAction.Refresh();
            }
            shieldAction = colliderObj.AddComponent<ShieldAction>();
            shieldAction.sprite = sprite;
            shieldAction.StartAction();
            Debug.Log("player get dash item " + other.gameObject.name);
            gameObject.SetActive(false);
        }


    }

    // Start is called before the first frame update

    private void OnTriggerExit2D(Collider2D other)
    {

    }

}
