using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    void Update()
    {
        // NEED LOGIC ALLOWING PLAYER TO PICK UP OBJECT
        pickup();
    }

    private void pickup()
    {
        InventoryManager.Instance.add(item);
        Destroy(gameObject);
    }
}
