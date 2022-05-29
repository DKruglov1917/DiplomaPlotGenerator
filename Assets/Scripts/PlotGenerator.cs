using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

using Random = UnityEngine.Random;

public class PlotGenerator : MonoBehaviour
{
    public delegate void PlotCreation(Situation chosenSituation);
    public static event PlotCreation OnPlotCreation;

    public TextAsset situationsAndStoriesJSON, questsJSON;
    public PlotGeneratorWindow window;
    public Situation situation;
    private List<string> maleNamesList, femaleNamesList, godNamesList, factNamesList, objectNamesList;

    #region Paths to names
    private string pathToMaleNames = "Assets/PlotGenResources/maleNames.txt";
    private string pathToFemaleNames = "Assets/PlotGenResources/femaleNames.txt";
    private string pathToGodNames = "Assets/PlotGenResources/godNames.txt";
    private string pathToFactNames = "Assets/PlotGenResources/factNames.txt";
    private string pathToObjectNames = "Assets/PlotGenResources/objectNames.txt";
    #endregion

    [Serializable]
    public class Character
    {
        [HideInInspector] public string character;
        public string name;
        public string typeOfCharacter;
        public int gender;
    }

    [Serializable]
    public class Situation
    {
        public string name;
        public string story;
        public string questType;
        public string questString;
        public Quest quest;
        public Character[] characters;
        [HideInInspector] public string[] stories;
    }

    public class SituationList
    {
        public Situation[] situation;
    }

    [Serializable]
    public class Quest
    {
        public string name;
        [HideInInspector] public string questString1;
        [HideInInspector] public string[] possibleTarget1;
        [HideInInspector] public string questString2;
        [HideInInspector] public string[] possibleTarget2;
    }

    public class QuestList
    {
        public Quest[] quest;
    }

    public SituationList situationList = new SituationList();
    public QuestList questList = new QuestList();

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GeneratePlot();
        }
    }

    private void Initialize()
    {
        situationList = JsonUtility.FromJson<SituationList>(situationsAndStoriesJSON.text);
        questList = JsonUtility.FromJson<QuestList>(questsJSON.text);

        maleNamesList = File.ReadAllLines(pathToMaleNames).ToList();
        femaleNamesList = File.ReadAllLines(pathToFemaleNames).ToList();
        godNamesList = File.ReadAllLines(pathToGodNames).ToList();
        factNamesList = File.ReadAllLines(pathToFactNames).ToList();
        objectNamesList = File.ReadAllLines(pathToObjectNames).ToList();
    }

    private void GeneratePlot()
    {
        CreateSituation();
        NameCharacters();   
        AddCharactersToQuest(situation);

        OnPlotCreation?.Invoke(situation);
    }

    private void CreateSituation()
    {
        int poltiValue = Random.Range(0, 36);

        situation = situationList.situation[poltiValue];
        situation.story = situation.stories[Random.Range(0, situation.stories.Length)];
        situation.questType = QuestCreator.ChooseQuestType(questList, situation);
        situation.quest = Array.Find(questList.quest, element => element.name == situation.questType);
    }

    private void NameCharacters()
    {
        foreach (var character in situation.characters)
        {
            switch (character.typeOfCharacter)
            {
                case ("man"):
                    character.gender = Random.Range(1, 3);
                    if (character.gender == 1)
                        character.name = maleNamesList[Random.Range(0, maleNamesList.Count)];
                    else
                        character.name = femaleNamesList[Random.Range(0, femaleNamesList.Count)];
                    break;

                case ("fact"):
                    character.name = factNamesList[Random.Range(0, factNamesList.Count)];
                    break;

                case ("object"):
                    character.name = objectNamesList[Random.Range(0, objectNamesList.Count)];
                    break;

                case ("god"):
                    character.name = godNamesList[Random.Range(1, godNamesList.Count)];
                    break;

                default:
                    break;
            }
        }
    }

    private void AddCharactersToQuest(Situation situation) 
    {
        List<string> chosenCharacters = new List<string>();

        int variation = Random.Range(0, 2);
        situation.questString = "";

        if (variation == 0)
        {
            situation.questString = situation.quest.questString1 + " ";
            situation.questString += ChooseQuestTarget(situation, situation.quest.possibleTarget1, chosenCharacters);

            chosenCharacters.Clear();
        }
        else
        {
            situation.questString = situation.quest.questString1 + " ";
            situation.questString += ChooseQuestTarget(situation, situation.quest.possibleTarget1, chosenCharacters);

            situation.questString += " " + situation.quest.questString2 + " ";
            situation.questString += ChooseQuestTarget(situation, situation.quest.possibleTarget2, chosenCharacters);

            chosenCharacters.Clear();
        }
    }

    private string ChooseQuestTarget(Situation situation, string[] possibleTarget, List<string> chosenCharacters)
    {
        while (true)
        {
            string desiredTarget = possibleTarget[Random.Range(0, possibleTarget.Length)];
            string target = null;

            Character[] suitableCharacters = null;

            switch (desiredTarget)
            {
                case "man":
                    suitableCharacters = Array.FindAll(situation.characters, element => element.typeOfCharacter == "man");
                    break;
                case "god":
                    suitableCharacters = Array.FindAll(situation.characters, element => element.typeOfCharacter == "god");
                    break;
                case "object":
                    suitableCharacters = Array.FindAll(situation.characters, element => element.typeOfCharacter == "object");
                    break;
                case "fact":
                    suitableCharacters = Array.FindAll(situation.characters, element => element.typeOfCharacter == "fact");
                    break;                    
                default:
                    target = null;
                    break;
            }

            if (suitableCharacters.Length <= 0)
                suitableCharacters = null;

            else if (suitableCharacters.Length > 0)
            {
                target = suitableCharacters[Random.Range(0, suitableCharacters.Length)].name;

                if (!chosenCharacters.Contains(target))
                {
                    chosenCharacters.Add(target);
                    return target;
                }
            }
        }
    }

    public class QuestCreator 
    {
        private enum QuestType
        {
            Kill,
            Delivery,
            Gather,
            Escort,
            Syntax
        }

        private static System.Random random = new System.Random();

        public static string ChooseQuestType(QuestList questList, Situation situation)
        {
            Array values = Enum.GetValues(typeof(QuestType));

            while (true)
            {
                QuestType questType = (QuestType)values.GetValue(random.Next(values.Length));
                situation.questType = questType.ToString();
                Quest quest = Array.Find(questList.quest, element => element.name == situation.questType);

                bool possibleTarget1found = false;
                bool possibleTarget2found = false;

                foreach (var target in quest.possibleTarget1)
                {
                    foreach (var character in situation.characters)
                    {
                        if (target == character.typeOfCharacter)
                        {
                            possibleTarget1found = true;
                        }
                    }
                }

                foreach (var target in quest.possibleTarget2)
                {
                    foreach (var character in situation.characters)
                    {
                        if (target == character.typeOfCharacter)
                        {
                            possibleTarget2found = true;
                        }
                    }
                }

                if (possibleTarget1found && possibleTarget2found)
                {
                    return questType.ToString();
                }
            }            
        }
    }
}


