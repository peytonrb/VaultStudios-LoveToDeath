using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookedIngredientController : MonoBehaviour
{
    private int value;
    public MeshRenderer potionMaterial;
    public GameObject cookedPotion;
    public bool isCooked;
    public IngredientController currentColor;
    private Color combinedColor;
    public Color nightshadeColor;

    void Start()
    {
        isCooked = false;
        cookedPotion.SetActive(false);
    }

    private void OnMouseDown()
    {
        cookedPotion.SetActive(true);
        StartCoroutine(cookTimer());
        GameManager_Aspen.plateValue += value;
    }

    IEnumerator cookTimer()
    {
        yield return new WaitForSeconds(10);
        isCooked = true;
        value = 1000;

        if (isCooked)
        {
            combinedColor = Color.Lerp(nightshadeColor, currentColor.potionColor, Mathf.PingPong(Time.time, 1));
            potionMaterial.material.color = combinedColor;
            currentColor.potionColor = combinedColor;
        }
    }
}
