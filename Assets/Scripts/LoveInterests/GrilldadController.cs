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
    public Transform playerPos;
    public Rigidbody rb;
    public string[] friends = {"forestcore", "emo", "chemist"};

    [Header("Is Killable")]
    public bool isKillable;
    public bool isDead;
    public bool playerHasItems;
    public string[] requiredItems = {"gasoline", "key", "saw"};

    // public GameObject house;

    void Start()
    {
        isDead = false;
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
        if (Vector3.Distance(player.transform.position, transform.position) >= 20f)
        {
            rb.freezeRotation = false;
            transform.LookAt(playerPos);
        }
        else
        {
            rb.freezeRotation = true;
        }    }

    public void initiateMurderGame()
    {
        SceneManager.LoadScene(6);
    }
}
