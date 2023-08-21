using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeUIController : MonoBehaviour
{
    public GameObject fakeRecipe1;
    public GameObject fakeRecipe2;
    public GameObject fakeRecipe3;
    public GameObject fakeRecipe4;
    public GameObject realRecipe;

    void Start()
    {
        fakeRecipe1.SetActive(true);
        fakeRecipe2.SetActive(false);
        fakeRecipe3.SetActive(false);
        fakeRecipe4.SetActive(false);
        realRecipe.SetActive(false);
    }

    public void fakeRecipe1Button()
    {
        fakeRecipe1.SetActive(false);
        fakeRecipe2.SetActive(true);
    }

    public void fakeRecipe2Button()
    {
        fakeRecipe2.SetActive(false);
        fakeRecipe3.SetActive(true);
    }

    public void fakeRecipe3Button()
    {
        fakeRecipe3.SetActive(false);
        realRecipe.SetActive(true);
    }

    public void realRecipeButton()
    {
        realRecipe.SetActive(false);
        fakeRecipe4.SetActive(true);
    }

    public void fakeRecipe4Button()
    {
        fakeRecipe4.SetActive(false);
        fakeRecipe1.SetActive(true);
    }
}
