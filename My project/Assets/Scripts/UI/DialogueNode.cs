using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class DialogueNode
{
    public string dialogueText;
    public string speakerName;
    public Sprite speakerSprite;
    public List<string> options = new List<string>();
    public List<int> nextNodeIDs = new List<int>();
    public bool isEndingChoice;
    public List<string> endingOptions = new List<string>();
    public List<int> endingNodeIDs = new List<int>();
}