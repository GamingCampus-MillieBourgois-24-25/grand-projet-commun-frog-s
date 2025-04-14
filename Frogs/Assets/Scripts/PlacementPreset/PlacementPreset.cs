using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacementPreset : MonoBehaviour
{
    [SerializeField] private GameObject BuildingToPlace;

    public void PlaceBuilding(){
        Debug.Log("Clique");
        Instantiate(BuildingToPlace, gameObject.transform.position, BuildingToPlace.transform.rotation);
        Destroy(gameObject);
    }
}
