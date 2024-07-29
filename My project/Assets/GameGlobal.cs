using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameGlobal : MonoBehaviour
{
    // Start is called before the first frame update

    private static GameGlobal _instance;

    public static GameGlobal Instance
    {
        get
        {
            if (_instance == null)
            {
                // ���Բ������е�ʵ��
                _instance = FindObjectOfType<GameGlobal>();

                if (_instance == null)
                {
                    // ��������ڣ�����һ���µ�GameManager����
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<GameGlobal>();
                    singletonObject.name = typeof(GameGlobal).ToString() + " (Singleton)";

                    // ȷ���õ��������ڳ����л�ʱ���ᱻ����
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return _instance;
        }
    }

    public int progress;
    void Awake()
    {
        if (_instance == null)
        {
            // ���������ʵ�����������Լ�Ϊʵ��
            _instance = this;
            DontDestroyOnLoad(gameObject); // ȷ���������ᱻ����
        }
        else if (_instance != this)
        {
            // ���ʵ���Ѿ����ڲ��Ҳ����Լ����������Լ�
            Destroy(gameObject);
        }
    }
}
