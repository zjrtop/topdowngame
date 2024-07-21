using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform childTransform;  // �������Transform
    public float rotationSpeed = 30f; // ��ת�ٶ�

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
            // �Ƹ������ԭ����ת
            childTransform.RotateAround(transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}
