using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using System.ComponentModel;
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
    // access to other scripts
    public Cube1 cube1;
    public Cube2 cube2;
    public Cube3 cube3;
    public Cube4 cube4;
    public Cube5 cube5;
    public Cube6 cube6;
    // lives variable
    private int lives = 0;
    // points variable
    private int points = 0;

    [Header("UI")]
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject loseScreenNoTryAgain;
    public WinLoseUIControllerCarmen uiController;
    public GameManager player;
    public PlayerController pController;
    private bool hasAdded;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("GameManager").GetComponent<GameManager>();
        pController = GameObject.Find("Player").GetComponent<PlayerController>();   
        hasAdded = false;
        System.Random rng = new System.Random();
        // make sure the two numbers are not the same
        int randomWire = rng.Next(1, 7);
        int randomWire2 = rng.Next(1, 7);
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
            randomWire2 = rng.Next(1, 6);
        }

        // prints out the value of the two exploding cubes into the console
        Debug.Log(randomWire);
        Debug.Log(randomWire2);

        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        loseScreenNoTryAgain.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        // Checking to see if the player clicks on an object
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Destroys object when hit
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == wire_1)
                {
                    if (wire_1.GetComponent<Cube1>().canExplode == true)
                    {
                        lives += 1;
                        Destroy(wire_1); 
                        Debug.Log(lives);
                    }
                    else
                    {
                        points += 1;
                        Destroy(wire_1);
                    }
                }

                if (hit.transform.gameObject == wire_2)
                {
                    if (wire_2.GetComponent<Cube2>().canExplode == true)
                    {
                        lives += 1;
                        Destroy(wire_2); 
                        Debug.Log(lives);
                    }
                    else
                    {   
                        points += 1;                 
                        Destroy(wire_2);
                    }
                }

                if (hit.transform.gameObject == wire_3)
                {
                    if (wire_3.GetComponent<Cube3>().canExplode == true)
                    {
                        lives += 1;
                        Destroy(wire_3);
                        Debug.Log(lives); 
                    }
                    else
                    {       
                        points += 1;             
                        Destroy(wire_3);
                    }
                }

                if (hit.transform.gameObject == wire_4)
                {
                    if (wire_4.GetComponent<Cube4>().canExplode == true)
                    {
                        lives += 1;
                        Destroy(wire_4);
                    }
                    else
                    {
                        points += 1;                    
                        Destroy(wire_4);
                    }
                }

                if (hit.transform.gameObject == wire_5)
                {
                    if (wire_5.GetComponent<Cube5>().canExplode == true)
                    {
                        lives += 1;
                        Destroy(wire_5);
                        Debug.Log(lives); 
                    }
                    else
                    {
                        points += 1;                    
                        Destroy(wire_5);
                    }
                }

                if (hit.transform.gameObject == wire_6)
                {
                    if (wire_6.GetComponent<Cube6>().canExplode == true)
                    {
                        Debug.Log("explode");
                        lives += 1;
                        Destroy(wire_6);
                        Debug.Log(lives); 
                    }
                    else
                    {
                        points += 1;                    
                        Destroy(wire_6);
                        Debug.Log("good");
                    }
                }
            }
        }
        
        if (lives >= 2)
        {
            if (!uiController.tryAgainPressed)
            {
                loseScreen.SetActive(true);
            }
            else
            {
                loseScreenNoTryAgain.SetActive(true);
            }
        }

        if (points >= 4)
        {
            winScreen.SetActive(true);

            if (!hasAdded)
            {
                player.bodyCount++;
                GameManager.Instance.sceneJustLoaded = true;
                hasAdded = true;
                pController.isDateTime = true;
            }
        }
    }
}
