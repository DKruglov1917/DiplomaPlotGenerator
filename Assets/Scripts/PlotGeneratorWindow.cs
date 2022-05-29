using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlotGeneratorWindow : MonoBehaviour
{
    public TextMeshProUGUI situation, questType, story, characters, quest;

    private void Awake()
    {
        PlotGenerator.OnPlotCreation += UpdateUI;
    }
    private void OnDestroy()
    {
        PlotGenerator.OnPlotCreation -= UpdateUI;
    }

    private void UpdateUI(PlotGenerator.Situation chosenSituation)
    {
        situation.text = chosenSituation.name;
        questType.text = chosenSituation.questType;
        story.text = "Story: \n" + chosenSituation.story;

        characters.text = null;
        characters.text = "Characters: \n";
        foreach (var character in chosenSituation.characters)
        {
            characters.text += character.character + ": " + character.name + "\n";
        }

        quest.text = "Your quest is " + chosenSituation.questString;
    }

    private void Exit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
