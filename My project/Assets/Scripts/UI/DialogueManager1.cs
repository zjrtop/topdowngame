using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueManager1 : MonoBehaviour
{
    public DialogueData1 dialogueData;
    public Text dialogueText;
    public Text speakerNameText;
    public Image speakerImage;
    public Button[] optionButtons;
    public GameObject endingChoicePanel;
    public Button[] endingChoiceButtons;
    public GameObject endingPanel;
    public Text endingText;
    public Image endingImage;

    private List<DialogueNode> dialogueNodes;
    private int currentNodeIndex = 0;

    void Start()
    {
        if (dialogueData != null)
        {
            dialogueNodes = dialogueData.nodes;
            ShowDialogueNode(currentNodeIndex);
        }
        else
        {
            Debug.LogError("Dialogue Data is not assigned!");
        }
    }

    void ShowDialogueNode(int nodeIndex)
    {
        if (nodeIndex < 0 || nodeIndex >= dialogueNodes.Count)
        {
            Debug.LogError("Invalid node index");
            return;
        }

        DialogueNode currentNode = dialogueNodes[nodeIndex];
        dialogueText.text = currentNode.dialogueText;
        speakerNameText.text = currentNode.speakerName;

        if (currentNode.speakerSprite != null)
        {
            speakerImage.sprite = currentNode.speakerSprite;
            speakerImage.enabled = true;
        }
        else
        {
            speakerImage.enabled = false;
        }

        if (currentNode.isEndingChoice)
        {
            ShowEndingChoice(currentNode);
        }
        else
        {
            ShowOptions(currentNode);
        }
    }

    void ShowOptions(DialogueNode node)
    {
        endingChoicePanel.SetActive(false);
        for (int i = 0; i < optionButtons.Length; i++)
        {
            if (i < node.options.Count)
            {
                optionButtons[i].gameObject.SetActive(true);
                optionButtons[i].GetComponentInChildren<Text>().text = node.options[i];
                int optionIndex = i;
                optionButtons[i].onClick.RemoveAllListeners();
                optionButtons[i].onClick.AddListener(() => OnOptionSelected(optionIndex));
            }
            else
            {
                optionButtons[i].gameObject.SetActive(false);
            }
        }
    }

    void ShowEndingChoice(DialogueNode node)
    {
        foreach (var button in optionButtons)
        {
            button.gameObject.SetActive(false);
        }
        endingChoicePanel.SetActive(true);
        for (int i = 0; i < endingChoiceButtons.Length; i++)
        {
            if (i < node.endingOptions.Count)
            {
                endingChoiceButtons[i].gameObject.SetActive(true);
                endingChoiceButtons[i].GetComponentInChildren<Text>().text = node.endingOptions[i];
                int choiceIndex = i;
                endingChoiceButtons[i].onClick.RemoveAllListeners();
                endingChoiceButtons[i].onClick.AddListener(() => OnEndingChoiceSelected(choiceIndex));
            }
            else
            {
                endingChoiceButtons[i].gameObject.SetActive(false);
            }
        }
    }

    void OnOptionSelected(int optionIndex)
    {
        int nextNodeID = dialogueNodes[currentNodeIndex].nextNodeIDs[optionIndex];
        if (nextNodeID == -1)
        {
            ShowEnding("游戏结束", null);
        }
        else
        {
            currentNodeIndex = nextNodeID;
            ShowDialogueNode(currentNodeIndex);
        }
    }

    void OnEndingChoiceSelected(int choiceIndex)
    {
        int nextNodeID = dialogueNodes[currentNodeIndex].endingNodeIDs[choiceIndex];
        if (nextNodeID == -1)
        {
            ShowEnding("游戏结束", null);
        }
        else
        {
            currentNodeIndex = nextNodeID;
            ShowDialogueNode(currentNodeIndex);
        }
    }

    public void ShowEnding(string endingText, Sprite endingImage)
    {
        endingPanel.SetActive(true);
        this.endingText.text = endingText;
        if (endingImage != null)
        {
            this.endingImage.sprite = endingImage;
            this.endingImage.enabled = true;
        }
        else
        {
            this.endingImage.enabled = false;
        }
    }
}