using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseUIControllerWesley : MonoBehaviour
{
    public bool tryAgainPressed;
    public GameObject tryAgainButton;
    public AnothaPlayerController player;
    private bool win;

    void Start()
    {
        tryAgainPressed = false;
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (tryAgainPressed)
        {
            tryAgainButton.SetActive(false);
        }
        else if (tryAgainButton == null)
        {
            Debug.Log("Button Deleted");
        }
    }

    public void tryAgain()
    {
        if (!tryAgainPressed)
        {
            tryAgainPressed = true;
            SceneManager.LoadScene(3);
        }
    }

    public void backToTown()
    {
        SceneManager.LoadScene(2);
    }
}
