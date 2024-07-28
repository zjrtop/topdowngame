using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform childTransform; // 需要旋转的子对象
    public float maxAngle = 45.0f;   // 最大旋转角度（正负）
    public float speed = 1.0f;       // 摆动速度

    private float currentAngle = 0.0f; // 当前角度
    private int direction = 1;         // 当前旋转方向

    void Start()
    {
        childTransform = transform.Find("ViewSight");
    }

    // Update is called once per frame
    void Update()
    {
        rotate2();
    }
    void rotate()
    {
        // 计算每帧旋转的角度增量
        float deltaAngle = speed * Time.deltaTime;

        // 如果达到最大角度，则反转方向
        if (Mathf.Abs(currentAngle) >= maxAngle)
        {
            direction *= -1; // 反转方向
        }

        // 更新当前角度
        currentAngle += direction * deltaAngle;

        // 限制当前角度在最大角度范围内
        currentAngle = Mathf.Clamp(currentAngle, -maxAngle, maxAngle);

        // 计算子对象相对于父对象的位置
        Vector3 rotationPosition = Quaternion.Euler(0, 0, currentAngle) * Vector3.right;

        // 设置子对象的位置
        childTransform.localPosition = rotationPosition;

        // 可选：同步子对象的旋转角度（使其面向正确方向）
        childTransform.localRotation = Quaternion.Euler(0, 0, currentAngle);
    }
    void rotate2()
    {
        float deltaAngle = speed * Time.deltaTime;

        // 如果到达了最大角度，则反转方向
        if (Mathf.Abs(currentAngle) >= maxAngle)
        {
            direction *= -1; // 反转方向
        }

        // 更新当前角度
        currentAngle += direction * deltaAngle;

        // 限制当前角度在最大角度范围内
        currentAngle = Mathf.Clamp(currentAngle, -maxAngle, maxAngle);

        // 绕父对象的位置旋转
        childTransform.RotateAround(transform.position, Vector3.forward, direction * deltaAngle);
    }
}
