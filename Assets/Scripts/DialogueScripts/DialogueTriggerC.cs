using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerC : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager manager;
    public bool isDead;
    public bool isLoveInterest;
    public bool isKillable;
    public ChemistController controller;
    // public GameObject trigger;

    void Start()
    {
        controller = gameObject.GetComponent<ChemistController>();
        manager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        isDead = controller.isDead;
        isLoveInterest = controller.isLoveInterest;
        isKillable = controller.isKillable;
    }

    public void dialogueStart() // attach to button?
    {
        manager.isDead = isDead;
        manager.isLoveInterest = isLoveInterest;
        manager.isKillable = isKillable;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        // trigger.GetComponent<Collider>().enabled = false;
    }
}
