using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerListUI : MonoBehaviour
{
    public Button[] playerList;
    public GameObject[] playerCards;
    public Button back;
    public Button start;

    void Start()
    {
        back.gameObject.SetActive(false);
        start.gameObject.SetActive(false);

        for (int i = 0; i < playerCards.Length; i++)
        {
            playerCards[i].SetActive(false);
        }
    }

    public void forestcore()
    {
        removeButtons();
        enablePlayerCards("FORESTCORE");
        GameManager.Instance.loveInterestName = "forestcore";
    }
    public void grillDad()
    {
        removeButtons();
        enablePlayerCards("GRILLDAD");
        GameManager.Instance.loveInterestName = "grilldad";
    }

    public void emo()
    {
        removeButtons();
        enablePlayerCards("EMO");
        GameManager.Instance.loveInterestName = "emo";
    }

    public void chemist()
    {
        removeButtons();
        enablePlayerCards("CHEMIST");
        GameManager.Instance.loveInterestName = "chemist";
    }

    public void gamerFemme()
    {
        removeButtons();
        enablePlayerCards("GAMER FEMME");
        GameManager.Instance.loveInterestName = "gamer";
    }

    public void surfer()
    {
        removeButtons();
        enablePlayerCards("SURFER");
        GameManager.Instance.loveInterestName = "surfer";
    }

    public void jojo()
    {
        removeButtons();
        enablePlayerCards("JOJO");
        GameManager.Instance.loveInterestName = "jojo";
    }

    public void occultGirl()
    {
        removeButtons();
        enablePlayerCards("OCCULT GIRL");
        GameManager.Instance.loveInterestName = "occult";
    }

    // sets the selected player card active in the scene
    private void enablePlayerCards(string characterName)
    {
        for (int i = 0; i < playerCards.Length; i++)
        {
            if (characterName == playerCards[i].name)
            {
                playerCards[i].SetActive(true);
            }
        }   

        start.gameObject.SetActive(true);
    }

    // deactivates all other playercards on click
    private void removeButtons()
    {
        back.gameObject.SetActive(true);

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

        back.gameObject.SetActive(false);
    }

    public void startButton()
    {
        SceneManager.LoadScene(2);
    }
}
