using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecipeController : MonoBehaviour
{
    private TextMeshProUGUI recipe;
    public GameManager_Aspen gm;
    
    void Start()
    {
        recipe = GetComponent<TextMeshProUGUI>();
        recipe.text = "berries: " + gm.moonseedBerries + "\n"
                      + "tea: " + gm.sweetTea / 10 + "\n"
                      + "mortar: " + gm.mortar / 100 + "\n"
                      + "nightshade: " + gm.nightshade / 1000 + "\n"
                      + "honey: " + gm.honey / 10000;
    }
}
