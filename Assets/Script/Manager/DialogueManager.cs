using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public CanvasGroup dialoguePanel;

    public List<string> kataKata;

    public TMP_Text kalimat;

    public TMP_Text nama;

    public int index;

    public bool isTalking;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isTalking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isTalking == true)
        {
            index++;
            Debug.Log(index);
            if(index >= kataKata.Count)
            {
                dialoguePanel.alpha = 0;
                index = 0;
                isTalking = false;
            } 
            else
            {
                NextDialogue();
            }
        }
        // if(Input.GetKeyDown(KeyCode.R))
        // {
        //     dialoguePanel.alpha = 0;
        // }
    }

    public void MemunculkanDialog(List<string> kata, string name)
    {
        isTalking = true;
        index = 0;
        dialoguePanel.alpha = 1;
        kataKata = kata;
        NextDialogue();
        nama.text = name;
    }

    void NextDialogue()
    {
        kalimat.text = kataKata[index];
    }
}
