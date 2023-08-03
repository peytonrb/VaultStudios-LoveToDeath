using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrilldadController : MonoBehaviour
{
    [Header("Chosen Love Interest")]
    public bool isLoveInterest;
    private PlayerListUI chosenInterest;
    public PlayerController player;
    public string[] friends = {"forestcore", "emo", "chemist"};

    [TextArea(3,10)]
    public string[] dateDialogue1;

    [TextArea(3,10)]
    public string[] dateDialogue2;

    [TextArea(3,10)]
    public string[] dateDialogue3;

    [Header("Is Killable")]
    public bool isKillable;
    public bool playerHasItems;
    public string[] requiredItems = {"gasoline", "key", "saw"};

    [TextArea(3,10)]
    public string[] friendDateDialogue;

    void Start()
    {
        playerHasItems = false;

        if (PlayerListUI.loveInterest == "grilldad")
        {
            isLoveInterest = true;
        }
        else
        {
            for (int i = 0; i < friends.Length; i++)
            {
                if (PlayerListUI.loveInterest == friends[i])
                {
                    isKillable = true;
                }
            }
        }
    }

    void Update()
    {
        // if they are love interest
        if (isLoveInterest)
        {
        }
        // if they are killable
        else if (isKillable)
        {
            // guarantees player is within range of love interest
            Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, 5f); // second number is radius
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F) && playerHasItems)
                {
                    initiateMurderGame();
                }
            } 
        }
        // if they are npc
        else
        {

        }
    }

    public void initiateMurderGame()
    {
        SceneManager.LoadScene(6);
    }
}
