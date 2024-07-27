using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameScript : MonoBehaviour
{
    public Button startButton;
    public GameObject loadingIcon;
    public GameObject uiElements;
    public string nextSceneName;
    public Vector2 loadingIconCenterPosition = new Vector2(0, 0); // 中央位置

    void Start()
    {
        // 将按钮点击事件绑定到方法
        startButton.onClick.AddListener(OnStartButtonClicked);

        // 确保在游戏开始时，加载图标是显示的
        loadingIcon.SetActive(true);
    }

    void OnStartButtonClicked()
    {
        // 仅显示加载图标，隐藏其他UI元素
        uiElements.SetActive(false); // 隐藏UI元素
        MoveLoadingIconToCenter(); // 将加载图标移动到中央
        // 开始异步加载场景
        StartCoroutine(LoadNextScene());
    }

    void MoveLoadingIconToCenter()
    {
        RectTransform rectTransform = loadingIcon.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = loadingIconCenterPosition;
    }

    System.Collections.IEnumerator LoadNextScene()
    {
        // 异步加载场景
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(nextSceneName);

        // 在场景加载完成前，保持加载图标显示
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
