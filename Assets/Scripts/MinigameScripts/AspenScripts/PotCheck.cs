using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotCheck : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GameManager_Aspen.orderValue == GameManager_Aspen.plateValue)
        {
            Debug.Log("correct");
        }
    }
}
