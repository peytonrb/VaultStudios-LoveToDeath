using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientRoom : RoomGenerator
{
    public PrefabPlacer prefabPlacer;
    public List<IngredientPlacementData> itemData;

    public override List<GameObject> ProcessRoom(Vector2Int roomCenter, HashSet<Vector2Int> roomFloor, HashSet<Vector2Int> roomFloorNoCorridors)
    {
        IngredientPlacementHelper itemPlacementHelper =
            new IngredientPlacementHelper(roomFloor, roomFloorNoCorridors);

        List<GameObject> placedObjects =
            prefabPlacer.PlaceAllIngredients(itemData, itemPlacementHelper);

        return placedObjects;
    }
}
