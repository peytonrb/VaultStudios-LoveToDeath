using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemValue : MonoBehaviour
{
    public string itemName;
    public int value;
    public AnothaPlayerController player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<AnothaPlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            player.addPoints(value, itemName);
        }   
    }
}
