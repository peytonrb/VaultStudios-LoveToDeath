using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class sunkcostController : MonoBehaviour
{
   // relating to player movement 
    private Rigidbody rb;
    public float speed = 0;
    private float movementX;
    private float movementY;

    //Making it so I can turn the player off if you die
    //public GameObject player;

    //UI elements
    public GameObject instructionsObject;
    public GameObject winTextObject;
    public GameObject loseTextObject;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
        instructionsObject.SetActive(false);
    }

    //Player movement
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //Player loses if they touch a spotlight
        if (other.gameObject.CompareTag("Light"))
        {
            Detected();
        }

        //Player wins if they touch the area surrounding Armani
        if (other.gameObject.CompareTag("Armani"))
        {
            Victory();
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    //Player has touched Armani, killing him
    void Victory()
    {
        speed = 0;
        winTextObject.SetActive(true);
    }

    //Player has been spotted, losing the game
    void Detected()
    {
        speed = 0;
        //player.SetActive(false);
        loseTextObject.SetActive(true);
    }
}
