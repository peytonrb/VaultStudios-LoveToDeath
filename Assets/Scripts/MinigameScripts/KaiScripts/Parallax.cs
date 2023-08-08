using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float depth = 1;
    public Player player;

    void Update()
    {
        float realVelocity = player.velocity.x / depth;
        Vector3 pos = transform.position;

        if (player.isDead)
        {
            return;
        }
        else
        {
            pos.x -= realVelocity * Time.fixedDeltaTime;

            if (pos.x <= -15f)
            {
                pos.x = 50f;
            }

            transform.position = pos;
        }
    }
}
