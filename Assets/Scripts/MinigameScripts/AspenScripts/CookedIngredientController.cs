using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookedIngredientController : MonoBehaviour
{
    private int value;
    private MeshRenderer potionMaterial;
    private bool isCooked;

    void Start()
    {
        potionMaterial = GetComponent<MeshRenderer>();
        isCooked = false;
        StartCoroutine(cookTimer());
    }

    private void OnMouseDown()
    {
        GameManager_Aspen.plateValue += value;
    }

    IEnumerator cookTimer()
    {
        yield return new WaitForSeconds(10);
        value = 1000;

        if (isCooked)
        {
            potionMaterial.material.color = new Color(48f/256f, 25f/256f, 52f/256f);
        }
    }
}
