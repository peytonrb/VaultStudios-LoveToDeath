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
        if (nameOfTarget == "wesley" && wesley.isKillable)
        {
            wesley.initiateMurderGame();
        }
        else if (nameOfTarget == "aspen" && aspen.isKillable)
        {
            aspen.initiateMurderGame();
        }
        else if (nameOfTarget == "carmen" && carmen.isKillable)
        {
            carmen.initiateMurderGame();
        }
        else if (nameOfTarget == "davey" && davey.isKillable)
        {
            davey.initiateMurderGame();
        }
        else if (nameOfTarget == "armani" && armani.isKillable)
        {
            armani.initiateMurderGame();
        }
        else if (nameOfTarget == "kai" && kai.isKillable)
        {
            kai.initiateMurderGame();
        }
    }
}
