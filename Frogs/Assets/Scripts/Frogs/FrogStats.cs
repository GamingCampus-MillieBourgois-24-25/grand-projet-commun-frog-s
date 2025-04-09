using System;
using System.Collections.Generic;
using UnityEngine;

public class FrogStats
{
    private Dictionary<string, int> StatMap = new Dictionary<string, int>();

    public FrogStats()
    {
        StatMap = new Dictionary<string, int>
        {
            { "Strength", 0 },
            { "Endurance", 0 },
            { "Creativity", 0 },
            { "Intelligence", 0 }
        };

        System.Random random = new System.Random();
        int totalPoints = random.Next(7, 13);
        int[] points = new int[4];

        // 1. Distribution initiale égale des points
        int basePoints = totalPoints / points.Length;
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = basePoints;
        }

        // 2. Répartition des points restants de manière aléatoire mais modérée
        int remainingPoints = totalPoints - (basePoints * points.Length);
        while (remainingPoints > 0)
        {
            // Distribution aléatoire des points restants
            int randomIndex = random.Next(0, points.Length);
            
            // Distribution d'un point supplémentaire à la statistique sélectionnée
            points[randomIndex]++;
            remainingPoints--;
        }

        // 3. Assigner les points aux statistiques
        StatMap["Strength"] = points[0];
        StatMap["Endurance"] = points[1];
        StatMap["Creativity"] = points[2];
        StatMap["Intelligence"] = points[3];
    }



    public FrogStats(int Strength, int Endurance, int Creativite, int Intelligence)
    {
        StatMap = new Dictionary<string, int>
        {
            { "Strength", Strength },
            { "Endurance", Endurance },
            { "Creativity", Creativite },
            { "Intelligence", Intelligence }
        };
    }

    public Dictionary<string, int> GetStats(){
        return StatMap;
    }
    public int GetStat(string statName){
        if(StatMap.ContainsKey(statName)){
            return StatMap[statName];
        }
        Console.WriteLine($"Erreur : No stat named {statName}");
        return 0;
    }
    public void SetStat(string statName, int newValue){
        if(StatMap.ContainsKey(statName)){
            StatMap[statName] = newValue;
        }
        Console.WriteLine($"Erreur : No stat named {statName}");
    }
}
