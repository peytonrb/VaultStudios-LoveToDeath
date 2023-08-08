using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Parameters_", menuName = "Procedural Content Generation/Data")]
public class Data : ScriptableObject
{
    public int iterations = 10, walkLength = 10;
    public bool startRandomIteration = true;
}
