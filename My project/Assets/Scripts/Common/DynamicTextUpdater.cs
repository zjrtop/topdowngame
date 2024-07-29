using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DynamicTextUpdater : MonoBehaviour
{
    public TextMeshProUGUI targetText;

    private string previousSceneKey = "PreviousScene";

    void Start()
    {
        // 获取上一个场景的名称
        string previousScene = PlayerPrefs.GetString(previousSceneKey, "DefaultScene");

        // 根据上一个场景的名称设置目标文本
        switch (previousScene)
        {
            case "HouseScene1":
                targetText.text = "目标：找到并净化大灰狼";
                break;
            case "HouseScene2":
                targetText.text = "目标：找到并净化猎人";
                break;
            case "HouseScene3":
                targetText.text = "目标：找到并净化奶奶";
                break;
            default:
                targetText.text = "目标：未知";
                break;
        }
    }

    // 在当前场景加载时，更新上一个场景记录（适用于单场景包装的情景）
    void Awake()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString(previousSceneKey, currentSceneName);
        PlayerPrefs.Save();
    }
}