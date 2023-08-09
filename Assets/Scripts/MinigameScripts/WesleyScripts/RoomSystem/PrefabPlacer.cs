using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class PrefabPlacer : MonoBehaviour
{
    [SerializeField]
    private GameObject ingredientPrefab;

    public List<GameObject> PlaceAllIngredients(List<IngredientPlacementData> ingredientPlacementData, IngredientPlacementHelper ingredientPlacementHelper)
    {
        List<GameObject> placedObjects = new List<GameObject>();

        IEnumerable<IngredientPlacementData> sortedList = new List<IngredientPlacementData>(ingredientPlacementData).OrderByDescending(placementData => placementData.ingredientData.size.x * placementData.ingredientData.size.y);

        foreach (var placementData in sortedList)
        {
            for (int i = 0; i < placementData.Quantity; i++)
            {
                Vector2? possiblePlacementSpot = ingredientPlacementHelper.GetIngredientPlacementPosition(
                    placementData.ingredientData.placementType,  
                    100, 
                    placementData.ingredientData.size, 
                    placementData.ingredientData.addOffset);


                if (possiblePlacementSpot.HasValue)
                {

                    placedObjects.Add(PlaceIngredient(placementData.ingredientData, possiblePlacementSpot.Value)); 
                }
            }
        }
        return placedObjects;
    }
    private GameObject PlaceIngredient(IngredientData ingredient, Vector2 placementPosition)
    {
        GameObject newIngredient = CreateObject(ingredientPrefab,placementPosition); 
        //GameObject newIngredient = Instantiate(IngredientPrefab, placementPosition, Quaternion.identity);
        newIngredient.GetComponent<Ingredient>().Initialize(ingredient); 
        return newIngredient;
    }

    public GameObject CreateObject(GameObject prefab, Vector3 placementPosition)
    {
        if (prefab == null)
            return null;
        GameObject newIngredient;
        if (Application.isPlaying)
        {
            newIngredient = Instantiate(prefab, placementPosition, Quaternion.identity);
        }
        else
        {
            newIngredient = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
            newIngredient.transform.position = placementPosition;
            newIngredient.transform.rotation = Quaternion.identity;
        }

        return newIngredient;
    }
}
