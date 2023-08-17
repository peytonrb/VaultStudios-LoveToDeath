using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MinigameMenuUI : MonoBehaviour
{
    public TextMeshProUGUI titleText;

    [SerializeField]
    private string nameOfTarget; 

    void Start()
    {
        nameOfTarget = PlayerPrefs.GetString("currentTarget");
    }

    void Update()
    {
        if (nameOfTarget == "wesley")
        {
            titleText.text = "Wesley Minigame"; // change to unique ones
        }
        else if (nameOfTarget == "aspen")
        {
            titleText.text = "Special Blend";
        }
        else if (nameOfTarget == "carmen")
        {
            titleText.text = "Going Live";
        }
        else if (nameOfTarget == "davey")
        {
            titleText.text = "Full Throttle";
        }
        else if (nameOfTarget == "armani")
        {
            titleText.text = "Sunk Cost";
        }
        else if (nameOfTarget == "kai")
        {
            titleText.text = "See You in Hell";
        }
    }

    public void startMinigame()
    {
        if (nameOfTarget == "wesley")
        {
            SceneManager.LoadScene(3);
        }
        else if (nameOfTarget == "aspen")
        {
            SceneManager.LoadScene(4);
        }
        else if (nameOfTarget == "carmen")
        {
            SceneManager.LoadScene(5);
        }
        else if (nameOfTarget == "davey")
        {
            SceneManager.LoadScene(6);
        }
        else if (nameOfTarget == "armani")
        {
            SceneManager.LoadScene(7);
        }
        else if (nameOfTarget == "kai")
        {
            SceneManager.LoadScene(8);
        }
    }

    public void backButton()
    {
        SceneManager.LoadScene(2);
    }
}
