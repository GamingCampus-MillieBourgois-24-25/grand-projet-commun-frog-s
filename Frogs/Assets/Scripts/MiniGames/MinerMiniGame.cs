using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGames
{
    public class MinerMiniGame : BaseMiniGames
    {
        [Header("UI Elements")]
        [SerializeField] private Button crystalButton;
        [SerializeField] private TextMeshProUGUI clickCounterText;
        [SerializeField] private Image timerFillImage;
        [SerializeField] private GameObject successMessage;
        [SerializeField] private GameObject failMessage;

        [Header("Settings")]
        [SerializeField] private int targetClicks = 30;
        [SerializeField] private float gameDuration = 10f;

        private int currentClicks = 0;
        private float currentTime = 0f;
        private bool isGameActive = true;

        private new void Start()
        {
            GoldMultiplier = 3f;
            base.Start();

            crystalButton.onClick.AddListener(ClickCrystal);
            currentTime = gameDuration;
        }

        private new void Update()
        {
            base.Update();

            if (!isGameActive) return;

            currentTime -= Time.deltaTime;
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
        }

        private void EndGame()
        {
            isGameActive = false;

            if (currentClicks >= targetClicks)
            {
                successMessage.SetActive(true);
                HasWin = true;
                Debug.Log(" MINI-JEU RÉUSSI : Boost activé pour les bâtiments Miner !");
            }
            else
            {
                failMessage.SetActive(true);
                HasWin = false;
                Debug.Log(" MINI-JEU RATÉ : Aucun boost activé.");
            }

            Invoke(nameof(CloseMiniGame), 5f);
        }

    }
}
