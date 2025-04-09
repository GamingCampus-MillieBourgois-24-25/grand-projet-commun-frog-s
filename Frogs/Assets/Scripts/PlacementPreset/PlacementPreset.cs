using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacementPreset : MonoBehaviour
{
    public void PlaceBuilding(GameObject prefab)
    {
        Instantiate(prefab, transform.position, prefab.transform.rotation);
        Destroy(gameObject);
    }

    public void OpenMarketPlace()
    {
        if (MarketplaceUIManager.Instance == null)
        {
            Debug.LogError("MarketplaceUIManager.Instance is null! Assure-toi qu’il est présent dans la scène.");
            return;
        }

        MarketplaceUIManager.Instance.Open(this);
    }

}


