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
    public float jumpVelocity = 20f;
    public float maxXVelocity = 100f;
    public float groundHeight = 5f;
    public bool isGrounded = false;
    public bool isHoldingJump = false;
    public float maxHoldJumpTime = 0.4f;
    public float maxMaxHoldJumpTime = 0.4f;
    public float holdJumpTimer = 0.0f;
    public float groundThreshold = 1f;
    public bool isDead;

    [Header("Win/Lose")]
    public bool hasWon;

    void Start()
    {
        isDead = false;
        hasWon = false;
    }

    void Update()
    {
        Vector3 pos = transform.position;
        float groundDistance = Mathf.Abs(pos.y - groundHeight);

        if (isGrounded || groundDistance <= groundThreshold)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                velocity.y = jumpVelocity;
                isHoldingJump = true;
                holdJumpTimer = 0.0f;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isHoldingJump = false;
        }
    }

    void FixedUpdate()
    {
        Vector3 pos = transform.position;

        if (pos.y <= -20f)
        {
            isDead = true;
        }

        if (isDead)                 // death --> trigger ui here
        {
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

        Vector2 rayOrigin3 = new Vector2(pos.x + 0.7f, pos.y + 1f); // ray origin is ahead of player
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
