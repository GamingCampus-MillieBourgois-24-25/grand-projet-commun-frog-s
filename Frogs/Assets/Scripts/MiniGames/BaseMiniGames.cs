using Unity.VisualScripting;
using UnityEngine;

namespace MiniGames
{
    public class BaseMiniGames : MonoBehaviour
    {
        [Header("Base Mini Game Settings")]
        [SerializeField] protected float goldMultiplier = 1.0f;
        [SerializeField] protected bool hasWin = false;
        
        [Header("Core Scripts")]
        [SerializeField] private GameManager gameManager;

        protected void Start()
        {
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }

        protected void Update()
        {
            if (!gameManager.isStartedMiniGame) return;

            if (!hasWin) return;
            ComputeGoldMultiplier();
            hasWin = false;
        }

        protected void ComputeGoldMultiplier()
        {
            gameManager.SetGoldMultiplayer(goldMultiplier);
        }  
        public void CloseMinigame()
        {
            Destroy(gameObject);
        }
    }
}
