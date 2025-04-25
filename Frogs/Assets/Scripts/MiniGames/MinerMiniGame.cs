using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGames
{
    public class MinerMiniGame : BaseMiniGames
    {
        [Header("UI Elements")]
        [SerializeField] private Button crystalButton;
        [SerializeField] private Image crystalImage;
        [SerializeField] private TextMeshProUGUI clickCounterText;
        [SerializeField] private Image timerFillImage;
        [SerializeField] private GameObject successMessage;
        [SerializeField] private GameObject failMessage;

        [Header("Crystal Sprites")]
        [SerializeField] private Sprite[] crystalStages;

        [Header("Settings")]
        [SerializeField] private int targetClicks = 30;
        [SerializeField] private float gameDuration = 10f;

        private int currentClicks = 0;
        private float currentTime = 0f;
        private bool isGameActive = true;

        private int stageThreshold;
        private int currentStage = 0;

        private new void Start()
        {
            GoldMultiplier = 3f;
            base.Start();

            crystalButton.onClick.AddListener(ClickCrystal);
            currentTime = gameDuration;

            stageThreshold = Mathf.Max(1, targetClicks / 3);

            if (crystalStages.Length > 0 && crystalImage != null)
                crystalImage.sprite = crystalStages[0];
        }

        private new void Update()
        {
            base.Update();

            if (!isGameActive) return;

            currentTime -= Time.deltaTime;
            if (timerFillImage != null)
                timerFillImage.fillAmount = currentTime / gameDuration;

            if (currentTime <= 0)
            {
                EndGame();
            }
        }

        private void ClickCrystal()
        {
            if (!isGameActive) return;

            currentClicks++;
            clickCounterText.text = $"Clics : {currentClicks}";

            int newStage = Mathf.Min(2, currentClicks / stageThreshold);
            if (newStage > currentStage)
            {
                currentStage = newStage;
                if (crystalStages.Length > currentStage && crystalImage != null)
                {
                    crystalImage.sprite = crystalStages[currentStage];
                }
            }
        }

        private void EndGame()
        {
            isGameActive = false;

            if (currentClicks >= targetClicks)
            {
                successMessage.SetActive(true);
                HasWin = true;
                Debug.Log("✅ MINI-JEU RÉUSSI : Boost activé pour les bâtiments Miner !");
            }
            else
            {
                failMessage.SetActive(true);
                HasWin = false;
                Debug.Log("❌ MINI-JEU RATÉ : Aucun boost activé.");
            }

            Invoke(nameof(CloseMiniGame), 5f);
        }
    }
}
