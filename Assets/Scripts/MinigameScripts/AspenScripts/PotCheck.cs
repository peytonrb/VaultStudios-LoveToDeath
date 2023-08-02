using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotCheck : MonoBehaviour
{
    public CookedIngredientController cooked;
    public MeshRenderer bigPotionMat;
    public IngredientController ingredient;

    private void OnMouseDown()
    {
        if (gameObject.tag == "BigPot")
        {
            if (GameManager_Aspen.orderValue == GameManager_Aspen.plateValue)
            {
                Debug.Log("correct");
            }
            else 
            {
                Debug.Log("you lose");
            }
        }
        else if (gameObject.tag == "SmallPot")
        {
            if (cooked.isCooked)
            {
                float r = Mathf.Sqrt((Mathf.Pow((48f / 256f), 2f) + Mathf.Pow(ingredient.potionColor.r, 2f)) / 2f);
                float g = Mathf.Sqrt((Mathf.Pow((25f / 256f), 2f) + Mathf.Pow(ingredient.potionColor.g, 2f)) / 2f);
                float b = Mathf.Sqrt((Mathf.Pow((52f / 256f), 2f) + Mathf.Pow(ingredient.potionColor.b, 2f)) / 2f);
                bigPotionMat.material.color = new Color(r, g, b);
            }
        }
    }
}
