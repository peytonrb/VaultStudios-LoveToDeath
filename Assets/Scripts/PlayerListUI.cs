using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerListUI : MonoBehaviour
{
    public Button[] playerList;
    public GameObject[] playerCards;
    public Button back;
    public Button start;
    public static string loveInterest;
    public GameObject forestcoreObj;
    public GameObject grilldadObj;
    public GameObject chemistObj;
    public GameObject gamerObj;
    public GameObject jojoObj;
    public GameObject occultObj;
    public GameObject buttonBackground;

    //hi peyton (^人^) <- WHO DID THIS THIS IS SO CUTE

    void Start()
    {
        back.gameObject.SetActive(false);
        start.gameObject.SetActive(false);
        forestcoreObj.SetActive(false);
        grilldadObj.SetActive(false);
        chemistObj.SetActive(false);
        gamerObj.SetActive(false);
        jojoObj.SetActive(false);
        occultObj.SetActive(false);
        buttonBackground.SetActive(true);

        for (int i = 0; i < playerCards.Length; i++)
        {
            playerCards[i].SetActive(false);
        }
    }

    public void forestcore()
    {
        removeButtons();
        enablePlayerCards("Aspen");
        forestcoreObj.SetActive(true);
        loveInterest = "forestcore";
    }

    public void grillDad()
    {
        removeButtons();
        enablePlayerCards("Davey");
        grilldadObj.SetActive(true);
        loveInterest = "grilldad";
    }

    // public void emo()
    // {
    //     removeButtons();
    //     enablePlayerCards("EMO");
    //     loveInterest = "emo";
    // }

    public void chemist()
    {
        removeButtons();
        enablePlayerCards("Wesley");
        chemistObj.SetActive(true);
        loveInterest = "chemist";
    }

    public void gamerFemme()
    {
        removeButtons();
        enablePlayerCards("Carmen");
        gamerObj.SetActive(true);
        loveInterest = "gamer";
    }

    // public void surfer()
    // {
    //     removeButtons();
    //     enablePlayerCards("SURFER");
    //     loveInterest = "surfer";
    // }

    public void jojo()
    {
        removeButtons();
        enablePlayerCards("Armani");
        jojoObj.SetActive(true);
        loveInterest = "jojo";
    }

    public void occult()
    {
        removeButtons();
        enablePlayerCards("Kai");
        occultObj.SetActive(true);
        loveInterest = "occult";
    }

    // sets the selected player card active in the scene
    private void enablePlayerCards(string name)
    {
        start.gameObject.SetActive(true);
    }

    // deactivates all other playercards on click
    private void removeButtons()
    {
        back.gameObject.SetActive(true);
        buttonBackground.SetActive(false);

        for (int i = 0; i < playerList.Length; i++)
        {
            playerList[i].gameObject.SetActive(false);
        }
    }

    // brings all buttons back to screen
    public void backButton()
    {
        for (int i = 0; i < playerList.Length; i++)
        {
            playerList[i].gameObject.SetActive(true);
        }

        disableAllCharacters();
        back.gameObject.SetActive(false);
        buttonBackground.SetActive(true);
    }

    public void disableAllCharacters()
    {
        forestcoreObj.SetActive(false);
        grilldadObj.SetActive(false);
        chemistObj.SetActive(false);
        gamerObj.SetActive(false);
        jojoObj.SetActive(false);
        occultObj.SetActive(false);
    }

    public void startButton()
    {
        SceneManager.LoadScene(2);
    }
}
