using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager_Aspen : MonoBehaviour
{
    public static int orderValue;
    public static int plateValue = 00000;
    public int moonseedBerries;
    public int sweetTea;
    public int mortar;
    public int nightshade;
    public int honey;

    void Awake()
    {
        System.Random rng = new System.Random();
        moonseedBerries = rng.Next(1, 5);

        int tempTea = rng.Next(1, 5);
        sweetTea = tempTea * 10;

        int tempMortar = rng.Next(1, 5);
        mortar = tempMortar * 100;

        int tempNightshade = rng.Next(1, 5);
        nightshade = tempNightshade * 1000;

        int tempHoney = rng.Next(1, 5);
        honey = tempHoney * 10000;

        orderValue = moonseedBerries + sweetTea + mortar + nightshade + honey;
        Debug.Log("order value: " + orderValue);
    }
}
