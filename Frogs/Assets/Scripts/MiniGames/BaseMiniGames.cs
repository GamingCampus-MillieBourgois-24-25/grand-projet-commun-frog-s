using Unity.VisualScripting;
using UnityEngine;

namespace MiniGames
{
    public class BaseMiniGames : MonoBehaviour
    {
        [Header("Base Mini Game Settings")]
        protected float GoldMultiplier = 1.0f;
        protected bool HasWin;
        
        [Header("Core Scripts")]
        [SerializeField] private GameManager gameManager;

        protected void Start()
        {
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }
        
        protected void Update()
        {
        }

        public void CloseMiniGame()
        {
            Destroy(gameObject);
        }
        
        public float GetGoldMultiplier()
        {
            return GoldMultiplier;
        }
        
        public bool GetHasWin()
        {
            return HasWin;
        }
        
        public void SetHasWin(bool hasWinSetter)
        {
            HasWin = hasWinSetter;
        }
    }
}
