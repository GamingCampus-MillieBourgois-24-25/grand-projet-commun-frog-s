using NUnit.Framework.Constraints;
using System.Collections;
using UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int Money = 1;

    [Header("UI")]
    [SerializeField] private GameObject workshopUIManager;
    [SerializeField] private bool isStartedMiniGame = false;
    
    private void Start()
    {
        workshopUIManager.SetActive(false);
    }

    public void AddMoney(int addAmount)
    {
        Money += addAmount;
        Debug.Log("Current Money: " + Money);
    }

    public void RemoveMoney(int removeAmount)
    {
        Money -= removeAmount;
    }
    
    public void SetIsStartedMiniGame(bool isStarted)
    {
        isStartedMiniGame = isStarted;
    }
    
    public bool GetIsStartedMiniGame()
    {
        return isStartedMiniGame;
    }

    public int GetMoney()
    {
        return Money;
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
