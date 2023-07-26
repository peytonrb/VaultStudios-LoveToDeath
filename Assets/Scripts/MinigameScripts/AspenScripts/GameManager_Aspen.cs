using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager_Aspen : MonoBehaviour
{
    public static int orderValue;
    public static int plateValue = 00000;
    private int moonseedBerries;
    private int sweetTea;
    private int mortar;
    private int nightshade;
    private int honey;

    void Awake()
    {
        System.Random rng = new System.Random();
        moonseedBerries = rng.Next(1, 3);

        int tempTea = rng.Next(1, 3);
        sweetTea = tempTea * 10;

        int tempMortar = rng.Next(1, 3);
        mortar = tempMortar * 100;

        int tempNightshade = rng.Next(1, 3);
        nightshade = tempNightshade * 1000;

        int tempHoney = rng.Next(1, 3);
        honey = tempHoney * 10000;

        orderValue = moonseedBerries + sweetTea + mortar + nightshade + honey;
        Debug.Log(orderValue);
    }
}
