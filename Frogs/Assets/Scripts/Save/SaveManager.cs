using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Workshop;

[System.Serializable]
public class SaveData
{
    public int gold;
    public List<BuildingData> buildings = new List<BuildingData>();
}

[System.Serializable]
public class BuildingData
{
    public WorkshopType buildingType;
    public Vector3 position;

    public FrogColor frogColor;
}

[System.Serializable]
    public struct BuildingEntry
    {
        public WorkshopType buildingType;
        public GameObject buildingPrefab;
    }

public class SaveManager : MonoBehaviour
{
    private string savePath;

    [SerializeField] List<BuildingEntry> buildingList;
    [SerializeField] List<GameObject> ZonesPrefab;
    [SerializeField] MarketplaceUIManager UIManager;
    [SerializeField] FrogColorManager CorlorManager;

    private void Awake()
    {
        savePath = Application.persistentDataPath + "/savefile.json";
    }

    void Start(){
        LoadGame();
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.gold = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GetGolds();
        List<BaseWorkshop> placedWorkshops = FindObjectsByType<BaseWorkshop>(FindObjectsSortMode.None).ToList();
        foreach (BaseWorkshop work in placedWorkshops)
        {
            BuildingData buildingData = new BuildingData();
            buildingData.buildingType = work.workshopType;
            buildingData.position = work.transform.position;
            buildingData.frogColor = work.ColorFrog;
            data.buildings.Add(buildingData);
        }
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
    }

    public void LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().SetGolds(data.gold);
            foreach(GameObject Zone in ZonesPrefab){
                foreach(BuildingData buildingData in data.buildings){
                    if(buildingData.position == Zone.transform.position){
                        GameObject BuildingToSpawn = GetBuildingByType(buildingData.buildingType);
                        Debug.Log(BuildingToSpawn.name);
                        GameObject Workshop = Instantiate(BuildingToSpawn, Zone.transform.position, BuildingToSpawn.transform.rotation);
                        CorlorManager.ApplyFrogColor(Workshop.GetComponent<BaseWorkshop>(), buildingData.frogColor);
                        Destroy(Zone);
                        UIManager.UpgratePrice();
                        break;
                    }
                }
            }
        }
        FindAnyObjectByType<GameManager>().StartPassiveGeneration();
    }

    GameObject GetBuildingByType(WorkshopType buildingType)
    {
        foreach (var entry in buildingList)
        {
            if (entry.buildingType == buildingType)
            {
                return entry.buildingPrefab;
            }
        }
        return null;
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveGame();
        }
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
