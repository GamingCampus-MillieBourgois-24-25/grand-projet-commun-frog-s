using System.Collections.Generic;
using MiniGames;
using UnityEngine;

namespace UI
{
    public class WorkshopUIManager : MonoBehaviour
    {
        [Header("Canvas")]
        [SerializeField] private GameObject canvasContainer;
        
        [Header("MiniGames")]
        [SerializeField] private List<GameObject> miniGames = new List<GameObject>();
        
        public void OpenMiniGame(GameObject miniGame){
            GameObject miniGameInstance = Instantiate(miniGame, canvasContainer.transform);
            miniGames.Add(miniGameInstance);
        }
    }
}
