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
    public bool hasMurderItems1;
    public bool hasMurderItems2;
    public bool hasMurderItems3;
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
        hasMurderItems1 = false;
        hasMurderItems2 = false;
        hasMurderItems3 = false;
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

        // love interest interaction key
        if (Input.GetKeyDown(KeyCode.F))
        {
            // guarantees player is within range of love interest
            Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, 5f); // second number is radius
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.tag == "Player")
                {
                    inventoryContainsItems(); // checks if player has murder items
                }
            }
        }

        if (inventory.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            inventory.SetActive(false);
        }
        // end key presses

        assignMurders(interestName);
    }

    private void inventoryContainsItems()
    {
        int counter1 = 0;
        int counter2 = 0;
        int counter3 = 0;

        // checks if player has required items
        for (int i = 0; i < murderItems1.Length; i++)
        {
            if (inventoryManager.contains(murderItems1[i]))
            {
                counter1++;
            }
        }

        for (int i = 0; i < murderItems2.Length; i++)
        {
            if (inventoryManager.contains(murderItems2[i]))
            {
                counter2++;
            }
        }

        for (int i = 0; i < murderItems3.Length; i++)
        {
            if (inventoryManager.contains(murderItems3[i]))
            {
                counter3++;
            }
        }

        // makes sure player has ALL required items
        if (counter1 == 3)
        {
            hasMurderItems1 = true;
            setToKill(1);
        }
        else if (counter2 == 3)
        {
            hasMurderItems2 = true;
            setToKill(2);
        }
        else if (counter3 == 3)
        {
            hasMurderItems3 = true;
            setToKill(3);
        }
    }

    private void setToKill(int index)
    {
        if (targets[index] == "forestcore")
        {
            forestcore.playerHasItems = true;
        }
        else if (targets[index] == "grilldad")
        {
            grilldad.playerHasItems = true;
        }
        else if (targets[index] == "chemist")
        {
            chemist.playerHasItems = true;
        }
        else if (targets[index] == "gamer")
        {
            gamer.playerHasItems = true;
        }
        else if (targets[index] == "jojo")
        {
            jojo.playerHasItems = true;
        }
        else if (targets[index] == "occult")
        {
            occult.playerHasItems = true;
        }
    }

    // assigns the murder targets to the variables
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

    // assigns the items required to kill the targets to the variables
    private void assignMurderItems(string name, int iteration)
    {
        if (name == "forestcore")
        {
            if (iteration == 1)
            {
                for (int i = 0; i < forestcore.requiredItems.Length; i++)
                {
                    murderItems1[i] = forestcore.requiredItems[i];
                }
            } else if (iteration == 2)
            {
                for (int i = 0; i < forestcore.requiredItems.Length; i++)
                {
                    murderItems2[i] = forestcore.requiredItems[i];
                }
            } else if (iteration == 3)
            {
                for (int i = 0; i < forestcore.requiredItems.Length; i++)
                {
                    murderItems3[i] = forestcore.requiredItems[i];
                }
            }
        } else if (name == "grilldad")
        {
            if (iteration == 1)
            {
                for (int i = 0; i < grilldad.requiredItems.Length; i++)
                {
                    murderItems1[i] = grilldad.requiredItems[i];
                }
            } else if (iteration == 2)
            {
                for (int i = 0; i < grilldad.requiredItems.Length; i++)
                {
                    murderItems2[i] = grilldad.requiredItems[i];
                }
            } else if (iteration == 3)
            {
                for (int i = 0; i < grilldad.requiredItems.Length; i++)
                {
                    murderItems3[i] = grilldad.requiredItems[i];
                }
            }
        } else if (name == "chemist")
        {
            if (iteration == 1)
            {
                for (int i = 0; i < chemist.requiredItems.Length; i++)
                {
                    murderItems1[i] = chemist.requiredItems[i];
                }
            } else if (iteration == 2)
            {
                for (int i = 0; i < chemist.requiredItems.Length; i++)
                {
                    murderItems2[i] = chemist.requiredItems[i];
                }
            } else if (iteration == 3)
            {
                for (int i = 0; i < chemist.requiredItems.Length; i++)
                {
                    murderItems3[i] = chemist.requiredItems[i];
                }
            }
        } else if (name == "gamer")
        {
            if (iteration == 1)
            {
                for (int i = 0; i < gamer.requiredItems.Length; i++)
                {
                    murderItems1[i] = gamer.requiredItems[i];
                }
            } else if (iteration == 2)
            {
                for (int i = 0; i < gamer.requiredItems.Length; i++)
                {
                    murderItems2[i] = gamer.requiredItems[i];
                }
            } else if (iteration == 3)
            {
                for (int i = 0; i < gamer.requiredItems.Length; i++)
                {
                    murderItems3[i] = gamer.requiredItems[i];
                }
            }
        } else if (name == "occult")
        {
            if (iteration == 1)
            {
                for (int i = 0; i < occult.requiredItems.Length; i++)
                {
                    murderItems1[i] = occult.requiredItems[i];
                }
            } else if (iteration == 2)
            {
                for (int i = 0; i < occult.requiredItems.Length; i++)
                {
                    murderItems2[i] = occult.requiredItems[i];
                }
            } else if (iteration == 3)
            {
                for (int i = 0; i < occult.requiredItems.Length; i++)
                {
                    murderItems3[i] = occult.requiredItems[i];
                }
            }
        } else if (name == "jojo")
        {
            if (iteration == 1)
            {
                for (int i = 0; i < jojo.requiredItems.Length; i++)
                {
                    murderItems1[i] = jojo.requiredItems[i];
                }
            } else if (iteration == 2)
            {
                for (int i = 0; i < jojo.requiredItems.Length; i++)
                {
                    murderItems2[i] = jojo.requiredItems[i];
                }
            } else if (iteration == 3)
            {
                for (int i = 0; i < jojo.requiredItems.Length; i++)
                {
                    murderItems3[i] = jojo.requiredItems[i];
                }
            }
        }
    }
}
