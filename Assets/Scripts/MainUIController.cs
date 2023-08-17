using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIController : MonoBehaviour
{
    public GameObject pauseMenu;

    public void mainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void backToTown()
    {
        pauseMenu.SetActive(false);
    }
}
