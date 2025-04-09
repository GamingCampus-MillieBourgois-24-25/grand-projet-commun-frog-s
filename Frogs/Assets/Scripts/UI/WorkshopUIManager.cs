using System.Collections.Generic;
using MiniGames;
using UnityEngine;

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
        
        public void OpenMiniGame()
        {
            GameObject miniGameInstance = Instantiate(miniGame, canvasContainer.transform);
            miniGames.Add(miniGameInstance);
            gameManager.HideWorkshopUI_Manager();
            gameManager.SetIsStartedMiniGame(true);
        }
        
        public void SetMiniGame(GameObject miniGameToSet)
        {
            this.miniGame = miniGameToSet;
        }
    }
}
