using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransportScene : MonoBehaviour
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
        // 获取父组件的Transform
        GameObject colliderObj = other.gameObject;
        if (colliderObj.CompareTag("humanbody"))
        {
            Transform parentTransform = colliderObj.transform.parent;

            if (parentTransform != null)
            {
                // 获取父组件的GameObject
                GameObject parentGameObject = parentTransform.gameObject;

                // 打印父组件的名字
                Debug.Log("Parent GameObject: " + parentGameObject.name);
                DontDestroyOnLoad(parentGameObject);
                SceneManager.LoadScene("HouseScene");
            }
            else
            {
                Debug.LogWarning("This GameObject does not have a parent.");
            }
        }
            
    }



}
