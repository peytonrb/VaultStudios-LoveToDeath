using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamerController : MonoBehaviour
{
    [Header("Chosen Love Interest")]
    public bool isLoveInterest;
    private PlayerListUI chosenInterest;
    public PlayerController player;

    [Header("Is Killable")]
    public bool isKillable;
    private string[] friends = {"forestcore", "emo", "jojo"};
    public string[] requiredItems = {};

    void Start()
    {
        if (PlayerListUI.loveInterest == "gamer")
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
            // guarantees player is within range of love interest
            Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, 5f); // second number is radius
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F) && player.hasMurderItems)
                {
                    initiateMurderGame();
                }
            }
        }
        // if they are killable
        else if (isKillable)
        {
            
        }
        // if they are npc
        else
        {

        }
    }

    private void initiateMurderGame()
    {
        SceneManager.LoadScene(5);
    }   
}
