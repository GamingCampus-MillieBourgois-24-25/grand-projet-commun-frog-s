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
    public int placementID;
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

        List<BaseWorkshop> placedWorkshops = new List<BaseWorkshop>(FindObjectsByType<BaseWorkshop>(FindObjectsSortMode.None));
        foreach (BaseWorkshop work in placedWorkshops)
        {
            BuildingData buildingData = new BuildingData();
            buildingData.buildingType = work.workshopType;
            buildingData.position = work.transform.position;
            buildingData.frogColor = work.ColorFrog;

            PlacementPreset placement = work.GetComponentInParent<PlacementPreset>();
            if (placement != null)
            {
                buildingData.placementID = placement.placementID;
            }

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

            GameManager gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            gameManager.SetGolds(data.gold);

            PlacementPreset[] placements = FindObjectsByType<PlacementPreset>(FindObjectsSortMode.None);

            foreach (BuildingData buildingData in data.buildings)
            {
                PlacementPreset placement = null;

                foreach (var p in placements)
                {
                    if (p.placementID == buildingData.placementID)
                    {
                        placement = p;
                        break;
                    }
                }

                if (placement != null)
                {
                    GameObject BuildingToSpawn = GetBuildingByType(buildingData.buildingType);
                    if (BuildingToSpawn != null)
                    {
                        GameObject Workshop = Instantiate(BuildingToSpawn, placement.transform.position, BuildingToSpawn.transform.rotation, placement.transform);
                        CorlorManager.ApplyFrogColor(Workshop.GetComponent<BaseWorkshop>(), buildingData.frogColor);
                        UIManager.UpgratePrice();

                        
                        Canvas placementCanvas = placement.GetComponentInChildren<Canvas>();
                        if (placementCanvas != null)
                        {
                            placementCanvas.gameObject.SetActive(false);
                        }
                    }
                }
                else
                {
                    Debug.LogWarning($"PlacementPreset avec placementID {buildingData.placementID} non trouvé !");
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
