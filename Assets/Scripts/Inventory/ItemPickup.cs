using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, 5f); // second number is radius
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F))
            {
                pickup();
            }
        }
    }

    private void pickup()
    {
        InventoryManager.Instance.add(item);
        Destroy(gameObject);
    }
}
