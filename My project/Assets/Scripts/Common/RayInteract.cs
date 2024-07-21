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
        
        Vector3 rayDirection = new Vector2(1.0f, 0.0f);
/*        Ray ray = new Ray(transform.position, rayDirection);//��������ʼ������*/


        float rayDistance = 100.0f;//���߾���

        Color rayColor = Color.red;//����������ɫ

        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, rayDirection, interactInstance, interactableLayer);
        //debug��ʾ������,����ʾ����Ӱ��ʵ��Ч�������߻�Ĭ�ϴ���

        if (hit.collider == null)
        {
            //Ĭ�����߳���
            //Debug.Log("name nothing");
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + (Vector3)rayDirection * rayDistance, Color.blue);
            Debug.DrawRay(transform.position, rayDirection * rayDistance, Color.red, 1.0f);

            //Debug.Log("interact with item");
            //������ײ����⵽���壬�������߾����Ϊ����Դ������ľ���
            //Debug.Log("Hit an interactable item: " + hit.collider.gameObject.name);
            if (hit.collider.gameObject.CompareTag("Item"))
            {
                Debug.Log("��⵽����");
            }
            rayDistance = Vector3.Distance(transform.position, hit.collider.gameObject.transform.position);
        }


    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }
    void Update()
    {
        DistributeRay();

        // ��ȡ��ҵķ��򣨼�����������Ҳࣩ
//         Vector2 direction = transform.right;
// 
//         // �����λ�÷�������
//         RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, rayLength, interactableLayer);
// 
//         // ���ӻ����ߣ������ڱ༭���е���
//         Debug.DrawRay(transform.position, direction * rayLength, Color.green);
// 
//         // ������߼�⵽����
//         if (hit.collider != null)
//         {
//             Debug.Log("Hit an interactable item: " + hit.collider.gameObject.name);
// 
//             // ���ý�������
//             InteractWithItem(hit.collider.gameObject);
//         }
    }
}

