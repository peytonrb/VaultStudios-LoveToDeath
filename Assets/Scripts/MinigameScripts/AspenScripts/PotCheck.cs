using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotCheck : MonoBehaviour
{
    public CookedIngredientController cooked;
    public MeshRenderer bigPotionMat;
    public IngredientController ingredient;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject loseScreenNoTryAgain;
    public WinLoseUIControllerAspen uiController;
    public bool hasAdded;

    void Start()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        loseScreenNoTryAgain.SetActive(false);
        hasAdded = false;
    }

    private void OnMouseDown()
    {
        if (gameObject.tag == "BigPot")
        {
            if (GameManager_Aspen.orderValue == GameManager_Aspen.plateValue)
            {
                winScreen.SetActive(true);

                if (!hasAdded)
                {
                    player.bodyCount++;
                    GameManager.Instance.sceneJustLoaded = true;
                    hasAdded = true;
                    pController.isDateTime = true;
                }
            }
            else
            {
                if (!uiController.tryAgainPressed)
                {
                    loseScreen.SetActive(true);
                }
                else
                {
                    loseScreenNoTryAgain.SetActive(true);
                }
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
