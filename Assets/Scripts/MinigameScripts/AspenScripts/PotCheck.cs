using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotCheck : MonoBehaviour
{
    public CookedIngredientController cooked;
    public MeshRenderer bigPotionMat;

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
                bigPotionMat.material.color = new Color(0.41f, 0.14f, 0.45f);
            }
        }
    }
}
