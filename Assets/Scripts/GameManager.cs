using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } 
    public string loveInterestName = "";

    private void Awake()
    {
        // This moves the current GameManager to DontDestroyOnLoad and deletes any other GameManagers
        if (Instance != null) 
        {
            DestroyImmediate(gameObject);
        } 
        else 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  
        }
    }
}
