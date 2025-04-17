using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MarketButtonUpdater : MonoBehaviour
{
    [System.Serializable]
    public class BuildingData
    {
        public string name;
        public GameObject prefab;
        public int basePrice = 10;
        [HideInInspector] public int currentPrice;
        [HideInInspector] public Button button;
        [HideInInspector] public TextMeshProUGUI priceText;
    }

    public List<BuildingData> buildings;
    public GameObject buttonPrefab;
    public Transform buttonContainer;

    private void Start()
    {
        foreach (var b in buildings)
            b.currentPrice = b.basePrice;

        GenerateButtons();
        InvokeRepeating(nameof(UpdateButtonStates), 0f, 0.3f);
    }

    void GenerateButtons()
    {
        foreach (var b in buildings)
        {
            var obj = Instantiate(buttonPrefab, buttonContainer);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = b.name;

            var priceText = obj.transform.Find("PriceText")?.GetComponent<TextMeshProUGUI>();
            if (priceText != null) priceText.text = b.basePrice + "G";

            var button = obj.GetComponent<Button>();
            b.button = button;
            b.priceText = priceText;

            button.onClick.AddListener(() =>
            {
                if (GameManagerInstance().GetGolds() >= b.currentPrice)
                {
                    GameManagerInstance().RemoveGolds(b.currentPrice);
                    Instantiate(b.prefab); // Ajoute ta logique de placement ici
                    b.currentPrice *= 5;
                    if (b.priceText != null) b.priceText.text = b.currentPrice + "G";
                }
            });
        }
    }

    void UpdateButtonStates()
    {
        int gold = GameManagerInstance().GetGolds();
        foreach (var b in buildings)
        {
            bool canBuy = gold >= b.currentPrice;
            b.button.interactable = canBuy;

            var colors = b.button.colors;
            colors.normalColor = canBuy ? Color.white : Color.gray;
            b.button.colors = colors;
        }
    }

    GameManager GameManagerInstance()
    {
        return FindObjectOfType<GameManager>();
    }
}
