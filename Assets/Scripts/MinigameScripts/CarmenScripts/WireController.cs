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
        // change end of range when the number of wires changes
        // make sure the two numbers are not the same
        int randomWire = rng.Next(1,3);
        int randomWire2 = rng.Next(1,3);
        // if statements
        // || means or
        if (randomWire == 1 || randomWire2 == 1)
        {
            //cube1.canExplode = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
