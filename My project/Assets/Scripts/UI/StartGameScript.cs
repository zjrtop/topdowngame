using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Collections;

public class StartGameScript : MonoBehaviour
{
    public Image loadingIcon; // 加载图标
    public GameObject loadingPanel; // 加载面板
    public Image loadingMask; // 加载遮罩
    public Button startButton; // 开始按钮
    public GameObject menuElements; // 包含所有菜单元素的父对象
    public float blinkDuration = 0.5f; // 闪烁动画时间
    public float maskFadeDuration = 1f; // 遮罩淡出时间

    private CanvasGroup loadingPanelCanvasGroup;

    void Start()
    {
        // 获取 CanvasGroup 组件
        loadingPanelCanvasGroup = loadingPanel.GetComponent<CanvasGroup>();

        // 确保加载图标初始状态可见
        loadingIcon.color = new Color(loadingIcon.color.r, loadingIcon.color.g, loadingIcon.color.b, 1);
        loadingIcon.gameObject.SetActive(true);

        // 确保加载面板和加载遮罩初始状态为不透明
        loadingPanel.SetActive(false);
        loadingMask.color = new Color(loadingMask.color.r, loadingMask.color.g, loadingMask.color.b, 1);

        // 绑定开始按钮点击事件
        startButton.onClick.AddListener(OnStartButtonClicked);
    }

    void OnStartButtonClicked()
    {
        // 确保所有对象有效
        if (menuElements == null || loadingPanel == null || loadingIcon == null || loadingMask == null || loadingPanelCanvasGroup == null)
        {
            Debug.LogError("One or more required components are not assigned or are missing.");
            return;
        }

        // 隐藏所有菜单元素
        menuElements.SetActive(false);

        // 显示加载面板
        loadingPanel.SetActive(true);

        // 开始加载图标闪烁动画
        loadingIcon.DOFade(0f, blinkDuration).SetLoops(-1, LoopType.Yoyo);

        // 开始遮罩透明度变化动画
        loadingMask.DOFade(0f, maskFadeDuration).OnComplete(() =>
        {
            // 停止加载图标的闪烁动画
            loadingIcon.DOKill();

            // 加载新场景
            StartCoroutine(LoadSceneCoroutine("HouseScene")); // 确保这里的名称与构建设置中的场景名称一致
        });

        // 同时淡出整个加载面板
        DOTween.To(() => loadingPanelCanvasGroup.alpha, x => loadingPanelCanvasGroup.alpha = x, 0f, maskFadeDuration);
    }

    IEnumerator LoadSceneCoroutine(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;

        yield return new WaitForSeconds(maskFadeDuration);

        // 在遮罩完全透明后，激活场景
        asyncOperation.allowSceneActivation = true;
    }
}
