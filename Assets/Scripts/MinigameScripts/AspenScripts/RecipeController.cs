using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecipeController : MonoBehaviour
{
    public TextMeshProUGUI moonseedBerries;
    public TextMeshProUGUI sweetTea;
    public TextMeshProUGUI mortar;
    public TextMeshProUGUI nightshade;
    public TextMeshProUGUI honey;
    public GameManager_Aspen gm;
    
    void Start()
    {
        moonseedBerries.text = gm.moonseedBerries + "";
        sweetTea.text = gm.sweetTea / 10 + "";
        mortar.text = gm.mortar / 100 + "";
        nightshade.text = gm.nightshade / 1000 + "";
        honey.text = gm.honey / 10000 + "";
    }
}
