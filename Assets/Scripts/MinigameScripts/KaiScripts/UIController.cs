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
        meterText.text = distance + " m";
    }
}
