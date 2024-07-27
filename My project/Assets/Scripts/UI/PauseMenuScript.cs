using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject settingsPanel;

    // 方法用于显示设置界面
    public void ShowSettings()
    {
        Debug.Log("ShowSettings called"); // 调试信息
        if (settingsPanel != null && pausePanel != null)
        {
            Debug.Log("SettingsPanel and PausePanel are not null"); // 调试信息
            settingsPanel.SetActive(true);
            pausePanel.SetActive(false);
            Debug.Log("SettingsPanel should be active and PausePanel should be inactive"); // 调试信息
        }
        else
        {
            Debug.LogWarning("SettingsPanel or PausePanel is not set");
        }
    }

    // 方法用于继续游戏
    public void ContinueGame()
    {
        Debug.Log("ContinueGame called"); // 调试信息
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1; // 继续游戏
            Debug.Log("PausePanel should be inactive and game should continue"); // 调试信息
        }
        else
        {
            Debug.LogWarning("PausePanel is not set");
        }
    }
}
