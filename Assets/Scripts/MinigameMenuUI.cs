using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MinigameMenuUI : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    [SerializeField]
    private string nameOfTarget; 

    void Start()
    {
        nameOfTarget = PlayerPrefs.GetString("currentTarget");
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        if (nameOfTarget == "wesley")
        {
            titleText.text = "Mixed Drinks"; // change to unique ones
            descriptionText.text = "Use WASD to collect chemicals in Wesley's hidden lab. Collect enough poisonous ones to kill.";
        }
        else if (nameOfTarget == "aspen")
        {
            titleText.text = "Special Blend";
            descriptionText.text = "Click on the ingredients to make a potion. Combine the right ingredients to create a deadly concoction.";
        }
        else if (nameOfTarget == "carmen")
        {
            titleText.text = "Going Live";
            descriptionText.text = "Click on the live wires. If you snap the correct wires, Carmen's circuits may explode. Proceed with caution.";
        }
        else if (nameOfTarget == "davey")
        {
            titleText.text = "Full Throttle";
            descriptionText.text = "Use WASD to navigate through the inside of a car in Davey's shop." + 
                                    " Reach the broken pipe before the gasoline fumes knock you out and you may find the key to your success.";
        }
        else if (nameOfTarget == "armani")
        {
            titleText.text = "Sunk Cost";
            descriptionText.text = "Use WASD to dodge Armani's security system. Don't get caught.";
        }
        else if (nameOfTarget == "kai")
        {
            titleText.text = "See You in Hell";
            descriptionText.text = "Visit the Underworld and bring one of Kai's demons to life. Use SPACE to escape from purgatory before you get lost in it.";
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
