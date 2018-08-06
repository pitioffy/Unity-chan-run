using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Animator animator;
    public Animator playerAnim;
    public Text dialogueText;

    private GameObject startDialogue;
    public GameObject talkDialogue;
    private Queue<string> sentences;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
	}
	
    public void StartDialogue(Dialogue dialogue, GameObject dialogueButton, bool quitDialogue)
    {
        startDialogue = dialogueButton;
        if (quitDialogue)
        {
            playerAnim.SetBool("Sad", true);
        }
        animator.SetBool("IsOpen", true);

        talkDialogue.SetActive(false);

        sentences.Clear();

        foreach (string sentence in dialogue.dialogueSentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        else if(sentences.Count == 1) 
        {
            playerAnim.SetBool("Sad", false);
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        startDialogue.SetActive(true);
        talkDialogue.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
