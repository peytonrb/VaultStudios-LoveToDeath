using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerRoom : RoomGenerator
{
    public GameObject player;

    public List<IngredientPlacementData> ingredientData;

    [SerializeField]
    private PrefabPlacer prefabPlacer;

    public override List<GameObject> ProcessRoom(
        Vector2Int roomCenter, 
        HashSet<Vector2Int> roomFloor, 
        HashSet<Vector2Int> roomFloorNoCorridors)
    {

        IngredientPlacementHelper ingredientPlacementHelper = 
            new IngredientPlacementHelper(roomFloor, roomFloorNoCorridors);

        List<GameObject> placedObjects = 
            prefabPlacer.PlaceAllIngredients(ingredientData, ingredientPlacementHelper);

        Vector2Int playerSpawnPoint = roomCenter;

        GameObject playerObject 
            = prefabPlacer.CreateObject(player, playerSpawnPoint + new Vector2(0.5f, 0.5f));
 
        placedObjects.Add(playerObject);

        return placedObjects;
    }
}

public abstract class PlacementData
{
    [Min(0)]
    public int minQuantity = 0;
    [Min(0)]
    [Tooltip("Max is inclusive")]
    public int maxQuantity = 0;
    public int Quantity
        => UnityEngine.Random.Range(minQuantity, maxQuantity + 1);
}

[Serializable]
public class IngredientPlacementData : PlacementData
{
    public IngredientData ingredientData;
}