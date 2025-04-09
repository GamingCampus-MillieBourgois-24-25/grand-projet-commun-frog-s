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
            goldPerCycle = (int)(goldPerCycle * goldMultiplayer);
            
            Debug.Log("miniGameScript.GetHasWin(): " + miniGameScript.GetHasWin());
            Debug.Log("miniGameScript.GetGoldMultiplier(): " + miniGameScript.GetGoldMultiplier());

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
                goldPerCycle *= 2;
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
        
        IEnumerator GenerateGoldCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                gameManager.AddMoney(goldPerCycle);
            }
        }
        
        private IEnumerator ResetGoldMultiplierAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            goldMultiplayer = 1f;
        }
        
    }
}