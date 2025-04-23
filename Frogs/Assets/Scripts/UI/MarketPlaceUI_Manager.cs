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

    [Header("Sprites des b�timents")]
    [SerializeField] private List<Sprite> buildingIcons = new List<Sprite>();

    [Header("Prefabs des Ateliers")]
    [SerializeField] private List<GameObject> workshopPrefabs = new List<GameObject>();

    [Header("Prix UI")]
    [SerializeField] private TextMeshProUGUI currentPriceText;

    [Header("Parent des boutons")]
    [SerializeField] private Transform buttonContainer;

    [Header("Slide Settings")]
    [SerializeField] private RectTransform panelToSlide;
    [SerializeField] private float slideDuration = 0.5f;
    [SerializeField] private float targetHeight = 300f;

    public static MarketplaceUIManager Instance { get; private set; }

    private PlacementPreset currentPlacement;
    private int currentGlobalPrice = 10;
    private List<Button> instantiatedButtons = new List<Button>();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        gameObject.SetActive(false);
        UpdatePriceUI();
    }

    void Update()
    {
        UpdateButtonsInteractable();
    }

    public void Open(PlacementPreset placement)
    {
        currentPlacement = placement;

        foreach (Transform child in buttonContainer)
            Destroy(child.gameObject);
        instantiatedButtons.Clear();

        for (int i = 0; i < Mathf.Min(workshopNames.Count, workshopPrefabs.Count); i++)
        {
            AddButton(workshopNames[i], workshopPrefabs[i]);
        }

        gameObject.SetActive(true);
        StartCoroutine(SlideUp());
    }

    void AddButton(string label, GameObject prefab)
    {
        var buttonObj = Instantiate(buildingButtonPrefab, buttonContainer);
        //buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = label;

        var image = buttonObj.GetComponentInChildren<Image>();
        int index = instantiatedButtons.Count;
        if (image != null && index < buildingIcons.Count)
            image.sprite = buildingIcons[index];

        var button = buttonObj.GetComponent<Button>();
        instantiatedButtons.Add(button);

        button.onClick.AddListener(() =>
        {
            if (GameManagerInstance().GetGolds() >= currentGlobalPrice)
            {
                GameManagerInstance().RemoveGolds(currentGlobalPrice);
                UpgratePrice();
                UpdatePriceUI();
                UpdateButtonsInteractable();
                currentPlacement.PlaceBuilding(prefab);
                gameObject.SetActive(false);
            }
        });

        UpdateButtonsInteractable();
    }

    public void UpgratePrice(){
        currentGlobalPrice *= 5;
    }


    void UpdateButtonsInteractable()
    {
        int gold = GameManagerInstance().GetGolds();

        foreach (var btn in instantiatedButtons)
        {
            btn.interactable = gold >= currentGlobalPrice;

            var colors = btn.colors;
            colors.normalColor = gold >= currentGlobalPrice ? Color.white : Color.gray;
            btn.colors = colors;
        }
    }

    void UpdatePriceUI()
    {
        if (currentPriceText != null)
        {
            currentPriceText.text = $"{currentGlobalPrice}G";
        }
    }

    GameManager GameManagerInstance()
    {
        return FindObjectOfType<GameManager>();
    }

    IEnumerator SlideUp()
    {
        RectTransform rt = panelToSlide;
        float elapsed = 0f;
        float startY = -targetHeight;  // d�part en dessous de l��cran
        float targetY = 0f;

        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, startY);
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, targetHeight);

        while (elapsed < slideDuration)
        {
            elapsed += Time.deltaTime;
            float y = Mathf.SmoothStep(startY, targetY, elapsed / slideDuration);
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, y);
            yield return null;
        }

        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, targetY);
    }


    public void Close()
    {
        StartCoroutine(SlideDown());
    }

    IEnumerator SlideDown()
    {
        RectTransform rt = panelToSlide;
        float elapsed = 0f;
        float startY = rt.anchoredPosition.y;
        float endY = -targetHeight;

        while (elapsed < slideDuration)
        {
            elapsed += Time.deltaTime;
            float y = Mathf.SmoothStep(startY, endY, elapsed / slideDuration);
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, y);
            yield return null;
        }

        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, endY);
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
        float scale = Mathf.SmoothStep(0f, 1.1f, t / duration); // petit d�passement pour l�effet "pop"
        panelToSlide.localScale = new Vector3(scale, scale, 1f);
        yield return null;
    }

    panelToSlide.localScale = new Vector3(1f, 1f, 1f);
}*/