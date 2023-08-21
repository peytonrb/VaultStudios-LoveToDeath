using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateBackgroundController : MonoBehaviour
{
    public string loveInterest;
    public PlayerController player;
    public Sprite[] images;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (player.dateCount == 1)
        {
            gameObject.GetComponent<Image>().sprite = images[0];
        }
        else if (player.dateCount == 2)
        {
            gameObject.GetComponent<Image>().sprite = images[1];
        }
        else if (player.dateCount == 3)
        {
            gameObject.GetComponent<Image>().sprite = images[2];
        }
    }
}
