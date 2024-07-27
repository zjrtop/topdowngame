using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType{
    NPC,
    Player
}

[Serializable]
public class DialogNode : MonoBehaviour
{
    public CharacterType type;

    public string characterName;

    public string dialog;

}
