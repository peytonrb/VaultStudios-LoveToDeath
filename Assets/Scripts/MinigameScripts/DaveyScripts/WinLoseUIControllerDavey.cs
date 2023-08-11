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
}
