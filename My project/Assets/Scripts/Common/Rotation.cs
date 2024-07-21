using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform childTransform;  // 子组件的Transform
    public float rotationSpeed = 30f; // 旋转速度

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotate();
    }
    void rotate()
    {
        if (childTransform != null)
        {
            // 绕父组件的原点旋转
            childTransform.RotateAround(transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}
