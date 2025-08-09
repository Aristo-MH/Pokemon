using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDialogue : MonoBehaviour
{
    public NPC npc;

    public List<string> kata;

    bool isTalking;

    // Start is called before the first frame update
    void Start()
    {
        isTalking = false;
        npc = GetComponent<NPC>();
    }

    // Update is called once per frame
    void Update()
    {
        if(npc.isPlayerNearby == true && Input.GetKeyDown(KeyCode.E) && isTalking == false)
        {
            // dialogueManager.dialoguePanel.alpha = 1;
            DialogueManager.Instance.MemunculkanDialog(kata, npc.nama);
            isTalking = true;
        }
    }
}
