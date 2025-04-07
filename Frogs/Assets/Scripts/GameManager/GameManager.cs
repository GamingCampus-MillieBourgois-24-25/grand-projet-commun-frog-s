using System;
using System.Collections;
using System.Collections.Generic;
using MiniGames;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
   private int Money = 0;

   [Header("UI")]
   [SerializeField] private GameObject workshopUIManager;

   private void Start()
   {
       workshopUIManager.SetActive(false);
   }

   public void AddMoney(int addAmount){
    Money += addAmount;
    Debug.Log(Money);
   }

   public void RemoveMoney(int removeAmount){
    Money -= removeAmount;
   }
   
   public void MultiplyMoney(float multiplier){
    Money = (int)(Money * multiplier);
   }

   public int GetMoney(){
    return Money;
   }
   
   public void ShowWorkshopUI_Manager(){
      workshopUIManager.SetActive(true);
   }
   
   public void HideWorkshopUI_Manager(){
      workshopUIManager.SetActive(false);
   }
   
}
