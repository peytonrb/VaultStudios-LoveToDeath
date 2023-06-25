using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestcoreController : MonoBehaviour
{
    [Header("Chosen Love Interest")]
    public bool isLoveInterest;
    private PlayerListUI chosenInterest;

    void Start()
    {
        if (PlayerListUI.loveInterest == "forestcore")
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
