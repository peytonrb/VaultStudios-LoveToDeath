using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float gravity;
    public Vector2 velocity;
    public float speed = 10f;
    public float maxSpeed = 10f;
    public float distance = 0;
    public float winningDistance;
    public float jumpVelocity = 20f;
    public float velocityX;
    public float maxXVelocity = 100f;
    public float groundHeight = 5f;
    public bool isGrounded = false;
    public bool isHoldingJump = false;
    public float maxHoldJumpTime = 0.4f;
    public float maxMaxHoldJumpTime = 0.4f;
    public float holdJumpTimer = 0.0f;
    public float groundThreshold = 1f;
    public bool isDead;
    public Animator anim;
    public bool hasAdded;
    public GameManager player;
    public PlayerController pController;

    [Header("Win/Lose")]
    public bool hasWon;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject loseScreenDoNotTryAgain;
    public WinLoseUIControllerKai uiController;
    public GameObject distanceText;

    void Start()
    {
        isDead = false;
        hasWon = false;
        hasAdded = false;
        anim = GetComponent<Animator>();
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        loseScreenDoNotTryAgain.SetActive(false);
        player = GameObject.Find("GameManager").GetComponent<GameManager>();
        pController = GameObject.Find("Player").GetComponent<PlayerController>();   
    }

    void Update()
    {
        velocityX = velocity.x;
        Vector3 pos = transform.position;
        float groundDistance = Mathf.Abs(pos.y - groundHeight);

        if (isGrounded || groundDistance <= groundThreshold)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("isJumping", true);
                isGrounded = false;
                velocity.y = jumpVelocity;
                isHoldingJump = true;
                holdJumpTimer = 0.0f;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isHoldingJump = false;
            anim.SetBool("isJumping", false);
        }
    }

    void FixedUpdate()
    {
        Vector3 pos = transform.position;

        if (pos.y <= -20f)
        {
            isDead = true;
        }

        if (isDead && distance >= winningDistance)
        {
            distanceText.SetActive(false);
            winScreen.SetActive(true);
            Destroy(gameObject);

            if (!hasAdded)
            {
                player.bodyCount++;
                GameManager.Instance.sceneJustLoaded = true;
                hasAdded = true;
                pController.isDateTime = true;
            }
        }
        else if (isDead && distance < winningDistance)
        {
            if (!uiController.tryAgainPressed)
            {
                loseScreen.SetActive(true);
            }
            else
            {
                loseScreenDoNotTryAgain.SetActive(true);
                pController.occultIsDead = true;
            }

            distanceText.SetActive(false);
            Destroy(gameObject);
        }

        if (!isGrounded)
        {
            if (isHoldingJump)
            {
                holdJumpTimer += Time.fixedDeltaTime;

                if (holdJumpTimer >= maxHoldJumpTime)
                {
                    isHoldingJump = false;
                }
            }

            pos.y += velocity.y * Time.fixedDeltaTime;

            if (!isHoldingJump)
            {
                velocity.y += gravity * Time.fixedDeltaTime;
            }
        }

        Vector2 rayOrigin = new Vector2(pos.x + 0.7f, pos.y); // ray origin is ahead of player
        Vector2 rayDirection = Vector2.up;
        float rayDistance = velocity.y * Time.fixedDeltaTime;
        RaycastHit2D hit2D = Physics2D.Raycast(rayOrigin, rayDirection, rayDistance);
        
        if (hit2D.collider != null)
        {
            GroundCheck ground = hit2D.collider.GetComponent<GroundCheck>();

            if (ground != null)
            {
                groundHeight = ground.groundHeight;  
                pos.y = groundHeight;
                // velocity.y = 0f; 
                isGrounded = true;
            }
        }

        Vector2 rayOrigin3 = new Vector2(pos.x + 0.7f, pos.y + 1.5f); // ray origin is ahead of player
        Vector2 rayDirection3 = Vector2.right;
        RaycastHit2D hit2D3 = Physics2D.Raycast(rayOrigin3, rayDirection3, 0.5f);

        if (hit2D3.collider != null)
        {
            isDead = true;
        }

        distance += velocity.x * Time.fixedDeltaTime;

        if (isGrounded)
        {
            float velocityRatio = velocity.x / maxXVelocity;
            speed = maxSpeed * (1 - velocityRatio);
            maxHoldJumpTime = maxMaxHoldJumpTime * velocityRatio; // jump length is proportional to speed 

            velocity.x += speed * Time.fixedDeltaTime;

            if (velocity.x >= maxXVelocity)
            {
                velocity.x = maxXVelocity;
            }
 
            Vector2 rayOrigin2 = new Vector2(pos.x - 0.7f, pos.y); // ray origin is ahead of player
            Vector2 rayDirection2 = Vector2.up;
            float rayDistance2 = velocity.y * Time.fixedDeltaTime;
            RaycastHit2D hit2D2 = Physics2D.Raycast(rayOrigin2, rayDirection2, rayDistance2);
        
            if (hit2D2.collider == null)
            {
                isGrounded = false;
            }
        }

        transform.position = pos;
    }
}
