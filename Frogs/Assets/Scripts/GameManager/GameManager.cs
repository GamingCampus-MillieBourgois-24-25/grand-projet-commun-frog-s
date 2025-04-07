using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   private int Money = 0;

   public void AddMoney(int addAmount){
    Money += addAmount;
    Debug.Log(Money);
   }

   public void RemoveMoney(int removeAmount){
    Money -= removeAmount;
   }

   public int GetMoney(){
    return Money;
   }
}
