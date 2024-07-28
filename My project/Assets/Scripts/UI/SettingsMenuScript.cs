using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuScript : MonoBehaviour
{
    public GameObject panelToClose; // 要关闭的面板

    void Start()
    {
        // 绑定关闭按钮的点击事件
        Button closeButton = GetComponent<Button>();
        closeButton.onClick.AddListener(ClosePanel);
    }

    void ClosePanel()
    {
        // 关闭面板
        panelToClose.SetActive(false);
    }
}
