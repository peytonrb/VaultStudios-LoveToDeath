using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float depth = 1;
    public Player player;

    void Start()
    {
        
    }

    void Update()
    {
        float realVelocity = player.velocity.x / depth;
        Vector3 pos = transform.position;

        pos.x -= realVelocity * Time.fixedDeltaTime;

        if (pos.x <= -25f)
        {
            pos.x = 80f;
        }

        transform.position = pos;
    }
}
