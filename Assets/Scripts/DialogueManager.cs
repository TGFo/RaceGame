using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextAsset DialogueFile;
    public NPCDialogue RaceDialogue;
    private Queue<NPC> DialogueQueue = new Queue<NPC>();

    private void Awake()
    {
        RaceDialogue = JsonUtility.FromJson<NPCDialogue>(DialogueFile.text);
        foreach (NPC npc in RaceDialogue.nonPlayerDialogue)
        {
            DialogueQueue.Enqueue(npc);
        }
    }
    public NPC GetNextDialogueItem()
    {
        return DialogueQueue.Dequeue();
    }
    public int GetDialogueCount()
    {
        return DialogueQueue.Count;
    }
}