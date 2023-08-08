using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI meterText;

    void Update()
    {
        int distance = Mathf.FloorToInt(player.distance);

        if (distance == 1000)
        {
            player.hasWon = true;   // trigger ui here
        }

        meterText.text = distance + " m";
    }
}
