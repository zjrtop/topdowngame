using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;      // 人物名称的文本组件
    public TMP_Text dialogueText;  // 对话内容的文本组件
    public Image portraitImage;    // 人物头像的图像组件
    public Button nextButton;      // 推进对话的按钮

    public DialogueData[] dialogues; // 存储对话内容的数组

    private int currentDialogueIndex = 0; // 当前对话的索引

    public bool isDialogueCompleted { get; private set; } = false; // 记录对话是否完成

    void Start()
    {
        if (dialogues.Length > 0)
        {
            DisplayDialogue(currentDialogueIndex);
        }

        nextButton.onClick.AddListener(OnNextButtonClick);
    }

    private void DisplayDialogue(int index)
    {
        if (index < dialogues.Length)
        {
            nameText.text = dialogues[index].name;
            dialogueText.text = dialogues[index].dialogue;
            portraitImage.sprite = dialogues[index].portrait;
        }
    }

    public void OnNextButtonClick()
    {
        currentDialogueIndex++;
        if (currentDialogueIndex < dialogues.Length)
        {
            DisplayDialogue(currentDialogueIndex);
        }
        else
        {
            // 对话结束，执行关闭对话框的逻辑
            Debug.Log("End of dialogue");
            //transform.parent.gameObject.SetActive(false); // 关闭对话框
            transform.gameObject.SetActive(false); 
            isDialogueCompleted = true; // 标记对话完成
        }
    }
}