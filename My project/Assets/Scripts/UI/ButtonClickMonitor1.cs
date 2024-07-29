using UnityEngine;
using UnityEngine.UI;

public class ButtonClickMonitor1 : MonoBehaviour
{
    // 设置的 PlayerPrefs 的键和值
    public string playerPrefsKey = "buttonClickStatus";
    public int prefsValue = 1;
    public Button observedButton; // 引用需要监控的按钮

    void Start()
    {
        if (observedButton != null)
        {
            observedButton.onClick.AddListener(OnButtonClicked);
        }
    }

    void OnButtonClicked()
    {
        Debug.Log($"Button clicked. Setting PlayerPrefs key: {playerPrefsKey} to value: {prefsValue}");

        // 设置 PlayerPrefs 状态
        PlayerPrefs.SetInt(playerPrefsKey, prefsValue);
        PlayerPrefs.Save(); // 确保立即写入磁盘
    }

    void OnDestroy()
    {
        if (observedButton != null)
        {
            observedButton.onClick.RemoveListener(OnButtonClicked);
        }
    }
}