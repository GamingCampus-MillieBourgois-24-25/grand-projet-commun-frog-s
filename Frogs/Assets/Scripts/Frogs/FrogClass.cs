using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Workshop;

public class FrogClass
{
    private List<string> possibleFirstName = new List<string>
    {
        "Croaky", "Bubbles", "Hoppy", "Lolly", "Toadette", "Ribbit", "Warty", "Splash",
        "Zippy", "Puddle", "Jumpster", "Twiggy", "Pippin", "Skipper", "Fizz"
    };

    private List<string> possibleLastName = new List<string>
    {
        "Léapfrog", "Bogwart", "Pondington", "Frogsworth", "Toadstone", "Slimey", "Ribbiton",
        "Lilirip", "Hopsalot", "Wartsworth", "Croakwell", "Jumpington", "Swampington", "Hopscotch", "Toadcliff"
    };

    private FrogStats stats;
    private string name;
    private BaseWorkshop fregWorkshop;
    
    public FrogClass(){
        stats = new FrogStats();
        string first = possibleFirstName[UnityEngine.Random.Range(0, possibleFirstName.Count)];
        string last = possibleLastName[UnityEngine.Random.Range(0, possibleLastName.Count)];
        name = $"{first} {last}";
        ShowStats();
    }

    public FrogClass(string Name,int Strength, int Endurance, int Creativite, int Intelligence){
        name = Name;
        stats = new FrogStats(Strength,Endurance,Creativite,Intelligence);
        ShowStats();
    }

    void ShowStats(){
        string result = "";
        foreach (KeyValuePair<string, int> entry in stats.GetStats())
        {
            result += entry.Key + ": " + entry.Value + " | ";  // Format clé: valeur
        }

        // Enlever le dernier " | " (séparateur)
        if (result.Length > 0)
            result = result.Substring(0, result.Length - 3);

        // Afficher le résultat dans la console
        Debug.Log($"{name} : {result}");
    }

    
    
}
