using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookedIngredientController : MonoBehaviour
{
    private int value;
    public MeshRenderer potionMaterial;
    public GameObject cookedPotion;
    public bool isCooked;
    private Color combinedColor;

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
            potionMaterial.material.color = new Color(48f/256f, 25f/256f, 52f/256f);
        }
    }
}
