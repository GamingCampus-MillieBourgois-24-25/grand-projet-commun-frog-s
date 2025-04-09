using System.Collections.Generic;
using MiniGames;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class WorkshopUIManager : MonoBehaviour
    {
        [Header("Manager")]
        [SerializeField] private GameManager gameManager;
        
        [Header("Canvas")]
        [SerializeField] private GameObject canvasContainer;
        
        [Header("MiniGames")]
        [SerializeField] private List<GameObject> miniGames = new List<GameObject>();
        [SerializeField] private GameObject miniGame;
        [SerializeField] private GameObject currentMiniGame;

        private UnityEvent<BaseMiniGames> onMiniGameCreated = new UnityEvent<BaseMiniGames>();
        
        public void OpenMiniGame()
        {
            currentMiniGame = Instantiate(miniGame, canvasContainer.transform);
            miniGames.Add(currentMiniGame);
            gameManager.HideWorkshopUI_Manager();
            gameManager.SetIsStartedMiniGame(true);
            
            onMiniGameCreated?.Invoke(currentMiniGame.GetComponent<BaseMiniGames>());
        }
        
        public void SetMiniGame(GameObject miniGameToSet)
        {
            this.miniGame = miniGameToSet;
        }
        
        public UnityEvent<BaseMiniGames> GetOnMiniGameCreated()
        {
            return onMiniGameCreated;
        }
    }
}
