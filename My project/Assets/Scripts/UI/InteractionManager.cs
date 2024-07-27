using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [System.Serializable]
    public class InteractionData
    {
        public GameObject panel; // 面板对象
        public ProximityTrigger proximityTrigger; // 触发器脚本
    }

    public InteractionData[] interactions; // 用于存储交互数据的数组

    public void OnInteractionButtonClick()
    {
        foreach (var interaction in interactions)
        {
            // 检查玩家是否在目标物体附近
            if (interaction.proximityTrigger.GetIsPlayerNearby())
            {
                // 如果玩家在附近则显示相应的设置对话框
                interaction.panel.SetActive(true);
                Debug.Log(interaction.panel.name + " opened!");
                return; // 一旦找到一个面板打开即可返回
            }
        }
        Debug.Log("Player is not close enough to interact!");
    }

    public void CloseAllDialogs()
    {
        foreach (var interaction in interactions)
        {
            // 关闭所有对话框
            interaction.panel.SetActive(false);
        }
        Debug.Log("All dialogs closed!");
    }
}