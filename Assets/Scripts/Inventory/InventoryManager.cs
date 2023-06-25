using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> items = new List<Item>();
    public Transform itemContent;
    public GameObject inventoryItem;

    private void Awake()
    {
        Instance = this;
    }

    public void add(Item item)
    {
        items.Add(item);
    }

    public void remove(Item item)
    {
        items.Remove(item);
    }

    // needs to be called when inventory button is pressed
    public void listItems()
    {
        // deletes exiting items in inventory before reloading
        foreach(Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        foreach(var item in items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);

            // var is SO BAD TO USE. DO NOT USE 
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }
    }
}
