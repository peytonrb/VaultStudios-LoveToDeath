using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public GameObject textBoxUI;
    public PlayerController player;
    public bool isActive;
    public bool isDead;
    public bool isLoveInterest;
    public bool isKillable;
    // public Animator animator;
    
    void Start()
    {
        isActive = false;
        sentences = new Queue<string>();
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
        nameText.text = dialogue.name;
        sentences.Clear();
        textBoxUI.SetActive(true);
        isActive = true;

        if (player.isDateTime && !isDead && isLoveInterest)
        {
            foreach (string sentence in dialogue.loveInterestDate)
            {
                sentences.Enqueue(sentence);
            }
        }

        if (player.isSocialTime && !isDead && isKillable)
        {
            foreach (string sentence in dialogue.friendDate)
            {
                sentences.Enqueue(sentence);
            }
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            isActive = false;
            return;
        }

        string fact = sentences.Dequeue();
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
