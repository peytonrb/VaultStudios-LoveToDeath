using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestcoreController : MonoBehaviour
{
    [Header("Chosen Love Interest")]
    public bool isLoveInterest;
    private PlayerListUI chosenInterest;

    [Header("Is Killable")]
    public bool isKillable;
    private string[] friends = {"name", "name", "name"};

    void Start()
    {
        if (PlayerListUI.loveInterest == "forestcore")
        {
            isLoveInterest = true;
        }
        else
        {
            for (int i = 0; i < friends.Length; i++)
            {
                if (PlayerListUI.loveInterest == friends[i])
                {
                    isKillable = true;
                }
            }
        }
    }

    void Update()
    {
        // if they are love interest
        if (isLoveInterest)
        {

        }
        // if they are killable
        else if (isKillable)
        {
            
        }
        // if they are npc
        else
        {

        }
    }
}
