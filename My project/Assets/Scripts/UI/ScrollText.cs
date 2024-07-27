using UnityEngine;
using UnityEngine.UI;

public class ScrollText : MonoBehaviour
{
    public ScrollRect scrollRect; // 滚动视图
    public float scrollSpeed = 20f; // 滚动速度

    void Update()
    {
        if (scrollRect.verticalNormalizedPosition > 0)
        {
            scrollRect.verticalNormalizedPosition -= scrollSpeed * Time.deltaTime;
        }
    }
}
