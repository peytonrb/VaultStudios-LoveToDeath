using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientController : MonoBehaviour
{
    public Transform ingredient;
    public int value;

    private void OnMouseDown()
    {
        if (gameObject.name == "MoonseedBerries") // 1
        {
            // instantiate/change potion color/etc
        }

        if (gameObject.name == "SweetTea") // 10
        {

        }

        if (gameObject.name == "Mortar") // 100
        {

        }
        
        // if (gameObject.name == "Nightshade") // 1000
        // {
                // needs to be cooked more than everything else
        // }

        if (gameObject.name == "Honey") // 10000
        {

        }

        GameManager_Aspen.plateValue += value;
        Debug.Log(GameManager_Aspen.plateValue + " " + GameManager_Aspen.orderValue);
    }
}
