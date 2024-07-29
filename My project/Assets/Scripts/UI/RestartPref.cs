using UnityEngine;

public class RestartPrefs : MonoBehaviour
{
    void Start()
    {
        // 重置特定的 PlayerPrefs 值
        PlayerPrefs.SetInt("myIntKey", 0);  
        PlayerPrefs.SetInt("buttonClickStatus", 0);
        PlayerPrefs.Save();

        // 或者清除所有的 PlayerPrefs
        // PlayerPrefs.DeleteAll();
    }
}