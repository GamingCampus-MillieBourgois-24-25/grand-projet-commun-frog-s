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
        }

        public void CloseMiniGame()
        {
            Destroy(gameObject);
        }
        
        public float GetGoldMultiplier()
        {
            return goldMultiplier;
        }
        
        public bool GetHasWin()
        {
            return hasWin;
        }
        
        public void SetHasWin(bool hasWinSetter)
        {
            hasWin = hasWinSetter;
        }
    }
}
