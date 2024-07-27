using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;

    [SerializeField] private GameObject dialogBox;

    [SerializeField] private TextMeshProUGUI dialog;

    [SerializeField] private TextMeshProUGUI characterName;
    
    [SerializeField] private CharacterType charaType;

    private int index;

    private bool isInTurn;

    private void Update(){
        if (isInTurn && Input.GetKeyDown(KeyCode.E)){
            Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) => isInTurn = true;

    private void OnTriggerExit2D(Collider2D other) => isInTurn = false;

    private void Play(){
        dialogBox.SetActive(true);

        DialogNode node =  dialogue.dialogNodes[Mathf.Clamp(index++, 0, dialogue.dialogNodes.Length-1)];

        dialog.text = node.dialog;

        characterName.text = node.characterName;

        if (index - 1 == dialogue.dialogNodes.Length){
            dialogBox.SetActive(false);
        }
    }

}
