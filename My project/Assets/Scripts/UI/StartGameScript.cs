using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Collections;
using UnityEngine.Video;

public class StartGameScript : MonoBehaviour
{
    public Image loadingIcon; // 加载图标
    public GameObject loadingCanvas; // 加载画布
    public Image loadingMask; // 加载遮罩
    public Button startButton; // 开始按钮
    public GameObject menuElements; // 包含所有菜单元素的父对象
    public float blinkDuration = 0.5f; // 闪烁动画时间
    public float maskFadeDuration = 1f; // 遮罩淡出时间
    public float maskToBlackDuration = 1f; // 遮罩变黑时间

    public GameObject videoScreen; // 视频屏幕对象
    private VideoPlayer videoPlayer; // 视频播放器组件

    private CanvasGroup loadingCanvasGroup;

    void Start()
    {
        // 获取 CanvasGroup 组件
        loadingCanvasGroup = loadingCanvas.GetComponent<CanvasGroup>();

        // 确保加载图标初始状态可见
        loadingIcon.color = new Color(loadingIcon.color.r, loadingIcon.color.g, loadingIcon.color.b, 1);
        loadingIcon.gameObject.SetActive(true);

        // 确保加载画布初始状态隐藏
        loadingCanvas.SetActive(false);

        // 确保遮罩初始状态为透明
        loadingMask.color = new Color(loadingMask.color.r, loadingMask.color.g, loadingMask.color.b, 0);

        // 隐藏视频屏幕
        videoScreen.SetActive(false);

        // 播放开屏界面的背景音乐
        if (AudioManager.instance != null)
        {
            Debug.Log("Playing MainMenuBGM");
            AudioManager.instance.Play("MainMenuBGM");
        }
        else
        {
            Debug.LogWarning("AudioManager instance is null");
        }

        // 绑定开始按钮点击事件
        startButton.onClick.AddListener(OnStartButtonClicked);

        // 获取 VideoPlayer 组件
        videoPlayer = videoScreen.GetComponent<VideoPlayer>();

        // 注册视频播放完成事件
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnStartButtonClicked()
    {
        Debug.Log("Start button clicked");

        // 确保所有对象有效
        if (menuElements == null || loadingCanvas == null || loadingIcon == null || loadingMask == null || loadingCanvasGroup == null || videoPlayer == null || videoScreen == null)
        {
            Debug.LogError("One or more required components are not assigned or are missing.");
            return;
        }

        // 播放开始游戏按钮点击音效
        if (AudioManager.instance != null)
        {
            Debug.Log("Playing StartGameClick");
            AudioManager.instance.Play("StartGameClick");
        }
        else
        {
            Debug.LogWarning("AudioManager instance is null");
        }

        // 停止背景音乐
        if (AudioManager.instance != null)
        {
            Debug.Log("Stopping MainMenuBGM");
            AudioManager.instance.Stop("MainMenuBGM");
        }
        else
        {
            Debug.LogWarning("AudioManager instance is null");
        }

        // 隐藏所有菜单元素
        menuElements.SetActive(false);

        // 开始播放视频
        PlayIntroVideo();
    }

    void PlayIntroVideo()
    {
        Debug.Log("Playing intro video");

        // 启用视频屏幕
        videoScreen.SetActive(true);
        // 确保 VideoPlayer 组件启用
        videoPlayer.enabled = true;
        // 播放视频
        videoPlayer.Play();
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("Video finished");

        // 隐藏视频屏幕
        videoScreen.SetActive(false);

        // 显示加载画布
        loadingCanvas.SetActive(true);

        // 开始加载图标闪烁动画
        loadingIcon.DOFade(0f, blinkDuration).SetLoops(-1, LoopType.Yoyo);

        // 开始遮罩从透明变黑
        Debug.Log("Starting mask fade to black");
        loadingMask.DOFade(1f, maskToBlackDuration).OnComplete(() =>
        {
            Debug.Log("Mask is now black, starting scene load");
            // 完全变黑后开始加载新场景
            StartCoroutine(LoadSceneCoroutine("HouseScene"));
        });
    }

    IEnumerator LoadSceneCoroutine(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;

        // 等待一段时间，模拟加载过程
        yield return new WaitForSeconds(maskToBlackDuration);

        // 完成加载后开始淡出遮罩
        Debug.Log("Starting mask fade to transparent");
        loadingMask.DOFade(0f, maskFadeDuration).OnComplete(() =>
        {
            Debug.Log("Mask is now transparent, activating scene");
            asyncOperation.allowSceneActivation = true;
        });
    }
}
