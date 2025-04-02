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
        
        [Header("Player Test")]
        public int playerGold = 0;

        protected void Start()
        {
            StartCoroutine(GenerateGoldCoroutine());
        }

        IEnumerator GenerateGoldCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                playerGold += goldPerCycle;
                Debug.Log("Gold generated! PlayerGold: " + playerGold);
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
            if (playerGold >= goldPricePerLevel)
            {
                playerGold -= goldPricePerLevel;
                level++;
                goldPerCycle *= 2;
                goldPricePerLevel *= 2;
                Debug.Log("Workshop upgraded! New level: " + level);
            }
            else
            {
                Debug.Log("Not enough gold to upgrade the workshop.");
            }
        }

    }
}
