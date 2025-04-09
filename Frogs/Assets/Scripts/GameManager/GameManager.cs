using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   private int Money = 0;

    void Start()
    {
        InvokeRepeating("TestFrogGeneration", 0f, 1f);
    }

    public void AddMoney(int addAmount){
    Money += addAmount;
   }

   public void RemoveMoney(int removeAmount){
    Money -= removeAmount;
   }

   public int GetMoney(){
    return Money;
   }

   void TestFrogGeneration(){
      new FrogClass();
   }
}
