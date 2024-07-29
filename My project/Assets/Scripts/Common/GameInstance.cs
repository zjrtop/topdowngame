using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameInstance Instance;

    //Ҫ����ʹ�õ�����;
    public int item;

    public int progress = 1;
    //��ʼ��
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }
}
