using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInteractionManager : MonoBehaviour
{
    [System.Serializable]
    public class InteractionData
    {
        public GameObject panel; // 面板对象
        public ProximityTrigger proximityTrigger; // 触发器脚本
    }

    public InteractionData interaction; // 用于存储交互数据
    public InfoPanelManager infoPanelManager; // 引用 InfoPanelManager

    public void OnInteractionButtonClick()
    {
        // 检查玩家是否在目标物体附近
        if (interaction.proximityTrigger.GetIsPlayerNearby())
        {
            Debug.Log("Player is near the interaction panel.");
            // 显示信息框
            infoPanelManager.ShowInfo();
        }
        else
        {
            Debug.Log("Player is not close enough to interact!");
        }
    }
}