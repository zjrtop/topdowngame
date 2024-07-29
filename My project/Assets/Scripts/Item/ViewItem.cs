using System.Collections;
using System.Collections.Generic;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class ViewItem : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite originView;
    // public int sampleRate = 11;

    public Sprite NewView;
    // private int originRate = 7;
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
            // PlayerAnimation parentAnimtionCtl = colliderObj.GetComponentInParent<PlayerAnimation>();
            // if (parentAnimtionCtl)
            // {
            //     parentAnimtionCtl.PlayerDeath();
            // }
            ViewAction viewAction = colliderObj.AddComponent<ViewAction>();
            viewAction.originView = originView;
            viewAction.NewView = NewView;
            viewAction.StartAction();
            Debug.Log("player get dash item " + other.gameObject.name);
            gameObject.SetActive(false);
        }
       

    }


}
