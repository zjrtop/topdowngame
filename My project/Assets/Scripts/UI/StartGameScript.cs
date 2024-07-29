using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Collections;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class StartGameScript : MonoBehaviour
{
    public Image loadingIcon; // 加载图标
    public GameObject loadingCanvas; // 加载画布
    public Image loadingMask; // 加载遮罩
    public Button startButton; // 开始按钮
    public GameObject menuElements; // 包含所有菜单元素的父对象
    public Slider progressBar; // 进度条
    public float blinkDuration = 0.5f; // 闪烁动画时间
    public float maskFadeDuration = 1f; // 遮罩淡出时间
    public float maskToBlackDuration = 1f; // 遮罩变黑时间

    public GameObject videoScreen; // 视频屏幕对象
    private VideoPlayer videoPlayer; // 视频播放器组件

    private CanvasGroup loadingCanvasGroup;
    private bool isDragging = false;
    private float lastInteractionTime;
    public float interactionTimeout = 2f; // 用户交互后进度条显示的时间

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

        // 隐藏视频屏幕和进度条
        videoScreen.SetActive(false);
        progressBar.gameObject.SetActive(false);

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

        // 绑定进度条事件
        progressBar.onValueChanged.AddListener(OnProgressBarChanged);

        // 添加 EventTrigger 事件
        AddEventTrigger(progressBar.gameObject, EventTriggerType.PointerDown, OnProgressBarDragStart);
        AddEventTrigger(progressBar.gameObject, EventTriggerType.PointerUp, OnProgressBarDragEnd);

        // 获取 VideoPlayer 组件
        videoPlayer = videoScreen.GetComponent<VideoPlayer>();

        // 注册视频播放完成事件
        videoPlayer.loopPointReached += OnVideoFinished;

        // 注册屏幕点击事件
        AddEventTrigger(videoScreen, EventTriggerType.PointerClick, OnScreenClicked);
    }

    void AddEventTrigger(GameObject target, EventTriggerType eventType, UnityEngine.Events.UnityAction<BaseEventData> callback)
    {
        EventTrigger trigger = target.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = target.AddComponent<EventTrigger>();
        }

        EventTrigger.Entry entry = new EventTrigger.Entry { eventID = eventType };
        entry.callback.AddListener(callback);
        trigger.triggers.Add(entry);
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

        // 设置进度条的最大值和初始值
        progressBar.maxValue = (float)videoPlayer.clip.length;
        progressBar.value = 0;

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

    void OnProgressBarChanged(float value)
    {
        if (isDragging)
        {
            Debug.Log("Dragging progress bar: " + value);
            videoPlayer.time = value;
        }
    }

    void OnProgressBarDragStart(BaseEventData data)
    {
        Debug.Log("Started dragging progress bar");
        isDragging = true;
        videoPlayer.Pause();
        ShowProgressBar();
    }

    void OnProgressBarDragEnd(BaseEventData data)
    {
        Debug.Log("Stopped dragging progress bar");
        isDragging = false;
        videoPlayer.Play();
        ShowProgressBar(); // Reset the timeout for hiding the progress bar
    }

    void OnScreenClicked(BaseEventData data)
    {
        Debug.Log("Screen clicked");
        ShowProgressBar();
    }

    void ShowProgressBar()
    {
        lastInteractionTime = Time.time;
        progressBar.gameObject.SetActive(true);
    }

    void Update()
    {
        if (!isDragging && videoPlayer.isPlaying)
        {
            progressBar.value = (float)videoPlayer.time;
        }

        // 自动隐藏进度条
        if (Time.time - lastInteractionTime > interactionTimeout)
        {
            progressBar.gameObject.SetActive(false);
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("Video finished");

        // 隐藏视频屏幕和进度条
        videoScreen.SetActive(false);
        progressBar.gameObject.SetActive(false);

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
            StartCoroutine(LoadSceneCoroutine("HouseScene1"));
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
