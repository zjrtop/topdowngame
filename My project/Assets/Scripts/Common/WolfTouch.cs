using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WolfTouch : MonoBehaviour
{
    // 检查的 PlayerPrefs 键
    public string key1 = "myIntKey";
    public string key2 = "buttonClickStatus";

    // 目标场景名称
    public string scene1 = "HouseScene1";
    public string scene2 = "HouseScene2";

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject colliderObj = other.gameObject;
        if (colliderObj.CompareTag("humanbody"))
        {
            // 获取两个 PlayerPrefs 的值
            int value1 = PlayerPrefs.GetInt(key1, 0);
            int value2 = PlayerPrefs.GetInt(key2, 0);

            // 检查两个值是否都为1
            if (value1 == 1 && value2 == 1)
            {
                SceneManager.LoadScene(scene2);
            }
            else if (value1 == 1)
            {
                SceneManager.LoadScene(scene1);
            }
        }
    }
}