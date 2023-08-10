using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    private Rigidbody2D rb;
    private float width;
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
            if (transform.position.x < -13f)
            {
            transform.position = new Vector3(43f, 8.12f, 5f);
            }
        } 
        else
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
        }
    }
}
