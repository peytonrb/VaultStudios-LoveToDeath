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
        player = GameObject.Find("Player").GetComponent<PlayerController>();
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

        if (player.isDateTime && player.dateCount == 0)
        {
            Debug.Log("entered if statement for date 1");
            foreach (string sentence in dialogue.loveInterestDate1)
            {
                sentences.Enqueue(sentence);
            }
        }

        if (player.isDateTime && player.dateCount == 1)
        {
            Debug.Log("entered if statement for date 2");
            foreach (string sentence in dialogue.loveInterestDate2)
            {
                sentences.Enqueue(sentence);
            }
        }

        if (player.isDateTime && player.dateCount == 2)
        {
            Debug.Log("entered if statement for date 3");
            foreach (string sentence in dialogue.loveInterestDate3)
            {
                sentences.Enqueue(sentence);
            }
        }

        // will only occur once
        if (player.isSocialTime)
        {
            Debug.Log("entered if statement for friend");
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
            player.setEverythingInactive();
            player.transform.position = player.startPosition;
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
