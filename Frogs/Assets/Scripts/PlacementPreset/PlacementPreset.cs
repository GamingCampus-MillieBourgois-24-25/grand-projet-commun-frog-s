using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacementPreset : MonoBehaviour
{
    public void PlaceBuilding(GameObject prefab)
    {
        Instantiate(prefab, transform.position, prefab.transform.rotation);
        FindAnyObjectByType<SaveManager>().SaveGame();
        Destroy(gameObject);
    }

    public void OpenMarketPlace()
    {
        if (MarketplaceUIManager.Instance == null)
        {
            Debug.LogError("MarketplaceUIManager.Instance is null! Assure-toi qu�il est pr�sent dans la sc�ne.");
            return;
        }

        MarketplaceUIManager.Instance.Open(this);
    }

}
