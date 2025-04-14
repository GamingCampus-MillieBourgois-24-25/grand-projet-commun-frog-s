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

        private UnityEvent<BaseMiniGames> onMiniGameCreated = new UnityEvent<BaseMiniGames>();
        private BaseWorkshop activeWorkshop;
        
        public void OpenMiniGame()
        {
            currentMiniGame = Instantiate(miniGamePrefab, canvasContainer.transform);
            gameManager.HideWorkshopUI_Manager();
            gameManager.SetIsStartedMiniGame(true);

            onMiniGameCreated?.Invoke(currentMiniGame.GetComponent<BaseMiniGames>());
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
        
        public UnityEvent<BaseMiniGames> GetOnMiniGameCreated()
        {
            return onMiniGameCreated;
        }
    }
}
