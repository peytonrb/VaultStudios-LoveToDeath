using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ItemSpawn : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase floorTile;
    private BoxCollider boxCollider;

    [Header("Player")]
    public GameObject player;
    public bool playerSpawn;

    [Header("Chlorine")]
    public GameObject item1Prefab;
    public int minimumAmountChlorine;
    public int maximumAmountChlorine;

    [Header("Sodium")]
    public GameObject item2Prefab;
    public int minimumAmountSodium;
    public int maximumAmountSodium;

    [Header("Lithium")]
    public GameObject item3Prefab;
    public int minimumAmountLithium;
    public int maximumAmountLithium;

    [Header("Potassium")]
    public GameObject item4Prefab;
    public int minimumAmountPotassium;
    public int maximumAmountPotassium;

    [Header("Oxygen")]
    public GameObject item5Prefab;
    public int minimumAmountOxygen;
    public int maximumAmountOxygen;

    [Header("Nitrogen")]
    public GameObject item6Prefab;
    public int minimumAmountNitrogen;
    public int maximumAmountNitrogen;

    [Header("Helium")]
    public GameObject item7Prefab;
    public int minimumAmountHelium;
    public int maximumAmountHelium;

    [Header("Argon")]
    public GameObject item8Prefab;
    public int minimumAmountArgon;
    public int maximumAmountArgon;

    [Header("Lead")]
    public GameObject item9Prefab;
    public int minimumAmountLead;
    public int maximumAmountLead;
    
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        generateRandom(item1Prefab, minimumAmountChlorine, maximumAmountChlorine);
        generateRandom(item2Prefab, minimumAmountSodium, maximumAmountSodium);
        generateRandom(item3Prefab, minimumAmountLithium, maximumAmountLithium);
        generateRandom(item4Prefab, minimumAmountPotassium, maximumAmountPotassium);
        generateRandom(item5Prefab, minimumAmountOxygen, maximumAmountOxygen);
        generateRandom(item6Prefab, minimumAmountNitrogen, maximumAmountNitrogen);
        generateRandom(item7Prefab, minimumAmountHelium, maximumAmountHelium);
        generateRandom(item8Prefab, minimumAmountArgon, maximumAmountArgon);
        generateRandom(item9Prefab, minimumAmountLead, maximumAmountLead);

        playerSpawn = false;
        spawnPlayer();
    }

    public void spawnPlayer()
    {
        while (!playerSpawn)
        {
            Vector3Int potentialPosition = new Vector3Int(0, 0, 0);
            potentialPosition = RandomPointInBounds(boxCollider.bounds);

            if (tilemap.GetTile(potentialPosition) == floorTile)
            {
                player.transform.position = potentialPosition;
                playerSpawn = true;
            }
        }
        
    }

    public void generateRandom(GameObject item, int maxAmt, int minAmt) // bool isRecursion, int startCount
    {
        int count = 0;

        // if (isRecursion)
        // {
        //     count = startCount;
        // }

        for (int i = 0; i <= 100; i++)
        {
            Vector3Int potentialPosition = new Vector3Int(0, 0, 0);
            potentialPosition = RandomPointInBounds(boxCollider.bounds);
            // Debug.Log(potentialPosition + " " + item.name);
            
            if (tilemap.GetTile(potentialPosition) == floorTile && count <= maxAmt)
            {
                count++;
                Instantiate(item, potentialPosition, Quaternion.identity);
            }
        }

        // if (count < minAmt)
        // {
        //     generateRandom(item, maxAmt, minAmt, true, count);
        // }
    }

    public Vector3Int RandomPointInBounds(Bounds bounds) {
        return new Vector3Int(
            (int) Random.Range(bounds.min.x, bounds.max.x),
            (int) Random.Range(bounds.min.y, bounds.max.y),
            0
        );  
    }
}
