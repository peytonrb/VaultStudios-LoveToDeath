using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseUIControllerAspen : MonoBehaviour
{
    public bool tryAgainPressed = false;
    public bool again = false;
    [SerializeField]
    private GameObject tryAgainButton;
    [SerializeField]
    private MinigamePlayerController player;
    private WinLoseUIControllerAspen uiController;
    private bool win;

    void Start()
    {
        uiController = GameObject.Find("WinLoseUIControllerAspen").GetComponent<WinLoseUIControllerAspen>();

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
        SceneManager.LoadScene(4);
    }

    public void backToTown()
    {
        SceneManager.LoadScene(2);
    }
}
