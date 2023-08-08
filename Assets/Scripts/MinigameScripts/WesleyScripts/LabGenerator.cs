using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LabGenerator : MonoBehaviour
{
    public TileVisualizer tilemapVisualizer = null;
    public Vector2Int startPosition = Vector2Int.zero;
    
    public void generateLab()
    {
        tilemapVisualizer.Clear();
        RunProceduralGeneration();
    }

    protected abstract void RunProceduralGeneration();
}
