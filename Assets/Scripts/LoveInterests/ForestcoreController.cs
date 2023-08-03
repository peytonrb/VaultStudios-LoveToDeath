using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForestcoreController : MonoBehaviour
{
    [Header("Chosen Love Interest")]
    public bool isLoveInterest;
    private PlayerListUI chosenInterest;
    public PlayerController player;
    public string[] friends = {"chemist", "jojo", "gamer"};

    [Header("Is Killable")]
    public bool isKillable;
    public bool isDead;
    public bool playerHasItems;
    public string[] requiredItems = {"berries", "tea", "mortar"};

    void Start()
    {
        isDead = false;
        playerHasItems = false;

        if (PlayerListUI.loveInterest == "forestcore")
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
        SceneManager.LoadScene(4);
    }
}
