using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Workshop;

public class PlacementPreset : MonoBehaviour
{
    private Canvas canvas;
    public void PlaceBuilding(GameObject prefab)
    {
        GameObject Workshop = Instantiate(prefab, transform.position, prefab.transform.rotation, transform);
        FindAnyObjectByType<FrogColorManager>().SetRandomFrogColor(Workshop.GetComponent<BaseWorkshop>());
        FindAnyObjectByType<SaveManager>().SaveGame();
        //Destroy(gameObject);

        BaseWorkshop workshop = Workshop.GetComponent<BaseWorkshop>();
        workshop.SetPlacementParent(this);

        canvas = GetComponentInChildren<Canvas>();
        if (canvas != null)
        {
            canvas.gameObject.SetActive(false);
        }


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

    public void ActivateBack()
    {
        Debug.Log("ActivateBack");
        //GetComponentInChildren<Canvas>().gameObject.SetActive(true);
        canvas.gameObject.SetActive(true);
    }
}

