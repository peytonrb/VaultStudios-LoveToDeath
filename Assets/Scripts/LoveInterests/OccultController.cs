using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccultController : MonoBehaviour
{
    [Header("Chosen Love Interest")]
    public bool isLoveInterest;
    private PlayerListUI chosenInterest;

    void Start()
    {
        if (PlayerListUI.loveInterest == "occult")
        {
            isLoveInterest = true;
        }
    }

    void Update()
    {
        if (isLoveInterest)
        {

        }
        else
        {

        } 
    }
}
