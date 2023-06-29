using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Basic Movement")]
    public CharacterController controller;
    public float speed;
    public float gravity = -9.81f;
    public float jumpHeight;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private Vector3 velocity;
    private bool isGrounded;

    [Header("Love Interest")]
    private GameObject loveInterest; // stores the GameObject of the love interest
    private PlayerListUI chosenInterest;
    private string interestName;
    public ChemistController chemist;
    public ForestcoreController forestcore;
    public GamerController gamer;
    public GrilldadController grilldad;
    public JojoController jojo;
    public OccultController occult;

    [Header("Murder")]
    public bool hasMurderItems;
    private string[] targets;
    private string[] murderItems1;
    private string[] murderItems2;
    private string[] murderItems3;

    [Header("Other")]
    public GameObject inventory;
    public InventoryManager inventoryManager;

    void Start()
    {
        inventory.SetActive(false);
        hasMurderItems = false;
        interestName = PlayerListUI.loveInterest;
        loveInterest = GameObject.Find(interestName);
    }

    void Update()
    {
        // movement mechanics
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        /**********************************************************
        *               DO WE NEED A JUMP FUNCTION?               *
        **********************************************************/
        // if (Input.GetButtonDown("Jump") && isGrounded)
        // {
        //     velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 
        // }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        // end movement mechanics

        // key presses
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventory.SetActive(true);
            inventoryManager.listItems();
        }

        if (inventory.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            inventory.SetActive(false);
        }
        // end key presses

        assignMurders(interestName);
    }

    private void assignMurders(string interestName)
    {
        int iteration = 0;

        if (interestName == "forestcore")
        {
            // assigning the names to the variable local to this script
            for (int i = 0; i < targets.Length; i++)
            {
                forestcore.friends[i] = targets[i];
            }

            // assigning the items to the variable local to this script
            foreach (string name in targets)
            {
                iteration++;
                assignMurderItems(name, iteration);
            }
        } else if (interestName == "grilldad")
        {
            // assigning the names to the variable local to this script
            for (int i = 0; i < targets.Length; i++)
            {
                grilldad.friends[i] = targets[i];
            }

            // assigning the items to the variable local to this script
            foreach (string name in targets)
            {
                iteration++;
                assignMurderItems(name, iteration);
            }
        } else if (interestName == "chemist")
        {
            // assigning the names to the variable local to this script
            for (int i = 0; i < targets.Length; i++)
            {
                chemist.friends[i] = targets[i];
            }

            // assigning the items to the variable local to this script
            foreach (string name in targets)
            {
                iteration++;
                assignMurderItems(name, iteration);
            }
        } else if (interestName == "gamer")
        {
            // assigning the names to the variable local to this script
            for (int i = 0; i < targets.Length; i++)
            {
                gamer.friends[i] = targets[i];
            }

            // assigning the items to the variable local to this script
            foreach (string name in targets)
            {
                iteration++;
                assignMurderItems(name, iteration);
            }
        } else if (interestName == "occult")
        {
            // assigning the names to the variable local to this script
            for (int i = 0; i < targets.Length; i++)
            {
                occult.friends[i] = targets[i];
            }

            // assigning the items to the variable local to this script
            foreach (string name in targets)
            {
                iteration++;
                assignMurderItems(name, iteration);
            }
        } else if (interestName == "jojo")
        {
            // assigning the names to the variable local to this script
            for (int i = 0; i < targets.Length; i++)
            {
                jojo.friends[i] = targets[i];
            }

            // assigning the items to the variable local to this script
            foreach (string name in targets)
            {
                iteration++;
                assignMurderItems(name, iteration);
            }
        }
    }

    private void assignMurderItems(string name, int iteration)
    {
        if (name == "forestcore")
        {
            if (iteration == 1)
            {
                murderItems1 = forestcore.requiredItems;
            } else if (iteration == 2)
            {

            } else if (iteration == 3)
            {

            }
        } else if (name == "grilldad")
        {

        } else if (name == "chemist")
        {

        } else if (name == "gamer")
        {

        } else if (name == "occult")
        {

        } else if (name == "jojo")
        {

        }
    }

    private void inventoryContainsItems()
    {

    }
}
