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
        Ray ray = new Ray(transform.position, rayDirection);//��������ʼ������
        float rayDistance = 0.0f;//���߾���
        Color rayColor = Color.red;//����������ɫ
        RaycastHit hit;//���������ײ 

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.CompareTag("Item"))
            {
                Debug.Log("��⵽����");
            }
        }
        if (hit.collider == null)
        {
            //Ĭ�����߳���
            rayDistance = 20.0f;
        }
        else
        {
            Debug.Log("interact with item");
            //������ײ����⵽���壬�������߾����Ϊ����Դ������ľ���
            rayDistance = Vector3.Distance(transform.position, hit.collider.gameObject.transform.position);
        }
        //debug��ʾ������,����ʾ����Ӱ��ʵ��Ч�������߻�Ĭ�ϴ���
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
