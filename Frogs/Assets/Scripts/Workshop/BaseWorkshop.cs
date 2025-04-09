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
        [SerializeField] protected GameObject miniGame;

        [Header("Core Scripts")]
        [SerializeField] private GameManager gameManager;
        [SerializeField] private WorkshopUIManager workshopUIManager;

        protected void Awake()
        {
            uniqueId = System.Guid.NewGuid().ToString();
        }

        protected void Start()
        {
            StartCoroutine(GenerateGoldCoroutine());
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            workshopUIManager = gameManager.GetWorkshopUIManger();
        }

        IEnumerator GenerateGoldCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                gameManager.AddMoney(goldPerCycle);
            }
        }

        protected void OnMouseDown()
        {
            gameManager.ShowWorkshopUI_Manager();
            workshopUIManager.SetMiniGame(miniGame);
        }

        protected void Update()
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                UpgradeWorkshop();
            }
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
        
    }
}