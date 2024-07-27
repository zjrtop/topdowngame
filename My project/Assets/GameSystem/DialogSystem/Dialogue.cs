using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogNode")]

public class Dialogue : ScriptableObject
{
    // Start is called before the first frame update
    public DialogNode[] dialogNodes;
}
