using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue Data 1")]
public class DialogueData1 : ScriptableObject
{
    public List<DialogueNode> nodes = new List<DialogueNode>();
}