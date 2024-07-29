using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HunterTouch : MonoBehaviour
{
    // 检查的 PlayerPrefs 键
    public string key1 = "myIntKey";
    public string key2 = "buttonClickStatus";

    // 目标场景名称
    public string scene1 = "HouseScene2";
    public string scene2 = "HouseScene3";

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject colliderObj = other.gameObject;
        if (colliderObj.CompareTag("humanbody"))
        {
            // 获取两个 PlayerPrefs 的值
            int value1 = PlayerPrefs.GetInt(key1, 0);
            int value2 = PlayerPrefs.GetInt(key2, 0);

            // 检查两个值是否都为2
            if (value1 == 2 && value2 == 2)
            {
                SceneManager.LoadScene(scene2);
            }
            else
            {
                SceneManager.LoadScene(scene1);
            }
        }
    }
}