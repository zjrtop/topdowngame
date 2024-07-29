using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayInteract : MonoBehaviour
{
    // Start is called before the first frame update

    public float interactInstance = 100.0f;

    public LayerMask interactableLayer;

    void Start()
    {
    }

    private void DistributeRay()
    {

        Transform parentTransform = transform.parent;
        Vector3 parentPosition =  transform.position;
        // 确保父组件存在
        if (parentTransform != null)
        {
            // 获取父组件位置
            parentPosition = parentTransform.position;

        }

        //Vector3 rayDirection = new Vector2(1.0f, 0.0f);
        /*        Ray ray = new Ray(transform.position, rayDirection);//创建并初始化射线*/
        Vector3 rayDirection = transform.right;

        float rayDistance = 50.0f;//射线距离

        Color rayColor = Color.red;//定义射线颜色

        RaycastHit2D hit;

        hit = Physics2D.Raycast(parentPosition, rayDirection, interactInstance, interactableLayer);
        //debug显示出射线,不显示并不影响实际效果，射线会默认存在

        if (hit.collider != null)
        {
            //默认射线长度
            //Debug.Log("name nothing");
            //Debug.DrawLine(transform.position, transform.position + (Vector3)rayDirection * rayDistance, Color.blue);
            //Debug.DrawRay(transform.position, rayDirection * rayDistance, Color.red, 1.0f);

            //Debug.Log("interact with item");
            //射线碰撞并检测到物体，则让射线距离变为发射源到物体的距离
            //Debug.Log("Hit an interactable item: " + hit.collider.gameObject.name);
            if (hit.collider.gameObject.CompareTag("humanbody"))
            {
                Debug.Log("检测到玩家");
                GameObject colliderObj = hit.collider.gameObject;
                PlayerStates playerStates = colliderObj.GetComponentInParent<PlayerStates>();
                
                PlayerAnimation parentAnimtionCtl = colliderObj.GetComponentInParent<PlayerAnimation>();
                int sheild = playerStates.GetDetectTimes();
                if (sheild == 1)
                {
                    playerStates.DecreaseShield();
                    Debug.Log("Sheild Consumer");
                }
                else
                {
                    if (parentAnimtionCtl)
                    {
                        parentAnimtionCtl.PlayerDeath();
                    }
                    Debug.Log("Player death");
                    PlayerTeleport playerTeleport = colliderObj.GetComponentInParent<PlayerTeleport>();
                    if (playerTeleport != null) {
                        playerTeleport.Teleport();
                    }
                }

            }
            rayDistance = Vector3.Distance(parentPosition, hit.collider.gameObject.transform.position);
        }


    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }
    void Update()
    {
        DistributeRay();

        // 获取玩家的方向（假设玩家面向右侧）
//         Vector2 direction = transform.right;
// 
//         // 在玩家位置发射射线
//         RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, rayLength, interactableLayer);
// 
//         // 可视化射线，方便在编辑器中调试
//         Debug.DrawRay(transform.position, direction * rayLength, Color.green);
// 
//         // 如果射线检测到物体
//         if (hit.collider != null)
//         {
//             Debug.Log("Hit an interactable item: " + hit.collider.gameObject.name);
// 
//             // 调用交互方法
//             InteractWithItem(hit.collider.gameObject);
//         }
    }
}

