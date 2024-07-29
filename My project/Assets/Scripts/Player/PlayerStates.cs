using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerStates : MonoBehaviour
{
    private int detectTimes = 0;

    public bool bIsTalkWithMerchant = false;

    public int progress = 0;

    public Sprite sprite;


    public void IncrementShield() {



        // �ڸ������в�����Ϊ"C"���Ӷ���
        Transform cTransform = transform.Find("UpperBuffer");

        if (cTransform != null)
        {
            // ��ȡ�Ӷ���C��GameObject
            GameObject cGameObject = cTransform.gameObject;
            Debug.Log("Found child GameObject C: " + cGameObject.name);
            SpriteRenderer spriteRenderer = cGameObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                Debug.Log("Found MyComponent in ChildObject.");
                spriteRenderer.sprite = sprite;
            }
            
        }
        detectTimes =  1;
    }

    public void DecreaseShield() {
        detectTimes = 0;
        Transform cTransform = transform.Find("UpperBuffer");

        if (cTransform != null)
        {
            // ��ȡ�Ӷ���C��GameObject
            GameObject cGameObject = cTransform.gameObject;
            Debug.Log("Found child GameObject C: " + cGameObject.name);
            SpriteRenderer spriteRenderer = cGameObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                Debug.Log("Found MyComponent in ChildObject.");
                spriteRenderer.sprite = null;
            }

        }
        detectTimes = 1;
    }

    public int GetDetectTimes() {
        return detectTimes;
    }


    public void SaveData()
    {
        GameInstance.Instance.item = progress;
    }
}
