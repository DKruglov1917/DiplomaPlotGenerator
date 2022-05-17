using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;

public class PlotGeneratorWindow : EditorWindow
{
    [MenuItem("Window/Plot Generator")]
   public static void ShowWindow()
    {
        GetWindow<PlotGeneratorWindow>("Plot Generator");
    }

    private void OnGUI()
    {
        GUILayout.Label("Quests", EditorStyles.boldLabel);        
        EditorGUILayout.Space();


        GUILayout.Label("Situations", EditorStyles.boldLabel);
        EditorGUILayout.Space();


        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Save"))
        {

        }
        if (GUILayout.Button("Load"))
        {
            
        }
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Test"))
        {
            //PlotGenerator.GeneratePlot();            
        }

        //if (GUILayout.Button("Read"))
        //{
        //    string path = "Assets/Resources/Names.txt";
        //    StreamReader reader = new StreamReader(path);
        //    Debug.Log(reader.ReadToEnd());
        //    reader.Close();
        //}

        if (GUILayout.Button("Read"))
        {
            string path = "Assets/Resources/maleNames.txt";
            List<string> fileLines = File.ReadAllLines(path).ToList();
            Debug.Log(fileLines[Random.Range(0, fileLines.Count)]);
        }
    }
}
