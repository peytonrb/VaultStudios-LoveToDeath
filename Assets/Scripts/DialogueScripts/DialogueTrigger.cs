using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    // public GameObject trigger;

    public void OnTriggerExit(Collider collider) // on mouse down?
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        // trigger.GetComponent<Collider>().enabled = false;
    }
}
