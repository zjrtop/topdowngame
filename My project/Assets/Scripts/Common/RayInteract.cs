using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayInteract : MonoBehaviour
{
    // Start is called before the first frame update

    public float interactInstance = 100.0f;



    void Start()
    {

    }

    private void DistributeRay()
    {
        Vector3 rayDirection = new Vector3(1.0f, 1.0f, 0.0f);
        Ray ray = new Ray(transform.position, rayDirection);//创建并初始化射线
        float rayDistance = 0.0f;//射线距离
        Color rayColor = Color.red;//定义射线颜色
        RaycastHit hit;//检测射线碰撞 

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.CompareTag("Item"))
            {
                Debug.Log("检测到物体");
            }
        }
        if (hit.collider == null)
        {
            //默认射线长度
            rayDistance = 20.0f;
        }
        else
        {
            Debug.Log("interact with item");
            //射线碰撞并检测到物体，则让射线距离变为发射源到物体的距离
            rayDistance = Vector3.Distance(transform.position, hit.collider.gameObject.transform.position);
        }
        //debug显示出射线,不显示并不影响实际效果，射线会默认存在
        Debug.DrawRay(ray.origin, rayDirection * rayDistance, rayColor);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }
    void Update()
    {
        DistributeRay();
    }
}
