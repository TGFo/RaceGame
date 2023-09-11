using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] TMP_Text NPCName;
    [SerializeField] TMP_Text NPCDialogue;
    [SerializeField] Image NPCPortrait;
    [SerializeField] DialogueManager dialogueManager;
    NPC currentNpc;

    private void Start()
    {
        NextDialogueLine();
    }
    public void NextDialogueLine()
    {
        if (dialogueManager.GetDialogueCount() > 0)
        {
            currentNpc = dialogueManager.GetNextDialogueItem();
            NPCName.text = currentNpc.npcName;
            NPCDialogue.text = currentNpc.npcDialogue;
            NPCPortrait.sprite = Resources.Load<Sprite>(currentNpc.portraitFileName);
        }
    }
}
