using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBack : MonoBehaviour
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
            if (transform.position.x < -11.27f)
            {
                transform.position = new Vector3(40.86f, 7.93f, 5f);
            }
        }
        else
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
        }
    }
}
