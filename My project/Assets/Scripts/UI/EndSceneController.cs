using UnityEngine;
using UnityEngine.Video;

public class EndSceneController : MonoBehaviour
{
    private VideoPlayer videoPlayer; // 视频播放器组件

    void Start()
    {
        // 获取 VideoPlayer 组件
        videoPlayer = GetComponent<VideoPlayer>();

        // 注册视频播放完成事件
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoFinished;
            // 开始播放视频
            videoPlayer.Play();
        }
        else
        {
            Debug.LogError("VideoPlayer component not found on the GameObject.");
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // 退出游戏
        Application.Quit();

        // 如果在编辑器中运行，使用以下代码退出播放模式
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
