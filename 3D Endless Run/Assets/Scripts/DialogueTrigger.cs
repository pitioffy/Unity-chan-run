using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;
    public bool hideButton;
    public bool quit;

    public void TriggerDialogue()
    {
        if (hideButton)
        {
            gameObject.SetActive(false);
        }
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, gameObject, quit);
    }
}

