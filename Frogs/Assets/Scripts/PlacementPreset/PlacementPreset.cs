using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacementPreset : MonoBehaviour
{
    [SerializeField] private GameObject BuildingToPlace;
    // Start is called before the first frame update
    
    public void PlaceBuilding(){
        Debug.Log("Clique");
        Instantiate(BuildingToPlace, gameObject.transform.position, gameObject.transform.rotation);
    }
}
