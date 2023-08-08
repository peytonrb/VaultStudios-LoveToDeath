using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LabGenerator), true)]
public class RandomLabGeneratorEditor : Editor
{
    LabGenerator generator;

    void Awake()
    {
        generator = (LabGenerator) target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Create Lab"))
        {
            generator.generateLab();
        }
    }
}
