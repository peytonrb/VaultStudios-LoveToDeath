using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float groundHeight;
    public float groundRight;
    public float screenRight;
    private BoxCollider2D collider2d;
    private bool didGenerateGround = false;
    public Player player;

    void Start()
    {
        collider2d = GetComponent<BoxCollider2D>();
        groundHeight = transform.position.y + (collider2d.size.y / 2) + 1;
        screenRight = Camera.main.transform.position.x * 2;
    }

    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos.x -= player.velocity.x * Time.fixedDeltaTime;
        groundRight = transform.position.x + (collider2d.size.x / 2);
        
        if (groundRight < -10f)
        {
            Destroy(gameObject);
            return;
        }
        
        if (!didGenerateGround)
        {
            if (groundRight < screenRight)
            {
                didGenerateGround = true;
                generateGround();
            }
        }

        transform.position = pos;
    }

    private void generateGround()
    {
        GameObject moreGround = Instantiate(gameObject);
        BoxCollider2D groundCollider = moreGround.GetComponent<BoxCollider2D>();
        Vector3 pos;

        float height1 = player.jumpVelocity * player.maxHoldJumpTime;
        float time = player.jumpVelocity / -player.gravity;
        float height2 = player.jumpVelocity * time + (0.5f * (-player.gravity * (time * time)));
        float maxJumpHeight = height1 + height2;
        float maxY = maxJumpHeight * 0.8f;
        maxY += groundHeight;
        float minY = 1;
        float actualY = Random.Range(minY, maxY);

        pos.y = actualY - groundCollider.size.y / 2;

        if (pos.y > 10f) // max height of generated platforms
        {
            pos.y = 10f;
        }

        float t1 = time + player.maxHoldJumpTime;
        float t2 = Mathf.Sqrt((2.0f * (maxY - actualY)) / -player.gravity);
        float totalTime = t1 + t2;
        float maxX = totalTime * player.velocity.x;
        maxX *= 0.8f;
        maxX += groundRight;
        float minX = screenRight + 30;
        float actualX = Random.Range(minX, maxX);

        pos.x = actualX + groundCollider.size.x / 2;
        pos.z = transform.position.z;
        moreGround.transform.position = pos;
        GroundCheck groundGO = moreGround.GetComponent<GroundCheck>();
        groundGO.groundHeight = moreGround.transform.position.y + (groundCollider.size.y / 2) + 1;
    }
}
