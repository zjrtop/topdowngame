using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAction : BaseAction
{
    // Start is called before the first frame update

    public Sprite sprite;
    void Start()
    {
        duration = 25.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (bIsRunning == true){
            if (GetTimeRemaining() <= 0){
                StopAction();
            }
        }
    }

    public new void StartAction (){
        base.StartAction();
        PlayerStates playerStates = GetComponentInParent<PlayerStates>();         // 获取移动组件。
        // PlayerAnimation playerAnimation = GetComponentInParent<PlayerAnimation>();
        //       if (playerAnimation == null) Debug.Log("Dash fuck2 fuck2");

        // if (movationTouch != null && playerAnimation != null)
        if (playerStates != null){
            playerStates.IncrementShield();
            //playerAnimation.SetAnimationRate("walk", sampleRate);
        }

        Transform parentTransform = transform.parent;
        
        if (parentTransform != null)
        {
            // 在父对象中查找名为"C"的子对象
            Transform cTransform = parentTransform.Find("UpperBuffer");
            
            if (cTransform != null)
            {
                // 获取子对象C的GameObject
                GameObject cGameObject = cTransform.gameObject;
                Debug.Log("Found child GameObject C: " + cGameObject.name);
                SpriteRenderer spriteRenderer = cGameObject.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    Debug.Log("Found MyComponent in ChildObject.");
                    spriteRenderer.sprite = sprite;
                }
            }


  
    }
    }
    public new void StopAction(){
        base.StopAction();
       PlayerStates playerStates = GetComponentInParent<PlayerStates>();         // 获取移动组件。
        // PlayerAnimation playerAnimation = GetComponentInParent<PlayerAnimation>();
        //       if (playerAnimation == null) Debug.Log("Dash fuck2 fuck2");

        // if (movationTouch != null && playerAnimation != null)
        if (playerStates != null){
            playerStates.DecreaseShield();
            //playerAnimation.SetAnimationRate("walk", sampleRate);
        }
                 Transform parentTransform = transform.parent;
        
        if (parentTransform != null)
        {
            // 在父对象中查找名为"C"的子对象
            Transform cTransform = parentTransform.Find("UpperBuffer");
            
            if (cTransform != null)
            {
                // 获取子对象C的GameObject
                GameObject cGameObject = cTransform.gameObject;
                Debug.Log("Found child GameObject C: " + cGameObject.name);
                SpriteRenderer spriteRenderer = cGameObject.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    Debug.Log("Found MyComponent in ChildObject.");
                    spriteRenderer.sprite = null;
                }
            }


  
        }
        Destroy(this);
    }
}
