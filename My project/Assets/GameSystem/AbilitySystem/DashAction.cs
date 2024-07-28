using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DashAction : BaseAction
{
    // Start is called before the first frame update
    public float dashSpeed = 500.0f;
    // public int sampleRate = 11;

    private float walkSpeed = 200.0f;
    // private int originRate = 7;

    void Start()
    {
        duration = 5.0f;
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
        MovationTouch movationTouch = GetComponentInParent<MovationTouch>();         // 获取移动组件。
        if (movationTouch == null) Debug.Log("Dash fuck fuck");
        // PlayerAnimation playerAnimation = GetComponentInParent<PlayerAnimation>();
        //       if (playerAnimation == null) Debug.Log("Dash fuck2 fuck2");

        // if (movationTouch != null && playerAnimation != null)
        if (movationTouch != null){
            Debug.Log("Dash go go");
            movationTouch.moveSpeed = dashSpeed;
            //playerAnimation.SetAnimationRate("walk", sampleRate);
        }
    }

    public new void StopAction(){
        base.StopAction();
        MovationTouch movationTouch = GetComponentInParent<MovationTouch>();         // 获取移动组件。
        // PlayerAnimation playerAnimation = GetComponentInParent<PlayerAnimation>();
        //  if (movationTouch != null && playerAnimation != null)
        if (movationTouch != null){
            Debug.Log("Dash stop stop");
            movationTouch.moveSpeed = walkSpeed;
            // playerAnimation.SetAnimationRate("walk", originRate);
        }
        Destroy(this);
    }
}
