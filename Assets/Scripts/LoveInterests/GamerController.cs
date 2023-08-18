using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamerController : MonoBehaviour
{
    [Header("Chosen Love Interest")]
    public bool isLoveInterest;
    private PlayerListUI chosenInterest;
    public string[] friends = { "forestcore", "emo", "jojo" };
    public PlayerController player;
    public Rigidbody rb;
    public Transform playerPos;

    [Header("Is Killable")]
    public bool isKillable;
    public bool isDead;
    public bool playerHasItems;
    public string[] requiredItems = { "wire cutter", "screwdriver", "gloves" };

    // public GameObject house;
    public static GamerController Instance { get; private set; } 

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        isDead = false;
        playerHasItems = false;

        player = GameObject.Find("Player").GetComponent<PlayerController>();
        playerPos = GameObject.Find("Player").transform;

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
        if (Vector3.Distance(player.transform.position, transform.position) >= 20f)
        {
            rb.freezeRotation = false;
            transform.LookAt(playerPos);
        }
        else
        {
            rb.freezeRotation = true;
        }

        if (player == null)
        {
            player = GameObject.Find("Player").GetComponent<PlayerController>();
            playerPos = GameObject.Find("Player").transform;
        }
    }

    public void initiateMurderGame()
    {
        SceneManager.LoadScene(5);
        player.isDateTime = true;
    }
}
