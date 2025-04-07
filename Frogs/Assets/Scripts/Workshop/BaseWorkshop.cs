using System;
using System.Collections;
using UnityEngine;

namespace Workshop
{
    public class BaseWorkshop : MonoBehaviour
    {
        [Header("Base Workshop Settings")]
        [SerializeField] protected string uniqueId = System.Guid.NewGuid().ToString();

        [Header("Base Workshop Stats")]
        [SerializeField] protected int level = 1;
        [SerializeField] protected int goldPerCycle = 1;
        [SerializeField] protected int goldPricePerLevel = 50;

        private GameManager gameManager;
        

        protected void Start()
        {
            StartCoroutine(GenerateGoldCoroutine());
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }

        IEnumerator GenerateGoldCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                gameManager.AddMoney(goldPerCycle);
            }
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
