using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewAction : BaseAction
{
    // Start is called before the first frame update
    public Sprite originView;
    // public int sampleRate = 11;

    public Sprite NewView;
    // private int originRate = 7;

    void Start()
    {
        duration = 10.0f;
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
        GameObject target = GameObject.FindWithTag("maskview");
        Image image = target.GetComponent<Image>();

        image.sprite = NewView;
        // PlayerAnimation playerAnimation = GetComponentInParent<PlayerAnimation>();
        //       if (playerAnimation == null) Debug.Log("Dash fuck2 fuck2");

        // if (movationTouch != null && playerAnimation != null)
        // if (movationTouch != null){
        //     Debug.Log("Dash go go");
        //     movationTouch.moveSpeed = dashSpeed;
        //     //playerAnimation.SetAnimationRate("walk", sampleRate);
        // }
    }

    public new void StopAction(){
        base.StopAction();
        GameObject target = GameObject.FindWithTag("maskview");
        Image image = target.GetComponent<Image>();

        image.sprite = originView;
        Destroy(this);
    }
}
