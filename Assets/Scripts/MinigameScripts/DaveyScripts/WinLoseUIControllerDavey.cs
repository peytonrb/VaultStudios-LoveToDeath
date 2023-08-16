using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseUIControllerDavey : MonoBehaviour
{
    public bool tryAgainPressed = false;
    public bool again = false;
    [SerializeField]
    private GameObject tryAgainButton;
    [SerializeField]
    private MinigamePlayerController player;
    private WinLoseUIControllerDavey uiController;
    private bool win;
    public GameObject mainMenu;
    public GameObject title;
    public GameObject button1;
    public GameObject button2;
    public GameObject instructions;
    public Timer timer;

    void Awake()
    {
        instructions.SetActive(false);
    }

    void Start()
    {
        uiController = GameObject.Find("WinLoseUIControllerDavey").GetComponent<WinLoseUIControllerDavey>();

        if (uiController.tryAgainButton == null)
        {
            Destroy(uiController.gameObject);
            tryAgainPressed = true;
        }

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (tryAgainButton == null)
        {
            return;
        }
        else if (tryAgainPressed)
        {
            tryAgainButton.SetActive(false);
        }
    }

    public void tryAgain()
    {
        tryAgainPressed = true;
        again = true;
        SceneManager.LoadScene(6);
    }

    public void backToTown()
    {
        SceneManager.LoadScene(2);
    }

    public void instructionsButton()
    {
        title.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);
        instructions.SetActive(true);
    }

    public void startGame()
    {
        mainMenu.SetActive(false);
        timer.gameStarted = true;
    }
}
