using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Workshop;
using TMPro;

public class MarketplaceUIManager : MonoBehaviour
{
    [Header("Bouton Prefab")]
    [SerializeField] private GameObject buildingButtonPrefab;

    [Header("Liste des Ateliers")]
    [SerializeField] private GameObject blacksmithPrefab;
    [SerializeField] private GameObject lumberjackPrefab;
    [SerializeField] private GameObject minerPrefab;
    public static MarketplaceUIManager Instance { get; private set; }


    [Header("Parent des boutons")]
    [SerializeField] private Transform buttonContainer;

    [Header("Slide Settings")]
    [SerializeField] private RectTransform panelToSlide;
    [SerializeField] private float slideDuration = 0.5f;
    [SerializeField] private float targetHeight = 300f;

    private PlacementPreset currentPlacement;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        Debug.Log("MarketplaceUIManager initialized");
    }



    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Open(PlacementPreset placement)
    {
        currentPlacement = placement;

        // Clear anciens boutons
        foreach (Transform child in buttonContainer)
        {
            Destroy(child.gameObject);
        }

        AddButton("Blacksmith", blacksmithPrefab);
        AddButton("Lumberjack", lumberjackPrefab);
        AddButton("Miner", minerPrefab);

        gameObject.SetActive(true);
        StartCoroutine(SlideUp());
    }

    void AddButton(string label, GameObject prefab)
    {
        var buttonObj = Instantiate(buildingButtonPrefab, buttonContainer);
        buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = label;
        buttonObj.GetComponent<Button>().onClick.AddListener(() =>
        {
            currentPlacement.PlaceBuilding(prefab);
            gameObject.SetActive(false);
        });
    }


    IEnumerator SlideUp()
    {
        RectTransform rt = panelToSlide;
        float elapsed = 0f;
        float startHeight = 0f;

        while (elapsed < slideDuration)
        {
            elapsed += Time.deltaTime;
            float newHeight = Mathf.SmoothStep(startHeight, targetHeight, elapsed / slideDuration);
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, newHeight);
            yield return null;
        }

        rt.sizeDelta = new Vector2(rt.sizeDelta.x, targetHeight); // Sécurité
    }

}
