using UnityEngine;
using UnityEngine.SceneManagement; // 需要这个命名空间来访问场景管理功能

public class SceneTransitionTrigger : MonoBehaviour
{
    public string sceneToLoad; // 要切换到的场景名称

    void OnTriggerEnter2D(Collider2D other)
    {
        // 检查进入触发器区域的对象是否是玩家（基于标签）
        if (other.CompareTag("humanbody"))
        {
            // 切换到指定场景
            SceneManager.LoadScene(sceneToLoad);
        }
    }  
}