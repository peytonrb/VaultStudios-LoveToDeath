using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Items : MonoBehaviour
{
    public PlayerController player;
    public Transform playerPos;
    public Rigidbody rb;
    public GameObject item;

    public static Items Instance { get; private set; }

    private void Awake()
    {
        // DontDestroyOnLoad(this);
        // if (Instance != null && Instance == this)
        // {
        //     Destroy(this);
        // }
        // else
        // {
        //     Instance = this;
        // }
    }

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        playerPos = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody>();
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

        if (SceneManager.GetActiveScene().name != "Town")
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
