using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacementPreset : MonoBehaviour
{
    [SerializeField] private GameObject BuildingToPlace;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if(gameManager.GetMoney() >= 30){
            gameObject.GetComponent<Canvas>().enabled = true;
        }
        else{
            gameObject.GetComponent<Canvas>().enabled = false;
        }
    }

    public void PlaceBuilding(){
        gameManager.RemoveMoney(30);
        Instantiate(BuildingToPlace, gameObject.transform.position, BuildingToPlace.transform.rotation);
        Destroy(gameObject);
    }
}
