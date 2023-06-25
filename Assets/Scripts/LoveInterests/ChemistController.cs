using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemistController : MonoBehaviour
{
    [Header("Chosen Love Interest")]
    public bool isLoveInterest;
    private PlayerListUI chosenInterest;

    void Start()
    {
        if (PlayerListUI.loveInterest == "chemist")
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
