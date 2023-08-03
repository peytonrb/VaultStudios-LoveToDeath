using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> conversation;
    public TMP_Text dialogueText;
    public GameObject textBoxUI;
    // public Animator animator;
    
    void Start()
    {
        conversation = new Queue<string>();
        textBoxUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        // animator.SetBool("isOpen", true);
        conversation.Clear();
        textBoxUI.SetActive(true);

        foreach (string fact in dialogue.conversation)
        {
            conversation.Enqueue(fact);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (conversation.Count == 0)
        {
            EndDialogue();
            return;
        }

        string fact = conversation.Dequeue();
        StopAllCoroutines();
        StartCoroutine(SentenceScroll(fact));
    }

    IEnumerator SentenceScroll(string fact)
    {
        dialogueText.text = "";

        foreach (char letter in fact.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        // animator.SetBool("isOpen", false);
        textBoxUI.SetActive(false);
    }
}
