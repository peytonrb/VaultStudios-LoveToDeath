using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } 
    public int bodyCount;
    public string loveInterest;
    public bool isFirstInstance = true;
    public PlayerController player;
    public CharacterController controller;
    public PlayerLook playerLook;
    public Camera mainCamera;
    public AudioListener audioListener;
    public bool sceneJustLoaded;
    public GameObject winScreen;
    public GameObject winText;

    private void Awake()
    {
        // This moves the current GameManager to DontDestroyOnLoad and deletes any other GameManagers
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
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        controller = GameObject.Find("Player").GetComponent<CharacterController>();
        playerLook = GameObject.Find("Main Camera").GetComponent<PlayerLook>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        audioListener = GameObject.Find("Main Camera").GetComponent<AudioListener>();
        winScreen.SetActive(false);
        winText.SetActive(false);
    }

    void Update()
    {
        if (bodyCount == 3)
        {
            winScreen.SetActive(true);
            winText.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name != "Town")
        {
            player.enabled = false;
            controller.enabled = false;
            playerLook.enabled = false;
            mainCamera.enabled = false;
            audioListener.enabled = false;
        }
        else
        {
            player.enabled = true;
            controller.enabled = true;
            playerLook.enabled = true;
            mainCamera.enabled = true;
            audioListener.enabled = true;
        }
    }
}
