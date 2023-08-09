using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ingredient : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private BoxCollider2D ingredientCollider;

    [SerializeField]
    int health = 3;
    // [SerializeField]
    // bool nonDestructible;

    public void Initialize(IngredientData ingredientData)
    {
        //set sprite
        spriteRenderer.sprite = ingredientData.sprite;
        //set sprite offset
        spriteRenderer.transform.localPosition = new Vector2(0.5f * ingredientData.size.x, 0.5f * ingredientData.size.y);
        ingredientCollider.size = ingredientData.size;
        ingredientCollider.offset = spriteRenderer.transform.localPosition;

        // if (ingredientData.nonDestructible)
        //     nonDestructible = true;

        this.health = ingredientData.health;

    }
}