using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrandMomTouch : MonoBehaviour
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
        // ??????????Transform
        GameObject colliderObj = other.gameObject;


        if (colliderObj.CompareTag("humanbody"))
        {
            PlayerStates playerStates = colliderObj.GetComponentInParent<PlayerStates>();
            int progress = playerStates.progress;
            if (progress == 3) 
            SceneManager.LoadScene("HouseScene4");
        }
    }
   }
