using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MiniGames;
using UI;
using UnityEngine;

namespace Workshop
{
    public enum WorkshopType
    {
        Florist,
        Miner,
        Baker,
        Lumberjack,
        Artist,
        Farmer,
        Writer,
        Fisher,
        Blacksmith,
        Cobbler,
        Alchemist,
        Jeweler 
    }

    
    
    public class BaseWorkshop : MonoBehaviour
    {
        [Header("Base Workshop Settings")]
        [SerializeField, HideInInspector] private string uniqueId;
        public string UniqueId => uniqueId;

        [Header("Base Workshop Stats")]
        [SerializeField] protected int level = 1;
        public int baseGoldPerCycle = 1;
        public int goldPerCycle = 1;
        public int goldPricePerLevel = 50;
        public WorkshopType workshopType;

        [Header("Core")]
        [SerializeField] private GameManager gameManager;
        [SerializeField] private WorkshopUIManager workshopUIManager;
        [SerializeField] protected GameObject miniGamePrefab;
        [SerializeField] protected BaseMiniGames miniGameScript;

        [Header("Frogs")]
        [SerializeField] public GameObject Frog;
        [SerializeField] public FrogColor ColorFrog;

        public float goldMultiplayer = 1f;
        public float goldTimerMultiplayer = 5f;
        public bool hasWonMiniGame= false;

        private Coroutine _goldMultiplierCoroutine;

        private bool Swapping = true;
        
        protected void Awake()
        {
            uniqueId = System.Guid.NewGuid().ToString();
        }

        protected void Start()
        {
            StartCoroutine(GenerateGoldCoroutine());
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            workshopUIManager = gameManager.GetWorkshopUIManger();
            workshopUIManager.GetOnMiniGameCreated().AddListener(OnMiniGameCreated);
        }
        
        protected void Update()
        {
            if(Swapping){
                if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
                {
                    
                    Ray ray;
                    
                    if (Input.touchCount > 0)
                    {
                        Touch touch = Input.GetTouch(0);
                        ray = Camera.main.ScreenPointToRay(touch.position);
                    }
                    else
                    {
                        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    }

                    
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.gameObject.GetComponent<BaseWorkshop>() != null || hit.collider.gameObject.GetComponent<BaseWorkshop>() != null)
                        {
                            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.green); 
                            SwapPlace(hit.collider.gameObject);
                        }
                        else{
                            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red); 
                        }
                    }
                }
            }

            if (!miniGameScript) return;
            if (miniGameScript.GetHasWin() && !hasWonMiniGame)
            {
                StartGoldMultiplayer();
                hasWonMiniGame= true;
            }
            
            if (Input.GetKeyDown(KeyCode.U))
            {
                UpgradeWorkshop();
            }
        }

        protected void OnMouseDown()
        {
            gameManager.ShowWorkshopUI_Manager();
            workshopUIManager.SetMiniGamePrefab(miniGamePrefab);
            workshopUIManager.SetActiveWorkshop(this);
        }
        
        private void OnMiniGameCreated(BaseMiniGames miniGame)
        {
            if (workshopType != workshopUIManager.GetActiveWorkshop().workshopType)
            {
                return;
            }
            
            Debug.Log("MiniGame Created: " + miniGame.gameObject.name);
            miniGameScript = miniGame;
            miniGameScript.SetHasWin(false);
        }

        private void UpgradeWorkshop()
        {
            if (gameManager.GetGolds() >= goldPricePerLevel)
            {
                gameManager.RemoveGolds(goldPricePerLevel);
                level++;
                baseGoldPerCycle *= 2;
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
        
        protected void SetGoldCycle(int goldCycle)
        {
            goldPerCycle = goldCycle;
            baseGoldPerCycle = goldPerCycle;
        }
        
        IEnumerator GenerateGoldCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                int currentGoldPerCycle = (int)(baseGoldPerCycle * goldMultiplayer);
                gameManager.AddMoney(currentGoldPerCycle);
            }
        }
        
        private IEnumerator ResetGoldMultiplierAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            goldMultiplayer = 1f;
            hasWonMiniGame= false;
        }

        private void SwapPlace(GameObject swapWith){
            Vector3 MyInitPos = transform.position;
            transform.position = swapWith.transform.position;
            swapWith.transform.position = MyInitPos;
        }
        
    }
}