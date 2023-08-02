using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IngredientController : MonoBehaviour
{
    public Transform ingredient;
    public MeshRenderer bigPotionMat;
    public int value;
    public Color potionColor;
    public Color berryColor;
    public Color teaColor;
    public Color mortarColor;
    public Color honeyColor;

    private void OnMouseDown()
    {
        float r;
        float g;
        float b;
        Color combinedColor = Color.white;
        potionColor = combinedColor;

        if (gameObject.name == "MoonseedBerries") // 1
        {
            r = Mathf.Sqrt((Mathf.Pow(berryColor.r, 2f) + Mathf.Pow(potionColor.r, 2f)) / 2f);
            g = Mathf.Sqrt((Mathf.Pow(berryColor.g, 2f) + Mathf.Pow(potionColor.g, 2f)) / 2f);
            b = Mathf.Sqrt((Mathf.Pow(berryColor.b, 2f) + Mathf.Pow(potionColor.b, 2f)) / 2f);
            combinedColor = new Color(r, g, b);
            // combinedColor = Color.Lerp(berryColor, potionColor, 0.5f);
            bigPotionMat.material.color = combinedColor;
        }

        if (gameObject.name == "SweetTea") // 10
        {
            r = Mathf.Sqrt((Mathf.Pow(teaColor.r, 2f) + Mathf.Pow(potionColor.r, 2f)) / 2f);
            g = Mathf.Sqrt((Mathf.Pow(teaColor.g, 2f) + Mathf.Pow(potionColor.g, 2f)) / 2f);
            b = Mathf.Sqrt((Mathf.Pow(teaColor.b, 2f) + Mathf.Pow(potionColor.b, 2f)) / 2f);
            combinedColor = new Color(r, g, b);
            // combinedColor = Color.Lerp(teaColor, potionColor, 0.5f);
            bigPotionMat.material.color = combinedColor;
        }

        if (gameObject.name == "Mortar") // 100
        {
            r = Mathf.Sqrt((Mathf.Pow(mortarColor.r, 2f) + Mathf.Pow(potionColor.r, 2f)) / 2f);
            g = Mathf.Sqrt((Mathf.Pow(mortarColor.g, 2f) + Mathf.Pow(potionColor.g, 2f)) / 2f);
            b = Mathf.Sqrt((Mathf.Pow(mortarColor.b, 2f) + Mathf.Pow(potionColor.b, 2f)) / 2f);
            combinedColor = new Color(r, g, b);
            // combinedColor = Color.Lerp(mortarColor, potionColor, 0.5f);
            bigPotionMat.material.color = combinedColor;
        }

        if (gameObject.name == "Honey") // 10000
        {
            r = Mathf.Sqrt((Mathf.Pow(honeyColor.r, 2f) + Mathf.Pow(potionColor.r, 2f)) / 2f);
            g = Mathf.Sqrt((Mathf.Pow(honeyColor.g, 2f) + Mathf.Pow(potionColor.g, 2f)) / 2f);
            b = Mathf.Sqrt((Mathf.Pow(honeyColor.b, 2f) + Mathf.Pow(potionColor.b, 2f)) / 2f);
            combinedColor = new Color(r, g, b);
            // combinedColor = Color.Lerp(honeyColor, potionColor, 0.5f);
            bigPotionMat.material.color = combinedColor;
        }

        GameManager_Aspen.plateValue += value;
    }
}
