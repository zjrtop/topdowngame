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
                // 尝试查找已有的实例
                _instance = FindObjectOfType<GameGlobal>();

                if (_instance == null)
                {
                    // 如果不存在，创建一个新的GameManager对象
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<GameGlobal>();
                    singletonObject.name = typeof(GameGlobal).ToString() + " (Singleton)";

                    // 确保该单例对象在场景切换时不会被销毁
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
            // 如果不存在实例，则设置自己为实例
            _instance = this;
            DontDestroyOnLoad(gameObject); // 确保单例不会被销毁
        }
        else if (_instance != this)
        {
            // 如果实例已经存在并且不是自己，则销毁自己
            Destroy(gameObject);
        }
    }
}
