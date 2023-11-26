using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] TMP_Text NPCName;
    [SerializeField] TMP_Text NPCDialogue;
    [SerializeField] Image NPCPortrait;
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] string nextScene;
    NPC currentNpc;

    private void Start()
    {
        NextDialogueLine();
        SFXManager.instance.PlaySound("cheer1");
    }
    public void NextDialogueLine()
    {
        if (dialogueManager.GetDialogueCount() > 0)
        {
            currentNpc = dialogueManager.GetNextDialogueItem();
            NPCName.text = currentNpc.npcName;
            NPCDialogue.text = currentNpc.npcDialogue;
            NPCPortrait.sprite = Resources.Load<Sprite>(currentNpc.portraitFileName);
            SFXManager.instance.PlaySound("Blip1");
        }else SceneManager.LoadScene(nextScene);
    }
}
