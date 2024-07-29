using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoPanelManager : MonoBehaviour
{
    public TMP_Text infoText;  // 显示信息的文本组件
    public Button closeButton; // 关闭信息的按钮

    public string info; // 要显示的单条信息

    private bool isInfoActive = false; // 信息框是否激活

    void Start()
    {
        closeButton.onClick.AddListener(OnCloseButtonClick);

        // 确保信息框初始状态是隐藏的
        transform.gameObject.SetActive(false); 
    }

    public void ShowInfo()
    {
        isInfoActive = true;
        infoText.text = info;
        transform.gameObject.SetActive(true); // 显示信息框
    }

    public void OnCloseButtonClick()
    {
        isInfoActive = false;
        transform.gameObject.SetActive(false); // 隐藏信息框
    }
}