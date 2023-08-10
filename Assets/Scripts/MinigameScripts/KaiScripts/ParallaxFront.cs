using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxFront : MonoBehaviour
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

            if (pos.x <= -2.5f)
            {
                pos.x = 50f;
                GameObject newOne = Instantiate(gameObject, new Vector3(35f, 2.23f, 5f), Quaternion.identity);
                
                if (pos.x == -26f)
                {
                    Destroy(gameObject);
                }
            }

            transform.position = pos;
        }
    }
}
