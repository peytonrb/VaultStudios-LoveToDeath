using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxFront : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public Player player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(speed, 0f, 0f);
    }

    void Update()
    {
        if (!player.isDead)
        {
            if (transform.position.x < -10.52f)
            {
                transform.position = new Vector3(39.32f, 2.23f, 5f);
            }
        }
        else
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
        }
    }
}
