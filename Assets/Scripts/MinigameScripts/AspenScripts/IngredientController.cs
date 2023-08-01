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

        if (gameObject.name == "MoonseedBerries") // 1
        {
            r = Mathf.Sqrt(((float) Math.Pow(berryColor.r, 2f) + (float) Math.Pow(potionColor.r, 2f)) / 2f);
            g = Mathf.Sqrt(((float) Math.Pow(berryColor.g, 2f) + (float) Math.Pow(potionColor.g, 2f)) / 2f);
            b = Mathf.Sqrt(((float) Math.Pow(berryColor.b, 2f) + (float) Math.Pow(potionColor.b, 2f)) / 2f);
            combinedColor = new Color(r, g, b);
            // combinedColor = Color.Lerp(berryColor, potionColor, 0.5f);
            bigPotionMat.material.color = combinedColor;
        }

        if (gameObject.name == "SweetTea") // 10
        {
            r = Mathf.Sqrt(((float) Math.Pow(teaColor.r, 2f) + (float) Math.Pow(potionColor.r, 2f)) / 2f);
            g = Mathf.Sqrt(((float) Math.Pow(teaColor.g, 2f) + (float) Math.Pow(potionColor.g, 2f)) / 2f);
            b = Mathf.Sqrt(((float) Math.Pow(teaColor.b, 2f) + (float) Math.Pow(potionColor.b, 2f)) / 2f);
            combinedColor = new Color(r, g, b);
            // combinedColor = Color.Lerp(teaColor, potionColor, 0.5f);
            bigPotionMat.material.color = combinedColor;
        }

        if (gameObject.name == "Mortar") // 100
        {
            r = Mathf.Sqrt(((float) Math.Pow(mortarColor.r, 2f) + (float) Math.Pow(potionColor.r, 2f)) / 2f);
            g = Mathf.Sqrt(((float) Math.Pow(mortarColor.g, 2f) + (float) Math.Pow(potionColor.g, 2f)) / 2f);
            b = Mathf.Sqrt(((float) Math.Pow(mortarColor.b, 2f) + (float) Math.Pow(potionColor.b, 2f)) / 2f);
            combinedColor = new Color(r, g, b);
            // combinedColor = Color.Lerp(mortarColor, potionColor, 0.5f);
            bigPotionMat.material.color = combinedColor;
        }

        if (gameObject.name == "Honey") // 10000
        {
            r = Mathf.Sqrt(((float) Math.Pow(honeyColor.r, 2f) + (float) Math.Pow(potionColor.r, 2f)) / 2f);
            g = Mathf.Sqrt(((float) Math.Pow(honeyColor.g, 2f) + (float) Math.Pow(potionColor.g, 2f)) / 2f);
            b = Mathf.Sqrt(((float) Math.Pow(honeyColor.b, 2f) + (float) Math.Pow(potionColor.b, 2f)) / 2f);
            combinedColor = new Color(r, g, b);
            // combinedColor = Color.Lerp(honeyColor, potionColor, 0.5f);
            bigPotionMat.material.color = combinedColor;
        }

        potionColor = combinedColor;
        Debug.Log(potionColor.r + " " + potionColor.g + " " + potionColor.b);
        GameManager_Aspen.plateValue += value;
    }
}
