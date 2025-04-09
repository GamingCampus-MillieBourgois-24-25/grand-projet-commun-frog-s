using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Workshop;

public class MarketplaceUIManager : MonoBehaviour
{
    [Header("Bouton Prefab")]
    [SerializeField] private GameObject buildingButtonPrefab;

    [Header("Noms des Ateliers")]
    [SerializeField] private List<string> workshopNames = new List<string>();

    [Header("Prefabs des Ateliers")]
    [SerializeField] private List<GameObject> workshopPrefabs = new List<GameObject>();

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

    void Update()
    {
        if (!gameObject.activeSelf) return;

#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0))
        {
            if (!RectTransformUtility.RectangleContainsScreenPoint(panelToSlide, Input.mousePosition, Camera.main))
            {
                Close();
            }
        }
#else
    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
    {
        Vector2 touchPos = Input.GetTouch(0).position;
        if (!RectTransformUtility.RectangleContainsScreenPoint(panelToSlide, touchPos, Camera.main))
        {
            Close();
        }
    }
#endif
    }


    public void Open(PlacementPreset placement)
    {
        currentPlacement = placement;

        foreach (Transform child in buttonContainer)
            Destroy(child.gameObject);

        for (int i = 0; i < Mathf.Min(workshopNames.Count, workshopPrefabs.Count); i++)
        {
            AddButton(workshopNames[i], workshopPrefabs[i]);
        }

        gameObject.SetActive(true);
        StartCoroutine(SlideUp());
        //PlayPopScale(); // si tu veux ajouter l'effet "pop"
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

        rt.sizeDelta = new Vector2(rt.sizeDelta.x, targetHeight);
    }

    public void Close()
    {
        StartCoroutine(SlideDown());
    }

    IEnumerator SlideDown()
    {
        RectTransform rt = panelToSlide;
        float elapsed = 0f;
        float startHeight = rt.sizeDelta.y;
        float endHeight = 0f;

        while (elapsed < slideDuration)
        {
            elapsed += Time.deltaTime;
            float newHeight = Mathf.SmoothStep(startHeight, endHeight, elapsed / slideDuration);
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, newHeight);
            yield return null;
        }

        rt.sizeDelta = new Vector2(rt.sizeDelta.x, 0);
        gameObject.SetActive(false);
    }
}





















/*//-------POP SCALE TRANSITION----------//
public void PlayPopScale()
{
    panelToSlide.localScale = Vector3.zero;
    StartCoroutine(PopScaleCoroutine());
}

IEnumerator PopScaleCoroutine()
{
    float duration = 0.2f;
    float t = 0;
    while (t < duration)
    {
        t += Time.deltaTime;
        float scale = Mathf.SmoothStep(0f, 1.1f, t / duration); // petit dépassement pour l’effet "pop"
        panelToSlide.localScale = new Vector3(scale, scale, 1f);
        yield return null;
    }

    panelToSlide.localScale = new Vector3(1f, 1f, 1f);
}*/