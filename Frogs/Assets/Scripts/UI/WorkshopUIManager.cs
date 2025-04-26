using System.Collections.Generic;
using MiniGames;
using UnityEngine;
using UnityEngine.Events;
using Workshop;

namespace UI
{
    public class WorkshopUIManager : MonoBehaviour
    {
        [Header("Manager")]
        [SerializeField] private GameManager gameManager;
        
        [Header("Canvas")]
        [SerializeField] private GameObject canvasContainer;
        
        [Header("MiniGames")]
        [SerializeField] private GameObject miniGamePrefab;
        [SerializeField] private GameObject currentMiniGame;

        private BaseWorkshop activeWorkshop;
        private bool miniGameSold = false;
        private bool upgradeWorkshop = false;
        
        public void Start()
        {
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            canvasContainer = GameObject.FindGameObjectWithTag("MainCanvas");
        }
        
        public void OpenMiniGame()
        {
            currentMiniGame = Instantiate(miniGamePrefab, canvasContainer.transform);
            gameManager.HideWorkshopUI_Manager();
            gameManager.SetIsStartedMiniGame(true);

        }

        public void SellMiniGame()
        {
            miniGameSold = true;
        }

        public void UpgradeWorkshop()
        {
            upgradeWorkshop = true;
        }
        
        public void SetMiniGamePrefab(GameObject miniGameToSet)
        {
            miniGamePrefab = miniGameToSet;
        }
        
        public void SetActiveWorkshop(BaseWorkshop workshop)
        {
            activeWorkshop = workshop;
        }

        public BaseWorkshop GetActiveWorkshop()
        {
            return activeWorkshop;
        }
        
        public bool GetMiniGameSold()
        {
            return miniGameSold;
        }
        
        public void SetMiniGameSold(bool miniGameSoldSetter)
        {
            miniGameSold = miniGameSoldSetter;
        }
        
        public bool GetUpgradeWorkshop()
        {
            return upgradeWorkshop;
        }
        
        public void SetUpgradeWorkshop(bool upgradeWorkshopSetter)
        {
            upgradeWorkshop = upgradeWorkshopSetter;
        }
    }
}
