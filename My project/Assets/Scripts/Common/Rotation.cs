using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform childTransform; // ��Ҫ��ת���Ӷ���
    public float maxAngle = 45.0f;   // �����ת�Ƕȣ�������
    public float speed = 1.0f;       // �ڶ��ٶ�

    private float currentAngle = 0.0f; // ��ǰ�Ƕ�
    private int direction = 1;         // ��ǰ��ת����

    void Start()
    {
        childTransform = transform.Find("ViewSight");
    }

    // Update is called once per frame
    void Update()
    {
        rotate2();
    }
    // void rotate()
    // {
    //     // ����ÿ֡��ת�ĽǶ�����
    //     float deltaAngle = speed * Time.deltaTime;

    //     // ����ﵽ���Ƕȣ���ת����
    //     if (Mathf.Abs(currentAngle) >= maxAngle)
    //     {
    //         direction *= -1; // ��ת����
    //     }

    //     // ���µ�ǰ�Ƕ�
    //     currentAngle += direction * deltaAngle;

    //     // ���Ƶ�ǰ�Ƕ������Ƕȷ�Χ��
    //     currentAngle = Mathf.Clamp(currentAngle, -maxAngle, maxAngle);

    //     // �����Ӷ�������ڸ������λ��
    //     Vector3 rotationPosition = Quaternion.Euler(0, 0, currentAngle) * Vector3.right;

    //     // �����Ӷ����λ��
    //     childTransform.localPosition = rotationPosition;

    //     // ��ѡ��ͬ���Ӷ������ת�Ƕȣ�ʹ��������ȷ����
    //     childTransform.localRotation = Quaternion.Euler(0, 0, currentAngle);
    // }
    void rotate2()
    {
        float deltaAngle = speed * Time.deltaTime;

        // ������������Ƕȣ���ת����
        if (Mathf.Abs(currentAngle) >= maxAngle)
        {
            direction *= -1; // ��ת����
        }

        // ���µ�ǰ�Ƕ�
        currentAngle += direction * deltaAngle;

        // ���Ƶ�ǰ�Ƕ������Ƕȷ�Χ��
        currentAngle = Mathf.Clamp(currentAngle, -maxAngle, maxAngle);

        // �Ƹ������λ����ת
        childTransform.RotateAround(transform.position, Vector3.forward, direction * deltaAngle);
    }
}
