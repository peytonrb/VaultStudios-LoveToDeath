using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseUIControllerKai : MonoBehaviour
{
    public bool tryAgainPressed = false;
    [SerializeField]
    private GameObject tryAgainButton;
    [SerializeField]
    private Player player;
    private WinLoseUIControllerKai uiController;
    private bool win;

    void Start()
    {
        uiController = GameObject.Find("WinLoseUIControllerKai").GetComponent<WinLoseUIControllerKai>();

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
        SceneManager.LoadScene(8);
    }

    public void backToTown()
    {
        SceneManager.LoadScene(2);
    }
}
