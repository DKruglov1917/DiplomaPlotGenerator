using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotGeneratorData : MonoBehaviour
{
     public static string[] quests = new string[7]
    {
            "Kill",
            "Combo",
            "Delivery",
            "Gather",
            "Escort",
            "Syntax",
            "Hybrid"
    };

    public static string[] situations = new string[36]
    {
                "Supplication", "Deliverance", "Crime pursued by vengeance",
                "Vengeance taken for kin upon kin", "Pursuit", "Disaster",
                "Falling prey to cruelty/misfortune", "Revolt", "Daring enterprise",
                "Abduction", "The enigma", "Obtaining",
                "Enmity of kin", "Rivalry of kin", "Murderous adultery",
                "Madness", "Fatal imprudence", "Involuntary crimes of love",
                "Slaying of kin unrecognized", "Self-sacrifice for an ideal", "Self-sacrifice for kin",
                "All sacrificed for passion", "Necessity of sacrificing loved ones", "Rivalry of superior vs. inferior",
                "Adultery", "Crimes of love", "Discovery of the dishonour of a loved one",
                "Obstacles to love", "An enemy loved", "Ambition",
                "Conflict with a god", "Mistaken jealousy", "Erroneous judgment",
                "Remorse", "Recovery of a lost one", "Loss of loved ones"
    };

    public static string[][] stories = new string[36][]
        {
            new string[]{ "The suppliant appeals to the power in authority for deliverance from the persecutor."},
            new string[]{ "The unfortunate has caused a conflict, and the threatener is to carry out justice, but the rescuer saves the unfortunate."},
            new string[]{ "The criminal commits a crime that will not see justice, so the avenger seeks justice by punishing the criminal."},
            new string[]{ "Two entities, the Guilty and the Avenging Kinsmen, are put into conflict over wrongdoing to the Victim, who is allied to both."},
            new string[]{ "The fugitive flees punishment for a misunderstood conflict."},
            new string[]{ "The vanquished power falls from their place after being defeated by the victorious enemy or being informed of such a defeat by the messenger."},
            new string[]{ "The unfortunate suffers from misfortune and/or at the hands of the master."},
            new string[]{ "The tyrant, a cruel power, is plotted against by the conspirator."},
            new string[]{ "The bold leader takes the object from the adversary by overpowering the adversary."},
            new string[]{ "The abductor takes the abducted from the guardian."},

            new string[]{ "The interrogator poses a problem to the seeker and gives a seeker better ability to reach the seeker's goals."},
            new string[]{ "The solicitor is at odds with the adversary who refuses to give the solicitor an object in the possession of the adversary"},
            new string[]{ "The Malevolent Kinsman and the Hated or a second Malevolent Kinsman conspire together."},
            new string[]{ "The Object of Rivalry chooses the Preferred Kinsman over the Rejected Kinsman."},
            new string[]{ "Two Adulterers conspire to kill the Betrayed Spouse."},
            new string[]{ "The Madman goes insane and wrongs the Victim."},
            new string[]{ "The Imprudent, by neglect or ignorance, loses the Object Lost or wrongs the Victim."},
            new string[]{ "The Lover and the Beloved have unknowingly broken a taboo through their romantic relationship, and the Revealer reveals this to them."},
            new string[]{ "The Slayer kills the Unrecognized Victim."},
            new string[]{ "The Hero sacrifices the Person or Thing for their Ideal, which is then taken by the Creditor."},

            new string[]{ "The Hero sacrifices a Person or Thing for their Kinsman, which is then taken by the Creditor."},
            new string[]{ "A Lover sacrifices a Person for the Object of their Passion, which is then lost forever."},
            new string[]{ "The Hero wrongs the Beloved Victim because of the Necessity for their Sacrifice."},
            new string[]{ "An Inferior Rival bests a Superior Rival and wins the Object of Rivalry."},
            new string[]{ "Two Adulterers conspire against the Deceived Spouse."},
            new string[]{ "A Lover and the Beloved break a taboo by initiating a romantic relationship."},
            new string[]{ "The Discoverer discovers the wrongdoing committed by the Guilty One."},
            new string[]{ "Two Lovers face an Obstacle together."},
            new string[]{ "The allied Lover and Hater have diametrically opposed attitudes towards the Beloved Enemy."},
            new string[]{ "The Ambitious Person seeks the Thing Coveted and is opposed by the Adversary."},

            new string[]{ "The Mortal and the Immortal enter a conflict."},
            new string[]{ "The Jealous One falls victim to the Author of the Mistake and becomes jealous of the Object and becomes conflicted with the Supposed Accomplice."},
            new string[]{ "The Mistaken One falls victim to the Author of the Mistake and passes judgment against the Victim of the Mistake when it should be passed against the Guilty One instead."},
            new string[]{ "The Culprit wrongs the Victim or commits the Sin, and is at odds with the Interrogator who seeks to understand the situation."},
            new string[]{ "The Seeker finds the One Found."},
            new string[]{ "The killing of the Kinsman Slain by the Executioner is witnessed by the Kinsman." }
        };

    public static string[][] characters = new string[36][]
    {
                new string[]{ "suppliant", "power in authority", "persecutor"},
                new string[] { "unfortunate", "threatener", "rescuer" },
                new string[] { "criminal", "avenger" },

                new string[]{ "Guilty Kinsman", "Avenging Kinsman",
                              "remembrance of the Victim" },
                new string[] { "punishment", "fugitive" },
                new string[] { "vanquished power", "victorious enemy" },

                new string[] { "unfortunate", "master" },
                new string[] { "tyrant", "conspirator" },
                new string[] { "bold leader", "object", "adversary" },

                new string[] { "abductor", "abducted", "guardian" },
                new string[] { "problem", "interrogator", "seeker" },
                new string[] { "arbitrator", "opposing parties" },

                new string[] { "Malevolent Kinsman", "Hated" },
                new string[]{ "Preferred Kinsman", "Rejected Kinsman",
                              "Object of Rivalry" },
                new string[] { "first Adulterer", "second Adulterer", "Betrayed Spouse" },

                new string[] { "Madman", "Victim" },
                new string[] { "Imprudent", "Victim" },
                new string[] { "Lover", "Beloved", "Revealer" },

                new string[] { "Slayer", "Unrecognized Victim" },
                new string[] { "Hero", "Ideal", "Creditor" },
                new string[] { "Hero", "Kinsman", "Person/Thing sacrificed" },

                new string[]{ "Lover", "Object of fatal Passion",
                              "Thing sacrificed" },
                new string[]{ "Hero", "Beloved Victim",
                              "Necessity for the Sacrifice" },
                new string[]{ "Superior Rival", "Inferior Rival",
                              "Object of Rivalry" },

                new string[] { "first Adulterer", "second Adulterer", "Deceived Spouse" },
                new string[] { "Lover", "Beloved" },
                new string[] { "Discoverer", "Guilty One" },

                new string[] { "first Lover", "second Lover", "Obstacle" },
                new string[] { "Lover", "Beloved Enemy", "Hater" },
                new string[] { "Ambitious Person", "Thing Coveted", "Adversary" },

                new string[] { "Mortal", "Immortal" },
                new string[]{ "Jealous One", "Object of whose Possession He is Jealous",
                              "Supposed Accomplice", "Cause"},
                new string[]{ "Mistaken One", "Victim of the Mistake",
                              "Cause", "the Guilty One"},

                new string[] { "Culprit", "Victim", "Interrogator" },
                new string[] { "Seeker", "One Found" },
                new string[] { "Kinsman Slain", "Kinsman Spectator", "Executioner" },
    };

    private static string[] typeOfCharacter = new string[3] { "Man", "God", "Fact" };

    public Dictionary<string, string> TypeOfCharacterDictionary = new Dictionary<string, string>()
    {
        [characters[0][0]] = typeOfCharacter[0],
        [characters[0][1]] = typeOfCharacter[0],
        [characters[0][2]] = typeOfCharacter[0],

        [characters[1][0]] = typeOfCharacter[0],
        [characters[1][1]] = typeOfCharacter[0],
        [characters[1][2]] = typeOfCharacter[0],

        [characters[2][0]] = typeOfCharacter[0],
        [characters[2][1]] = typeOfCharacter[0],

        [characters[3][0]] = typeOfCharacter[0],
        [characters[3][1]] = typeOfCharacter[0],
        [characters[3][2]] = typeOfCharacter[0],

        [characters[4][0]] = typeOfCharacter[2],
        [characters[4][1]] = typeOfCharacter[0],

        [characters[5][0]] = typeOfCharacter[0],
        [characters[5][1]] = typeOfCharacter[0],

        [characters[6][0]] = typeOfCharacter[0],
        [characters[6][1]] = typeOfCharacter[0],

        [characters[7][0]] = typeOfCharacter[0],
        [characters[7][1]] = typeOfCharacter[0],

        [characters[8][0]] = typeOfCharacter[0],
        [characters[8][1]] = typeOfCharacter[2],
        [characters[8][2]] = typeOfCharacter[0],

        [characters[9][0]] = typeOfCharacter[0],
        [characters[9][1]] = typeOfCharacter[0],
        [characters[9][2]] = typeOfCharacter[0],

        [characters[10][0]] = typeOfCharacter[0],
        [characters[10][1]] = typeOfCharacter[0],
        [characters[10][2]] = typeOfCharacter[0],

        [characters[11][0]] = typeOfCharacter[0],
        [characters[11][1]] = typeOfCharacter[0],

        [characters[12][0]] = typeOfCharacter[0],
        [characters[12][1]] = typeOfCharacter[0],

        [characters[13][0]] = typeOfCharacter[0],
        [characters[13][1]] = typeOfCharacter[0],
        [characters[13][2]] = typeOfCharacter[2],

        [characters[14][0]] = typeOfCharacter[0],
        [characters[14][1]] = typeOfCharacter[0],
        [characters[14][2]] = typeOfCharacter[0],

        [characters[15][0]] = typeOfCharacter[0],
        [characters[15][1]] = typeOfCharacter[0],

        [characters[16][0]] = typeOfCharacter[0],
        [characters[16][1]] = typeOfCharacter[0],

        [characters[17][0]] = typeOfCharacter[0],
        [characters[17][1]] = typeOfCharacter[0],
        [characters[17][2]] = typeOfCharacter[0],

        [characters[18][0]] = typeOfCharacter[0],
        [characters[18][1]] = typeOfCharacter[0],

        [characters[19][0]] = typeOfCharacter[0],
        [characters[19][1]] = typeOfCharacter[2],
        [characters[19][2]] = typeOfCharacter[0],

        [characters[20][0]] = typeOfCharacter[0],
        [characters[20][1]] = typeOfCharacter[0],
        [characters[20][2]] = typeOfCharacter[0],

        [characters[21][0]] = typeOfCharacter[0],
        [characters[21][1]] = typeOfCharacter[0],
        [characters[21][2]] = typeOfCharacter[2],

        [characters[22][0]] = typeOfCharacter[0],
        [characters[22][1]] = typeOfCharacter[0],
        [characters[22][2]] = typeOfCharacter[2],

        [characters[23][0]] = typeOfCharacter[0],
        [characters[23][1]] = typeOfCharacter[0],
        [characters[23][2]] = typeOfCharacter[2],

        [characters[24][0]] = typeOfCharacter[0],
        [characters[24][1]] = typeOfCharacter[0],
        [characters[24][2]] = typeOfCharacter[0],

        [characters[25][0]] = typeOfCharacter[0],
        [characters[25][1]] = typeOfCharacter[0],

        [characters[26][0]] = typeOfCharacter[0],
        [characters[26][1]] = typeOfCharacter[0],

        [characters[27][0]] = typeOfCharacter[0],
        [characters[27][1]] = typeOfCharacter[0],
        [characters[27][2]] = typeOfCharacter[2],

        [characters[28][0]] = typeOfCharacter[0],
        [characters[28][1]] = typeOfCharacter[0],
        [characters[28][2]] = typeOfCharacter[0],

        [characters[29][0]] = typeOfCharacter[0],
        [characters[29][1]] = typeOfCharacter[2],
        [characters[29][2]] = typeOfCharacter[0],

        [characters[30][0]] = typeOfCharacter[0],
        [characters[30][1]] = typeOfCharacter[1],

        [characters[31][0]] = typeOfCharacter[0],
        [characters[31][1]] = typeOfCharacter[0],
        [characters[31][2]] = typeOfCharacter[0],
        [characters[31][3]] = typeOfCharacter[2],

        [characters[32][0]] = typeOfCharacter[0],
        [characters[32][1]] = typeOfCharacter[0],
        [characters[32][2]] = typeOfCharacter[2],
        [characters[32][3]] = typeOfCharacter[0],

        [characters[33][0]] = typeOfCharacter[0],
        [characters[33][1]] = typeOfCharacter[0],
        [characters[33][2]] = typeOfCharacter[0],

        [characters[34][0]] = typeOfCharacter[0],
        [characters[34][1]] = typeOfCharacter[0],

        [characters[35][0]] = typeOfCharacter[0],
        [characters[35][1]] = typeOfCharacter[0],
        [characters[35][2]] = typeOfCharacter[0]
    };

    private static string[] genders = new string[3] { "m", "f", "n" };    
}
