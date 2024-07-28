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
        public bool requiresDialogueCompletion;  // 需要完成对话
    }

    public InteractionData[] interactions; // 用于存储交互数据的数组
    public DialogueManager npcADialogueManager; // 引用 NPC A 的 DialogueManager

    public void OnInteractionButtonClick()
    {
        foreach (var interaction in interactions)
        {
            // 检查玩家是否在目标物体附近
            Debug.Log($"Checking if player is near: {interaction.panel.name}");
            if (interaction.proximityTrigger.GetIsPlayerNearby())
            {
                // Debug 日志，检查是否需要完成对话
                Debug.Log($"Checking interaction with panel: {interaction.panel.name}");
                
                if (interaction.requiresDialogueCompletion && !npcADialogueManager.isDialogueCompleted)
                {
                    Debug.Log("Dialogue with NPC A is not completed yet!");
                    return;
                }

                // 如果玩家在附近且对话完成，显示相应的设置对话框
                Debug.Log($"Opening panel: {interaction.panel.name}");
                interaction.panel.SetActive(true);
                StartCoroutine(VerifyPanelActive(interaction.panel)); // 验证面板在下一帧是否仍为激活状态
                return; // 一旦找到一个面板打开即可返回
            }
        }
        Debug.Log("Player is not close enough to interact!");
    }

    private IEnumerator VerifyPanelActive(GameObject panel)
    {
        yield return null; // 等待一帧
        Debug.Log($"Panel {panel.name} active status: {panel.activeSelf}");
    }

    public void CloseAllDialogs()
    {
        foreach (var interaction in interactions)
        {
            // 关闭所有对话框
            Debug.Log($"Closing panel: {interaction.panel.name}");
            interaction.panel.SetActive(false);
        }
        Debug.Log("All dialogs closed!");
    }
}