using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JojoController : MonoBehaviour
{
    [Header("Chosen Love Interest")]
    public bool isLoveInterest;
    private PlayerListUI chosenInterest;
    public PlayerController player;
    public Rigidbody rb;
    public string[] friends = { "grilldad", "chemist", "gamer" };
    public Transform playerPos;

    [Header("Is Killable")]
    public bool isKillable;
    public bool isDead;
    public bool playerHasItems;
    public string[] requiredItems = { "fishing line", "toolbox", "crowbar" };

    // public GameObject house;
    public static JojoController Instance { get; private set; } 

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

        if (PlayerListUI.loveInterest == "jojo")
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
        SceneManager.LoadScene(7);
        player.isDateTime = true;
    }
}
