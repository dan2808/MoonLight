using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TreeGenerator))]
public class LevelDesignerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        TreeGenerator generatorScript = (TreeGenerator)target;



        if (GUILayout.Button("GenerateAssets"))
        {
            generatorScript.GenerateAssets();
        }

        if (GUILayout.Button("DeleteAssets"))
        {
            generatorScript.DeleteAssets();
        }
    }
}
