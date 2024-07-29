using UnityEngine;

public class SavePref2 : MonoBehaviour
{
    // 设置的 PlayerPrefs 的键和值
    public string key = "myIntKey";
    public int value = 2;

    void OnTriggerEnter2D(Collider2D other)
    {
        // 检查进入触发器区域的对象是否是玩家（基于标签）
        if (other.CompareTag("humanbody"))
        {
            Debug.Log("Player entered trigger area. Setting PlayerPrefs.");

            // 设置 PlayerPrefs 状态
            PlayerPrefs.SetInt(key, value);
            PlayerPrefs.Save(); // 确保立即写入磁盘
        }
    }
}