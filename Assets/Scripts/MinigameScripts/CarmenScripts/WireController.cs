using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
// Written by lace

public class WireController : MonoBehaviour
{
    // variables of the wires
    public GameObject wire_1;
    public GameObject wire_2;
    public GameObject wire_3;
    public GameObject wire_4;
    public GameObject wire_5;
    public GameObject wire_6;
    // variables for 
    public Cube1 cube1;
    public Cube2 cube2;
    public Cube3 cube3;
    public Cube4 cube4;
    public Cube5 cube5;
    public Cube6 cube6;

    // Start is called before the first frame update
    void Start()
    {
        System.Random rng = new System.Random();
        // make sure the two numbers are not the same
        int randomWire = rng.Next(1,7);
        int randomWire2 = rng.Next(1,7);
        // if statements use the random numbers and correlate them to their
        // respective cube, and turn their boolean variable, "canExplode"
        // to true
        // || means or
        if (randomWire == 1 || randomWire2 == 1)
        {
            cube1.canExplode = true;
        }

        if (randomWire == 2 || randomWire2 == 2)
        {
            cube2.canExplode = true;
        }

        if (randomWire == 3 || randomWire2 == 3)
        {
            cube3.canExplode = true;
        }

        if (randomWire == 4 || randomWire2 == 4)
        {
            cube4.canExplode = true;
        }

        if (randomWire == 5 || randomWire2 == 5)
        {
            cube5.canExplode = true;
        }

        if (randomWire == 6 || randomWire2 == 6)
        {
            cube6.canExplode = true;
        }

        // trying out a while loop to see if itll keep changing the value
        // until its different from the first pick

        // it worked well, i will continue to keep this as the safety net
        while (randomWire == randomWire2)
        {
            randomWire2 = rng.Next(1,6);
        }

        // prints out the value of the two exploding cubes into the console
        Debug.Log(randomWire);
        Debug.Log(randomWire2);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}