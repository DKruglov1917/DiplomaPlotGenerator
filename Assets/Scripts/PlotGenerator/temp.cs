using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{    
    public static void GeneratePlot()
    {
        WriteStory(GetPoltiValue());
    }

    private static int GetPoltiValue()
    {
        int _poltiValue = Random.Range(0, 36);
        return _poltiValue;
    }

    private static void WriteStory(int poltiValue)
    {
        Debug.Log(PlotGeneratorData.situations[poltiValue]);
        Debug.Log(PlotGeneratorData.stories[poltiValue][0]);

        foreach (var character in PlotGeneratorData.characters[poltiValue])
        {
            Debug.Log("So we have: " + character);           
        }
    }    
}
