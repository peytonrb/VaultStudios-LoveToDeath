using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MinigameMenuUI : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public ChemistController wesley;
    public ForestcoreController aspen;
    public GamerController carmen;
    public GrilldadController davey;
    public JojoController armani;
    public OccultController kai;
    public string nameOfTarget; // establish this depending on whos house you show up to
    public GameObject menu;

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
        Debug.Log("entered");
        if (nameOfTarget == "wesley")
        {
            wesley.initiateMurderGame();
        }
        else if (nameOfTarget == "aspen")
        {
            aspen.initiateMurderGame();
        }
        else if (nameOfTarget == "carmen")
        {
            carmen.initiateMurderGame();
        }
        else if (nameOfTarget == "davey")
        {
            davey.initiateMurderGame();
        }
        else if (nameOfTarget == "armani")
        {
            armani.initiateMurderGame();
        }
        else if (nameOfTarget == "kai")
        {
            kai.initiateMurderGame();
        }
    }

    public void backButton()
    {
        menu.SetActive(false);
    }
}
