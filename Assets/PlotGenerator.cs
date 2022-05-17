using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Linq;

public class PlotGenerator : MonoBehaviour
{
    public TextAsset storiesJSON;
    public TextMeshProUGUI situationTMP, questTypeTMP, storyTMP, charactersAndQuestTMP;

    [System.Serializable]
    public class Character
    {
        public string character;
        public string typeOfCharacter;
    }

    [System.Serializable]
    public class Situation
    {
        public string name;
        public string[] stories;
        public Character[] characters;
    }

    [System.Serializable]
    public class SituationList
    {
        public Situation[] situation;
    }

    public SituationList situationList = new SituationList();

    private void Start()
    {
        situationList = JsonUtility.FromJson<SituationList>(storiesJSON.text);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GeneratePlot();
        }
    }

    void InitializeUI()
    {

    }

    void GeneratePlot()
    {
        int poltiValue = Random.Range(0, 36);

        Situation situation = situationList.situation[poltiValue];

        string chosenSituation = situationList.situation[poltiValue].name;
        string chosenQuest = PlotGeneratorData.quests[Random.Range(0, PlotGeneratorData.quests.Length)]; //оепемеярх йбеярш б JSON
        string chosenStory = situation.stories[Random.Range(0, situation.stories.Length)];

        situationTMP.text = chosenSituation;
        questTypeTMP.text = chosenQuest;
        storyTMP.text = "Story:" + "\n" + chosenStory;

        #region Names
        string pathToMaleNames = "Assets/Resources/maleNames.txt";
        string pathToFemaleNames = "Assets/Resources/femaleNames.txt";
        string pathToGodNames = "Assets/Resources/godNames.txt";

        List<string> maleNamesList = File.ReadAllLines(pathToMaleNames).ToList();
        List<string> femaleNamesList = File.ReadAllLines(pathToFemaleNames).ToList();
        List<string> godNamesList = File.ReadAllLines(pathToGodNames).ToList();
        #endregion

        charactersAndQuestTMP.text = "";
        foreach (var character in situation.characters)
        {
            charactersAndQuestTMP.text += character.character + ": ";
            switch (character.typeOfCharacter)
            {
                case ("man"):
                    int gender = Random.Range(0, 1);
                    if (gender == 0)
                        charactersAndQuestTMP.text += maleNamesList[Random.Range(0, maleNamesList.Count)];
                    else
                        charactersAndQuestTMP.text += femaleNamesList[Random.Range(0, femaleNamesList.Count)];
                    break;

                case ("fact"):
                    charactersAndQuestTMP.text += "FACT_NAME";
                    break;

                case ("god"):
                    charactersAndQuestTMP.text += godNamesList[Random.Range(1, godNamesList.Count)];
                    break;
            }

            charactersAndQuestTMP.text += "\n";
        }

        charactersAndQuestTMP.text += "\n" + "Your quest is to " + chosenQuest + " " + situation.characters[Random.Range(0, situation.characters.Length)].character;
    }
}
