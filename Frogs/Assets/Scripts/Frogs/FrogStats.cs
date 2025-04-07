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
        int totalPoints = random.Next(8, 11);
        int remainingPoints = totalPoints;
        int[] points = new int[4];

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = random.Next(0, remainingPoints + 1);
            remainingPoints -= points[i];
        }

        for (int i = 0; remainingPoints > 0; i = (i + 1) % points.Length)
        {
            points[i]++;
            remainingPoints--;
        }

        StatMap["Strength"] = points[0];
        StatMap["Endurance"] = points[1];
        StatMap["Creativity"] = points[2];
        StatMap["Intelligence"] = points[3];
    }

    public FrogStats(int Strength, int Endurance, int creativite, int Intelligence)
    {
        StatMap = new Dictionary<string, int>
        {
            { "Strength", Strength },
            { "Endurance", Endurance },
            { "Creativity", creativite },
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
