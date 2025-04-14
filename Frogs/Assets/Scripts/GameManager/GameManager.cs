using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject workshopUIManager;
    [SerializeField] private bool isStartedMiniGame = false;

    [Header("Player")]
    [SerializeField] private int golds;
    [SerializeField] private int diamonds;
    
    private void Start()
    {
        workshopUIManager.SetActive(false);
    }

    public void AddMoney(int addAmount)
    {
        Debug.Log("Current gold per cycle: " + addAmount);
        golds += addAmount;
        Debug.Log("Current golds: " + golds);
    }

    public void RemoveGolds(int removeAmount)
    {
        golds -= removeAmount;
    }
    
    public int GetGolds()
    {
        return golds;
    }
    
    public void AddDiamonds(int addAmount)
    {
        diamonds += addAmount;
        Debug.Log("Current diamonds: " + diamonds);
    }
    
    public void RemoveDiamonds(int removeAmount)
    {
        diamonds -= removeAmount;
    }
    
    public int GetDiamonds()
    {
        return diamonds;
    }
    
    public void SetIsStartedMiniGame(bool isStarted)
    {
        isStartedMiniGame = isStarted;
    }
    
    public bool GetIsStartedMiniGame()
    {
        return isStartedMiniGame;
    }

    public WorkshopUIManager GetWorkshopUIManger()
    {
        return workshopUIManager.GetComponent<WorkshopUIManager>();
    }

    public void ShowWorkshopUI_Manager()
    {
        workshopUIManager.SetActive(true);
    }

    public void HideWorkshopUI_Manager()
    {
        workshopUIManager.SetActive(false);
    }
}
