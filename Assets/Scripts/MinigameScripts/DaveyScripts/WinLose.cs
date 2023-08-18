using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    public Timer timer;
    public bool hasItem;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject loseScreenNoTryAgain;
    public WinLoseUIControllerDavey uiController;
    public bool hasAdded;

    void Start()
    {
        winScreen.SetActive(false);
        loseScreenNoTryAgain.SetActive(false);
        loseScreen.SetActive(false);
        hasAdded = false;
    }

    void Update()
    {
        if (hasItem)
        {
            winScreen.SetActive(true);

            if (!hasAdded)
            {
                player.bodyCount++;
                GameManager.Instance.sceneJustLoaded = true;
                hasAdded = true;
                pController.isDateTime = true;
            }
        }
        else if (timer.levelFinished && !hasItem)
        {
            if (!uiController.tryAgainPressed)
            {
                loseScreen.SetActive(true);
            }
            else
            {
                loseScreenNoTryAgain.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "KeyItem")
        {
            Destroy(collision.gameObject);
            hasItem = true;
        }
    }
}
