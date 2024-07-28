using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseAction : MonoBehaviour
{
    public float duration = 5.0f;
    public bool bIsRunning = false;

    private float startTime;




    public float GetTimeRemaining(){
        return duration - Time.time + startTime;
    }
    public virtual void StartAction(){
  
    
    Transform parentTransform = transform.parent;

        if (parentTransform != null)
        {
            // 打印自己的名字
            Debug.Log(string.Format("Runing: %s",  GetType().Name));
        }

        
        startTime = Time.time;
        bIsRunning = true;
    }

    public virtual void StopAction(){
	//LogScreen(this, FString::Printf(TEXT("Started : %s"), *ActionName.ToString()), FColor::Green);
    
        Transform parentTransform = transform.parent;

        if (parentTransform != null)
        {
            // 如果父对象存在，获取父对象的GameObject并打印其名字
            Debug.Log(string.Format("Stop: %s", GetType().Name));
        }

        
        startTime = -1 ;
        bIsRunning = false;
    }

    public bool CanStart(){
        return true;
    }
}
