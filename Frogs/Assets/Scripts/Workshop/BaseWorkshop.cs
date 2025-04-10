using System.Collections;
using MiniGames;
using UI;
using UnityEngine;

namespace Workshop
{
    public class BaseWorkshop : MonoBehaviour
    {
        [Header("Base Workshop Settings")]
        [SerializeField, HideInInspector] private string uniqueId;
        public string UniqueId => uniqueId;

        [Header("Base Workshop Stats")]
        [SerializeField] protected int level = 1;
        [SerializeField] protected int baseGoldPerCycle = 1;
        [SerializeField] protected int goldPerCycle = 1;
        [SerializeField] protected int goldPricePerLevel = 50;

        [Header("Core")]
        [SerializeField] private GameManager gameManager;
        [SerializeField] private WorkshopUIManager workshopUIManager;
        [SerializeField] protected GameObject miniGamePrefab;
        [SerializeField] protected BaseMiniGames miniGameScript;
        [SerializeField] private float goldMultiplayer = 1f;
        [SerializeField] private float goldTimerMultiplayer = 5f;

        private Coroutine _goldMultiplierCoroutine;
        
        protected void Awake()
        {
            uniqueId = System.Guid.NewGuid().ToString();
        }

        protected void Start()
        {
            StartCoroutine(GenerateGoldCoroutine());
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            workshopUIManager = gameManager.GetWorkshopUIManger();
            miniGameScript = miniGamePrefab.GetComponent<BaseMiniGames>();
            workshopUIManager.GetOnMiniGameCreated().AddListener(OnMiniGameCreated);
        }
        
        protected void Update()
        {
            if (miniGameScript.GetHasWin())
            {
                StartGoldMultiplayer();
                miniGameScript.SetHasWin(false);
            }
            
            if (Input.GetKeyDown(KeyCode.U))
            {
                UpgradeWorkshop();
            }
        }

        protected void OnMouseDown()
        {
            gameManager.ShowWorkshopUI_Manager();
            workshopUIManager.SetMiniGame(miniGamePrefab);
        }
        
        private void OnMiniGameCreated(BaseMiniGames miniGame)
        {
            miniGameScript = miniGame;
            miniGameScript.SetHasWin(false);
        }

        private void UpgradeWorkshop()
        {
            if (gameManager.GetMoney() >= goldPricePerLevel)
            {
                gameManager.RemoveMoney(goldPricePerLevel);
                level++;
                baseGoldPerCycle *= 2;
                goldPricePerLevel *= 2;
            }
        }

        private void StartGoldMultiplayer()
        {
            goldMultiplayer = miniGameScript.GetGoldMultiplier();

            if (_goldMultiplierCoroutine != null)
                StopCoroutine(_goldMultiplierCoroutine);

            _goldMultiplierCoroutine = StartCoroutine(ResetGoldMultiplierAfterDelay(goldTimerMultiplayer));
        }
        
        protected void SetGoldCycle(int goldCycle)
        {
            goldPerCycle = goldCycle;
            baseGoldPerCycle = goldPerCycle;
        }
        
        IEnumerator GenerateGoldCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                int currentGoldPerCycle = (int)(baseGoldPerCycle * goldMultiplayer);
                Debug.Log("Current Gold Per Cycle: " + currentGoldPerCycle);
                gameManager.AddMoney(currentGoldPerCycle);
            }
        }
        
        private IEnumerator ResetGoldMultiplierAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            goldMultiplayer = 1f;
        }
        
    }
}