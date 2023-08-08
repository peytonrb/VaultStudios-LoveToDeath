using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Player player;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos.x -= player.velocity.x * Time.fixedDeltaTime;

        if (pos.x < -100f)
        {
            Destroy(gameObject); 
        }

        pos.z = transform.position.z;
        transform.position = pos;
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Destroy(gameObject);
            player.velocity.x *= 0.6f;
            player.speed *= 0.6f;
        }
    }
}
